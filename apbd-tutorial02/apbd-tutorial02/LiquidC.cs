namespace apbd_tutorial02;

public class LiquidC: Container,IHazardNotifier
{
    public bool IncludeHazardous { get; set; }

    public LiquidC(double height, double tareWeight, double depth, double maxKg)
    :base(height,tareWeight,depth,maxKg,"L") {}
    
    
    public void HazardousSituation(string message)
    {
        Console.WriteLine("WARNING! Hazardous situation on" + SerialNumber);
    }

    public override void LoadCargo(Cargo cargo)
    {
        if (cargo is HazardousCargo)
        {
            if (MassKg + cargo.Weight <= MaxKg * 0.5)
            {
                ListOfCargos.Add(cargo);
                MassKg += cargo.Weight;
                IncludeHazardous = true;
            }
            else
            {
                throw new OverFillException("Exceeds the capacity of " + SerialNumber);
            }
        }
        else
        {
            if (MassKg + cargo.Weight <= MaxKg * 0.9)
            {
                ListOfCargos.Add(cargo);
                MassKg += cargo.Weight;
            }
            else
            {
                throw new OverFillException("Exceeds the capacity of " + SerialNumber);
            }
        }
    }

    public override void EmptyTheCargo()
    {
        ListOfCargos.Clear();
        MassKg = 0.0;
        IncludeHazardous = false;
    }
}