namespace apbd_tutorial02;

public class GasCargo: Cargo
{
    public double Pressure { get; set; }

    public GasCargo(string name, double weight, double pressure)
        : base(name, weight)
    {
        Pressure = pressure;
    }
}