namespace apbd_tutorial02;

public class Ship
{
    public List<Container> ListOfContainers { get; }
    public double MaxSpeed { get; set; }
    public double CurrentSpeed { get; set; }
    public int MaxNumberOfContainers { get; set; }
    
    public double MaxWeight { get; set; }
    private static int counter = 1;
    public int Id { get; set; }

    public Ship(double maxSpeed, int maxNumberOfContainers, double maxWeight)
    {
        ListOfContainers = new List<Container>();
        MaxSpeed = maxSpeed;
        MaxNumberOfContainers = maxNumberOfContainers;
        MaxWeight = maxWeight;
        Id = counter++;
    }

    public void addContainer(Container container)
    {
        if (container.MassKg + CurrentWeight() <= MaxWeight)
        {
            if (CurrentNumberOfContainers() + 1 <= MaxNumberOfContainers)
            {
                ListOfContainers.Add(container);
                container.carrier = this;
            }
            else
            {
                Console.WriteLine("Exceeds the max number of containers");
            }
        }
        else
        {
            throw new OverFillException("Exceeds the max weight of ship " + Id);
        }
    }

    public void addContainer(List<Container> containers)
    {
        double totalWeight = 0.0;
        foreach (Container c in containers)
        {
            totalWeight += c.TareWeight + c.MassKg;
        }

        if ( CurrentWeight() + totalWeight <= MaxWeight )
        {
            if (containers.Count + ListOfContainers.Count <= MaxNumberOfContainers)
            {
                ListOfContainers.AddRange(containers);
                foreach (Container c in containers)
                {
                    c.carrier = this;
                }
            }
            else
            {
                throw new NotEnoughSpaceException("Exceeds the max number of containers\n" +
                                                  "Current space: " + CurrentNumberOfContainers() + "/" +
                                                  MaxNumberOfContainers);
            }
        }
        else
        {
            throw new OverFillException("Exceeds the max weight of ship " + Id);
        }
        
    }

    public int CurrentNumberOfContainers()
    {
        return ListOfContainers.Count;
    }

    public double CurrentWeight()
    {
        double result = 0.0;
        foreach (Container c in ListOfContainers)
        {
            result += c.MassKg + c.TareWeight;
        }

        return result;
    }

    public void RemoveContainerBySerialNumber(string serialNumber)
    {
        for (int i = 0; i < ListOfContainers.Count; i++)
        {
            if (ListOfContainers[i].SerialNumber.Equals(serialNumber,StringComparison.OrdinalIgnoreCase))
            {
                GetContainerBySerialNumber(serialNumber).carrier = null;
                ListOfContainers.RemoveAt(i);
                break;
            }
        }

        throw new IdNotFoundException("ID "+ Id +" does not exist!");
    }

    public Container GetContainerBySerialNumber(string serialNumber)
    {
        for (int i = 0; i < ListOfContainers.Count; i++)
        {
            if (ListOfContainers[i].SerialNumber.Equals(serialNumber,StringComparison.OrdinalIgnoreCase))
            {
                return ListOfContainers[i];
            }
        }

        throw new IdNotFoundException("ID "+ Id +" does not exist!");
    }

    public override string ToString()
    {
        return "Ship " + Id +
               "(speed=" + MaxSpeed + ", maxContainerNum=" + MaxNumberOfContainers +
               ", maxWeight=" + MaxWeight + ")";
    }
    
}