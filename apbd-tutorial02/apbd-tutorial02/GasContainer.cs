namespace apbd_tutorial02;

public class GasContainer : Container,IHazardNotifier
{
    public GasContainer(double height, double tareWeight, double depth, double maxKg)
        :base(height,tareWeight,depth,maxKg,"G"){}

    public override void EmptyTheCargo()
    {
        MassKg = MassKg * 0.95;
        
    }

    public override void LoadCargo(Cargo cargo)
    {
        if (MassKg + cargo.Weight <= MaxKg)
        {
            ListOfCargos.Add(cargo);
            MassKg += cargo.Weight;
        }
        else
        {
            throw new OverFillException(cargo + " exceeds the capacity of " + SerialNumber);
        }
    }

    public void HazardousSituation(string message)
    {
        Console.WriteLine("WARNING! Hazardous situation on " + SerialNumber);
    }

    public double TotalPressure()
    {
        double result = 0.0;
        foreach (Cargo c in ListOfCargos)
        {
            result += ((GasCargo)c).Pressure;
        }

        return result;
    }
}