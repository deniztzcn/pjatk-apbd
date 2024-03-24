namespace apbd_tutorial02;

public class NotEnoughSpaceException: Exception
{
    public NotEnoughSpaceException(string message) : base(message)
    {
    }
}