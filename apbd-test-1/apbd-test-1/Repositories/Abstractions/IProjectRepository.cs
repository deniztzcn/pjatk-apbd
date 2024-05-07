namespace apbd_test_1.Repositories.Abstractions;

public interface IProjectRepository
{
    Task<string?> GetProjectName(int id);
    Task<bool> DeleteProject(int idProject);
}