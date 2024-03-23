namespace apbd_tutorial02;

public class RefrigeratedC: Container
{
    public double Temperature { get; set; }
    public string TypeOfProduct { get; set; }
    public List<string> Products { get; }
    public RefrigeratedC(double height, double tareWeight, double depth, double maxKg,string typeOfProduct, double temperature)
        : base(height, tareWeight, depth, maxKg, "C")
    {
        Products = new List<string>();
        TypeOfProduct = typeOfProduct;
        Temperature = temperature;
    }

    public override void EmptyTheCargo()
    {
        Products.Clear();
    }

    public override void LoadCargo(Cargo cargo)
    {
        throw new NotImplementedException();
    }
}