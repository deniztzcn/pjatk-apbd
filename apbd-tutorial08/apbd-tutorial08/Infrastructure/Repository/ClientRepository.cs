using apbd_tutorial08.Application.Repository;
using apbd_tutorial08.Context;
using apbd_tutorial08.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace apbd_tutorial08.Infrastructure.Repository;

public class ClientRepository: IClientRepository
{
    private readonly Apbd08Context _apbd08Context;

    public ClientRepository(Apbd08Context apbd08Context)
    {
        _apbd08Context = apbd08Context;
    }

    public async Task DeleteClientAsync(int id)
    {
        var client = await _apbd08Context.Clients
            .Include(c => c.ClientTrips)
            .FirstOrDefaultAsync(c => c.IdClient == id);
        
        if (client == null)
        {
            throw new ClientNotFound(id);
        }

        if (client.ClientTrips.Any())
        {
            throw new ClientHasAssignedTrips(id);
        }

        _apbd08Context.Clients.Remove(client);
        await _apbd08Context.SaveChangesAsync();
    } 
}