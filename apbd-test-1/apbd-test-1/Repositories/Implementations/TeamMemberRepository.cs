using System.Data.SqlClient;
using apbd_example_test.Services.Abstractions;
using apbd_test_1.Models;
using apbd_test_1.Repositories.Abstractions;

namespace apbd_test_1.Repositories.Implementations;

public class TeamMemberRepository: ITeamMemberRepository
{
    private readonly string _connectionString;

    public TeamMemberRepository(IDbConnectionService connectionService)
    {
        _connectionString = connectionService.GetConnectionString;
    }

    public async Task<TeamMember?> GetTeamMember(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = "SELECT * FROM TeamMember WHERE IdTeamMember = @IdTeamMember";
        command.Parameters.AddWithValue("@IdTeamMember", id);
        
        await connection.OpenAsync();
        
        using (var dr = await command.ExecuteReaderAsync())
        {
            if (await dr.ReadAsync())
            {
                return new TeamMember()
                {
                    IdTeamMember = (int) dr["IdTeamMember"],
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    Email = dr["Email"].ToString()
                };
            }
        }

        return null;
    }
}