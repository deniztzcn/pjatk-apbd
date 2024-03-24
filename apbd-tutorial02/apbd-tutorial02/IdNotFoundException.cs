namespace apbd_tutorial02;

public class IdNotFoundException: Exception
{
    public IdNotFoundException(string message) :
        base(message)
    {
    }
}