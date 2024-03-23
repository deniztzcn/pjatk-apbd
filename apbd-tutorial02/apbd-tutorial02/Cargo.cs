namespace apbd_tutorial02;

public abstract class Cargo
{
    public string Name { get; set; }
    public double Weight { get; set; }

    public Cargo(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }
}