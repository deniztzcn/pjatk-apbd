using apbd_test_1.DTO;

namespace apbd_example_test.Services.Abstractions;

public interface IProjectService
{
    Task<bool> IsTeamMemberExists(int id);
    Task<TeamMemberDTO> GetTeamMemberAndTasks(int id);
    Task<bool> DeleteProject(int id);
}