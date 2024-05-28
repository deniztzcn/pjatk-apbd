namespace apbd_tutorial08.Exceptions;

public class ClientHasAssignedTrips : Exception
{
    public ClientHasAssignedTrips(int id) : base($"Client with id {id} has assigned trips.")
    {
        
    }
}