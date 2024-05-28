using apbd_tutorial08.Application.Repository;
using apbd_tutorial08.Application.Services.Abstraction;

namespace apbd_tutorial08.Application.Services.Implementation;

public class ClientService: IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task DeleteClientAsync(int id)
    {
        await _clientRepository.DeleteClientAsync(id);
    }
}