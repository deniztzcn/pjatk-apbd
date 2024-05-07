using apbd_test_1.Models;
using Task = apbd_test_1.Models.Task;

namespace apbd_test_1.DTO;

public class TeamMemberDTO
{
    public int IdTeamMember { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<TaskDTO> AssignedTasks { get; set; }
    public List<TaskDTO> CreatedTasks { get; set; }
}