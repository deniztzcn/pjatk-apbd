namespace apbd_tutorial02;

public class LiquidContainer: Container,IHazardNotifier
{
    public bool IncludeHazardous { get; set; }

    public LiquidContainer(double height, double tareWeight, double depth, double maxKg)
    :base(height,tareWeight,depth,maxKg,"L") {}
    
    
    public void HazardousSituation(string message)
    {
        Console.WriteLine("WARNING! Hazardous situation on" + SerialNumber);
    }

    public override void LoadCargo(Cargo cargo)
    {
        if (cargo.IsHazardous)
        {
            if (cargo.Weight <= MaxKg * 0.5)
            {
                Cargo = cargo;
                MassKg = cargo.Weight;
                IncludeHazardous = true;
            }
            else
            {
                throw new OverFillException("Exceeds the capacity of " + SerialNumber);
            }
        }
        else
        {
            if (cargo.Weight <= MaxKg * 0.9)
            {
                Cargo = cargo;
                MassKg = cargo.Weight;
            }
            else
            {
                throw new OverFillException("Exceeds the capacity of " + SerialNumber);
            }
        }
    }

    public override void EmptyTheCargo()
    {
        Cargo = null;
        MassKg = 0.0;
        IncludeHazardous = false;
    }
}