namespace apbd_tutorial02;

public class OverFillException : Exception
{
    public OverFillException(string message)
        : base(message){}
}