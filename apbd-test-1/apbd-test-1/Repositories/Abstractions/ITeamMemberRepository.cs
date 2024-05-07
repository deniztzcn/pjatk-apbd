using apbd_test_1.Models;

namespace apbd_test_1.Repositories.Abstractions;

public interface ITeamMemberRepository
{
    Task<TeamMember?> GetTeamMember(int id);
}