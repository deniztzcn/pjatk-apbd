namespace apbd_tutorial02;

public class ProductTypeNotMatchException: Exception
{
    public ProductTypeNotMatchException(string message) : base(message)
    {
    }
}