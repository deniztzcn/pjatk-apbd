using System.Data.Common;
using System.Data.SqlClient;
using apbd_example_test.Services.Abstractions;
using apbd_test_1.Models;
using apbd_test_1.Repositories.Abstractions;
using Task = System.Threading.Tasks.Task;

namespace apbd_test_1.Repositories.Implementations;

public class TaskRepository: ITaskRepository
{
    private readonly string _connectionString;

    public TaskRepository(IDbConnectionService connectionService)
    {
        _connectionString = connectionService.GetConnectionString;
    }

    public async Task<List<Models.Task>> GetAssignedTasks(int id)
    {
        List<Models.Task> assignedTasks = new List<Models.Task>();
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Task WHERE IdAssignedTo = @IdTeamMember ORDER BY Deadline DESC";
        command.Parameters.AddWithValue("@IdTeamMember", id);
        
        await connection.OpenAsync();

        using (var dr = await command.ExecuteReaderAsync())
        {
            while (await dr.ReadAsync())
            {
                assignedTasks.Add(new Models.Task
                {
                    IdProject = (int) dr["IdProject"],
                    IdTaskType = (int) dr["IdTaskType"],
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Deadline = (DateTime) dr["Deadline"],
                }); 
                
            }
        }

        return assignedTasks;
    }
    public async Task<List<Models.Task>> GetCreatedTasks(int id)
    {
        List<Models.Task> createdTasks = new List<Models.Task>();
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = "SELECT * FROM Task WHERE IdCreator = @IdTeamMember ORDER BY Deadline DESC";
        command.Parameters.AddWithValue("@IdTeamMember", id);
        
        await connection.OpenAsync();

        using (var dr = await command.ExecuteReaderAsync())
        {
            while (await dr.ReadAsync())
            {
                createdTasks.Add(new Models.Task
                {
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                    Deadline = (DateTime) dr["Deadline"],
                }); 
                
            }
        }

        return createdTasks;
    }

    public async Task<bool> DeleteTask(int idProject)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "DELETE FROM Task WHERE IdProject = @IdProject";
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