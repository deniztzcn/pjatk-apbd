namespace apbd_tutorial02;

public class Product : Cargo
{
    public double RequiredTemperature { get; set; }

    public Product(string name, double weight, double requiredTemperature) 
        : base(name, weight)
    {
        RequiredTemperature = requiredTemperature;
    }
}