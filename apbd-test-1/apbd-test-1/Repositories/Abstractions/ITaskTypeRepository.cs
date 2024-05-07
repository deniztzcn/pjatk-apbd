namespace apbd_test_1.Repositories.Abstractions;

public interface ITaskTypeRepository
{
    Task<string?> GetTaskType(int id);
}