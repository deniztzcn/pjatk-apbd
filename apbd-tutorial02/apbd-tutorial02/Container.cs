using System.Runtime.CompilerServices;
using System.Text;

namespace apbd_tutorial02;

public abstract class Container
{
    public double Height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    public double MassKg { get; set; }
    public string ContainerType { get; set; }
    public double MaxKg { get; set; }
    private static int _counter = 1;
    public int Id { get; set; }
    public string SerialNumber { get; set; }
    public List<Cargo> ListOfCargos { get; }
    public Ship carrier { get; set; }

    public Container(double height, double tareWeight, double depth, double maxKg, string containerType)
    {
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        MaxKg = maxKg;
        Id = _counter++;
        ContainerType = containerType;
        SerialNumber = "KON-" + ContainerType + "-"+ Id;
        ListOfCargos = new List<Cargo>();
    }

    public abstract void EmptyTheCargo();

    public abstract void LoadCargo(Cargo cargo);

    public override string ToString()
    {
        StringBuilder cargoString = new StringBuilder();
        foreach (var cargo in ListOfCargos)
        {
            cargoString.Append(cargo).Append(", ");
        }

        string cargoListString = cargoString.ToString().TrimEnd(' ', ',');

        if (carrier == null)
        {
            return $"{SerialNumber} [{cargoListString} | {MassKg}/{MaxKg} kg] not in any ship.";    
        }
        else
        {
            return $"{SerialNumber} [{cargoListString} | {MassKg}/{MaxKg} kg] in ship {carrier.Id}.";
        } 
        
    }
}