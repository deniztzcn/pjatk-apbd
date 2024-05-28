namespace apbd_tutorial08.Exceptions;

public class ClientAlreadyRegisteredTrip : Exception
{
    public ClientAlreadyRegisteredTrip(string pesel):base($"Client with pesel {pesel} already registered for the trip."){
        
    }
}