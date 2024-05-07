using apbd_example_test.Services.Abstractions;
using apbd_test_1.DTO;
using Microsoft.AspNetCore.Mvc;

namespace apbd_test_1.Controllers;

[Route("api/tasks")]
[ApiController]
public class ProjectController: ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamMemberAndTasks(int id)
    {
        var isTeamMemberExists = await _projectService.IsTeamMemberExists(id);
        if (!isTeamMemberExists)
        {
            return BadRequest($"Team member with id {id} does not exist.");
        }

        var teamMemberDTO = await _projectService.GetTeamMemberAndTasks(id);

        return Ok(teamMemberDTO);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProject(int id)
    {
        var deleteTask = await _projectService.DeleteProject(id);
        if (deleteTask)
        {
            return Ok("Project deleted.");
        }

        return BadRequest("Something went wrong.");
    }
}