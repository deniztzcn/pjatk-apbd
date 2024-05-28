namespace apbd_tutorial08.Application.Services.Abstraction;

public interface IClientService
{
    Task DeleteClientAsync(int id);
}