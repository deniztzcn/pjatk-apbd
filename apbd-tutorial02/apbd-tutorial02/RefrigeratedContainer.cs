namespace apbd_tutorial02;

public class RefrigeratedContainer: Container
{
    public double Temperature
    {
        get => Temperature;
        set
        {
            if (value <= GetMaxTemperature())
            {
                Console.WriteLine("Temperature can not be lower than " + GetMaxTemperature());
            }
            else
            {
                Temperature = value;
            }
        }
    }

    public string TypeOfProduct { get; set; }
    public List<Product> ListOfProducts { get; set; }
    public RefrigeratedContainer(double height, double tareWeight, double depth, double maxKg)
        : base(height, tareWeight, depth, maxKg, "C")
    {
        ListOfProducts = new List<Product>();
    }

    public override void EmptyTheCargo()
    {
        ListOfProducts.Clear();
        Temperature = 0.0;
        TypeOfProduct = null;
    }

    public override void LoadCargo(Cargo cargo)
    {
        if (!ListOfProducts.Any())
        {
            if (MassKg + cargo.Weight <= MaxKg)
            {
                MassKg += cargo.Weight;
                ListOfProducts.Add((Product)cargo);
                Temperature = GetMaxTemperature();
                TypeOfProduct = ((Product)cargo).Name;
            }
            else
            {
                throw new OverFillException(cargo + " exceeds the capacity of " + SerialNumber);
            }
        } else if (cargo.Name.Equals(TypeOfProduct,StringComparison.OrdinalIgnoreCase))
        {
            if (MassKg + cargo.Weight <= MaxKg)
            {
                MassKg += cargo.Weight;
                ListOfProducts.Add((Product)cargo);
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
        return ListOfProducts.OfType<Product>().Max(p => p.RequiredTemperature);
    }
}