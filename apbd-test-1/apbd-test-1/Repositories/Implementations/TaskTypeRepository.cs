using System.Data.SqlClient;
using apbd_example_test.Services.Abstractions;
using apbd_test_1.Repositories.Abstractions;

namespace apbd_test_1.Repositories.Implementations;

public class TaskTypeRepository: ITaskTypeRepository
{
    private readonly string _connectionString;

    public TaskTypeRepository(IDbConnectionService connectionService)
    {
        _connectionString = connectionService.GetConnectionString;
    }

    public async Task<string?> GetTaskType(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = "SELECT * FROM TaskType WHERE IdTaskType = @IdTaskType";
        command.Parameters.AddWithValue("@IdTaskType", id);
        
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
}