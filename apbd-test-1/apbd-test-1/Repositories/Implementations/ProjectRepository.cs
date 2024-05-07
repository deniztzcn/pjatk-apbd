using System.Data.Common;
using System.Data.SqlClient;
using apbd_example_test.Services.Abstractions;
using apbd_test_1.Repositories.Abstractions;

namespace apbd_test_1.Repositories.Implementations;

public class ProjectRepository: IProjectRepository
{
    private readonly string _connectionString;

    public ProjectRepository(IDbConnectionService connectionService)
    {
        _connectionString = connectionService.GetConnectionString;
    }

    public async Task<string?> GetProjectName(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Project WHERE IdProject = @IdProject";
        command.Parameters.AddWithValue("@IdProject", id);
        
        await connection.OpenAsync();

        using (var dr = await command.ExecuteReaderAsync())
        {
            if (await dr.ReadAsync())
            {
                return dr["Name"].ToString();
            }
        }

        return null;
    }
    
    public async Task<bool> DeleteProject(int idProject)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "DELETE FROM Project WHERE IdProject = @IdProject";
        command.Parameters.AddWithValue("@IdProject", idProject);

        await connection.OpenAsync();
        
        DbTransaction tran = await connection.BeginTransactionAsync();
        command.Transaction = (SqlTransaction)tran;
        
        try
        {
            await command.ExecuteNonQueryAsync();
            await tran.CommitAsync();
            return true;
        }
        catch (SqlException exception)
        {
            await tran.RollbackAsync();
            throw;
        }
        catch (Exception exception)
        {
            await tran.RollbackAsync();
            throw;
        }

    }
}