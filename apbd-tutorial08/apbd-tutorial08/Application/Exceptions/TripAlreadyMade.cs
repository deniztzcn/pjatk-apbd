namespace apbd_tutorial08.Exceptions;

public class TripAlreadyMade : Exception
{
    public TripAlreadyMade(int id) : base($"Trip with id {id} is already made.")
    {
        
    }
}