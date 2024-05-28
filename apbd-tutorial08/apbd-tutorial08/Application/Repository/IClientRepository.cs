namespace apbd_tutorial08.Application.Repository;

public interface IClientRepository
{
    Task DeleteClientAsync(int id);
}