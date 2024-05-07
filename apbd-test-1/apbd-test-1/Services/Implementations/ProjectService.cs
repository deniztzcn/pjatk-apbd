using apbd_example_test.Services.Abstractions;
using apbd_test_1.DTO;
using apbd_test_1.Models;
using apbd_test_1.Repositories.Abstractions;

namespace apbd_example_test.Services.Implementations;

public class ProjectService: IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly ITeamMemberRepository _teamMemberRepository;
    private readonly ITaskTypeRepository _taskTypeRepository;

    public ProjectService(IProjectRepository projectRepository, ITaskRepository taskRepository, ITeamMemberRepository teamMemberRepository, ITaskTypeRepository taskTypeRepository)
    {
        _projectRepository = projectRepository;
        _taskRepository = taskRepository;
        _teamMemberRepository = teamMemberRepository;
        _taskTypeRepository = taskTypeRepository;
    }

    public async Task<bool> IsTeamMemberExists(int id)
    {
        var teamMember = await _teamMemberRepository.GetTeamMember(id);

        return teamMember != null;
    }

    public async Task<TeamMemberDTO> GetTeamMemberAndTasks(int id)
    {
        TeamMemberDTO teamMemberDto = new TeamMemberDTO();
        var teamMember = await _teamMemberRepository.GetTeamMember(id);
        var assignedTasks = new List<TaskDTO>();
        var createdTasks = new List<TaskDTO>();

        foreach (var task in await _taskRepository.GetCreatedTasks(id))
        {
            createdTasks.Add(new TaskDTO
            {
                Name = task.Name,
                Description = task.Description,
                Deadline = task.Deadline,
                ProjectName = await _projectRepository.GetProjectName(task.IdProject),
                TaskType = await _taskTypeRepository.GetTaskType(task.IdTaskType),
            });        
        }
        
        foreach (var task in await _taskRepository.GetAssignedTasks(id))
        {
            assignedTasks.Add(new TaskDTO
            {
                Name = task.Name,
                Description = task.Description,
                Deadline = task.Deadline,
                ProjectName = await _projectRepository.GetProjectName(task.IdProject),
                TaskType = await _taskTypeRepository.GetTaskType(task.IdTaskType),
            });        
        }

        teamMemberDto.IdTeamMember = teamMember.IdTeamMember;
        teamMemberDto.FirstName = teamMember.FirstName;
        teamMemberDto.LastName = teamMember.LastName;
        teamMemberDto.Email = teamMember.Email;
        teamMemberDto.AssignedTasks = assignedTasks;
        teamMemberDto.CreatedTasks = createdTasks;
        return teamMemberDto;
    }

    public async Task<bool> DeleteProject(int id)
    {
        var deleteTask = await _taskRepository.DeleteTask(id);
        var deleteProject = await _projectRepository.DeleteProject(id);

        if (deleteTask && deleteProject)
        {
            return true;
        }

        return false;
    }
}