using apbd_test_1.Models;
using Task = apbd_test_1.Models.Task;

namespace apbd_test_1.Repositories.Abstractions;

public interface ITaskRepository
{
    Task<List<Task>> GetAssignedTasks(int id);
    Task<List<Task>> GetCreatedTasks(int id);
    Task<bool> DeleteTask(int idProject);
}