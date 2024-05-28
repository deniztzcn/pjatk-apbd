namespace apbd_tutorial08.Exceptions;

public class ClientAlreadyExists: Exception
{
    public ClientAlreadyExists(string pesel) : base($"Client with pesel {pesel} already exists.")
    {
        
    }
}