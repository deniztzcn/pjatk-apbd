namespace apbd_tutorial02;

public class GasC : Container,IHazardNotifier
{
    public GasC(double height, double tareWeight, double depth, double maxKg, string containerType)
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
            throw new OverFillException("Exceeds the capacity of " + SerialNumber);
        }
    }

    public void HazardousSituation(string message)
    {
        Console.WriteLine("WARNING! Hazardous situation on " + SerialNumber);
    }
}