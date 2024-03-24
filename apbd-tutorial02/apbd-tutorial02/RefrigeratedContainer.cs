namespace apbd_tutorial02;

public class RefrigeratedContainer: Container
{
    public double Temperature { get; set; }
    public string TypeOfProduct { get; set; }
    public RefrigeratedContainer(double height, double tareWeight, double depth, double maxKg,string typeOfProduct, double temperature)
        : base(height, tareWeight, depth, maxKg, "C")
    {
        TypeOfProduct = typeOfProduct;
        Temperature = temperature;
    }

    public override void EmptyTheCargo()
    {
        ListOfCargos.Clear();
        Temperature = 0.0;
    }

    public override void LoadCargo(Cargo cargo)
    {
        if (cargo.Name.Equals(TypeOfProduct,StringComparison.OrdinalIgnoreCase))
        {
            if (MassKg + cargo.Weight <= MaxKg)
            {
                MassKg += cargo.Weight;
                ListOfCargos.Add(cargo);
                Temperature = GetMaxTemperature();
            }
            else
            {
                throw new OverFillException(cargo + " exceeds the capacity of " + SerialNumber);
            }
        }
        else
        {
            throw new ProductTypeNotMatchException("ERROR! The product was supposed to be " + TypeOfProduct);
        }
    }

    private double GetMaxTemperature()
    {
        return ListOfCargos.OfType<Product>().Max(p => p.RequiredTemperature);
    }
}