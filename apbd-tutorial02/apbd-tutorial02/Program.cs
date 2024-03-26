using System.ComponentModel.Design;
using System.Data;
using System.Threading.Channels;
using apbd_tutorial02;

class Program
{
    private static List<Container> Containers { get; set; }
    private static List<Ship> Ships { get; set; }
    static void Main(string[] args)
    {
        Containers = new List<Container>();
        Ships = new List<Ship>();
        
        Menu();

    }

    private static void Menu()
    {
        while (true)
        {
            Console.WriteLine("List of container ships: ");
            Ships.ForEach(s => Console.WriteLine(s));
            
            Console.WriteLine("List of containers: ");
            Containers.ForEach(c => Console.WriteLine(c));
            Console.WriteLine("1- Create a container\n" +
                              "2- Load a cargo to a container\n" +
                              "3- Create a ship\n" +
                              "4- Load a container to a ship\n" +
                              "5- Load a list of containers to a ship\n" +
                              "6- Remove a container from a ship\n" +
                              "7- Unload a container\n" +
                              "8- Transfer containers between ships\n" +
                              "9- Replace container with another one\n" +
                              "10- Get information about a container\n" +
                              "11- Get information about a ship\n" +
                              "12- List of containers for a ship\n" +
                              "13- Increase the speed for a ship\n" +
                              "14- Decrease the speed for a ship\n" +
                              "anything else to quit.");

            Console.Write("-> ");
            string command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    CreateContainer();
                    break;
                case "2":
                    try
                    {
                        LoadCargoToContainer();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "3":
                    CreateShip();
                    break;
                case "4":
                    try
                    {
                        LoadContainerToShip();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    break;
                case "5":
                    try
                    {
                        LoadContainersToShip();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }

                    break;
                case "6":
                    try
                    {
                        RemoveContainerFromShip();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    break;
                case "7":
                    try
                    {
                        UnloadContainer();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }

                    break;
                case "8":
                    try
                    {
                        ReplaceContainerWith();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    
                    break;
                case "9":
                    
                    try
                    {
                        TransferContainerBetweenShips();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    
                    break;
                case "10":
                    Console.Write("Container serial number: ");
                    string serialNumber = Console.ReadLine();
                    try
                    {
                        Container tempContainer = GetContainerBySerialNumber(serialNumber);
                        Console.WriteLine(tempContainer);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    break;
                case "11":
                {
                    try
                    {
                        int id = GetValidIntInput("Ship ID: ");
                        Ship tempShip = Ships.FirstOrDefault(s => id == s.Id);
                        Console.WriteLine(tempShip);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    
                    break;
                }
                case "12":
                {
                    try
                    {
                        int id = GetValidIntInput("Ship ID: ");
                        Ship tempShip = Ships.FirstOrDefault(s => id == s.Id);

                        foreach (Container c in tempShip.ListOfContainers)
                        {
                            Console.WriteLine(c);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    
                    break;
                }
                case "13":
                {
                    try
                    {
                        int id = GetValidIntInput("Ship ID: ");
                        Ship tempShip = Ships.FirstOrDefault(s => id == s.Id);
                        double speed = GetValidDoubleInput("Speed to increaase: ");
                        if (speed + tempShip.CurrentSpeed <= tempShip.MaxSpeed)
                        {
                            Console.WriteLine("The speed is increased");
                        }
                        else
                        {
                            Console.WriteLine("ERROR! The Max limit is exceeded");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    
                    break;
                }
                case "14":
                {
                    try
                    {
                        int id = GetValidIntInput("Ship ID: ");
                        Ship tempShip = Ships.FirstOrDefault(s => id == s.Id);
                        double speed = GetValidDoubleInput("Speed to decrease: ");
                        if (speed - tempShip.CurrentSpeed > 0)
                        {
                            Console.WriteLine("The speed is decreased");
                        }
                        else
                        {
                            Console.WriteLine("ERROR! The speed cant be negative");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                    }
                    break;
                }
                default:
                    return;
            }
        }
    }

    private static void CreateContainer()
    {
        Console.WriteLine("Please provide a container type\n" +
                          "1- Liquid container\n" +
                          "2- Gas container\n" +
                          "3- Refrigerated container");
        Console.Write("-> ");
        string containerType = Console.ReadLine();

        switch (containerType)
        {
            case "1":
            {
                HandleLiquidContainer();
                break;
            }
            case "2":
            {
                HandleGasContainer();
                break;
            }
            case "3":
            {
                HandleRefrigeratedContainer();
                break;
            }
            default:
                Console.WriteLine("Invalid input! Please try again.");
                break;
        }
    }

    private static double GetValidDoubleInput(string input)
    {
        double value;
        while (true)
        {
            Console.Write(input);
            if (double.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
    
    private static int GetValidIntInput(string input)
    {
        int value;
        while (true)
        {
            Console.Write(input);
            if (int.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    private static Container GetContainerBySerialNumber(string serialNumber)
    {
        foreach (Container c in Containers)
        {
            if (serialNumber.Equals(c.SerialNumber,StringComparison.OrdinalIgnoreCase))
                return c;
        }

        throw new IdNotFoundException("There is no container with " + serialNumber);
    }

    private static void LoadCargoToContainer()
    {
        Console.WriteLine("Please choose a container by a serial number to load.");
        foreach (Container c in Containers)
        {
            Console.WriteLine(c);    
        }
        
        Console.Write("Serial number: ");
        string serialNumber = Console.ReadLine();
        Container temp = GetContainerBySerialNumber(serialNumber);

        switch (temp.ContainerType)
        {
            case "L":
            {
                HandleLiquidCargo(temp);
                break;
            }
            case "G":
            {
                HandleGasCargo(temp);
                break;
            }
            case "C":
            {
                HandleProductCargo(temp);
                break;
            }
        }
    }

    private static void HandleLiquidCargo(Container container)
    {
        bool isHazardous = false;
        Console.WriteLine("Is this cargo hazardous?\n" +
                          "1- yes\n" +
                          "2- no");
        Console.Write("-> ");
        string command = Console.ReadLine();

        if (command.Equals("1"))
        {
            isHazardous = true;
        }
        else if (command.Equals("2"))
        {
            isHazardous = false;
        }
        else
        {
            Console.WriteLine("Invalid input! Assuming cargo is not hazardous.");
        }

        Console.Write("Cargo name: ");
        string cargoName = Console.ReadLine();
        double weight = GetValidDoubleInput("Cargo weight: ");
        Cargo temp_cargo = new Cargo(cargoName, weight);
        temp_cargo.IsHazardous = isHazardous;
        container.LoadCargo(temp_cargo);
        Console.WriteLine(temp_cargo + " is loaded to " + container);
    }

    private static void HandleGasCargo(Container container)
    {
        Console.Write("Cargo name: ");
        string cargoName = Console.ReadLine();
        double weight = GetValidDoubleInput("Cargo weight: ");
        double pressure = GetValidDoubleInput("Pressure: ");
        GasCargo temp_cargo = new GasCargo(cargoName, weight, pressure);
        container.LoadCargo(temp_cargo);
        Console.WriteLine(temp_cargo + " is loaded to " + container);
    }

    private static void HandleProductCargo(Container container)
    {
        Console.Write("Cargo name: ");
        string cargoName = Console.ReadLine();
        double weight = GetValidDoubleInput("Cargo weight: ");
        double requiredTemp = GetValidDoubleInput("Required temperature: ");
        Product temp_cargo = new Product(cargoName, weight, requiredTemp);
        container.LoadCargo(temp_cargo);
        Console.WriteLine(temp_cargo + " is loaded to " + container);
    }

    private static void HandleLiquidContainer()
    {
        double height = GetValidDoubleInput("Height: ");
        double tareWeight = GetValidDoubleInput("Weight: ");
        double depth = GetValidDoubleInput("Depth: ");
        double maxKg = GetValidDoubleInput("Max Kg: ");
        LiquidContainer lc = new LiquidContainer(height, tareWeight, depth, maxKg);
        Containers.Add(lc);
    }
    private static void HandleGasContainer()
    {
        double height = GetValidDoubleInput("Height: ");
        double tareWeight = GetValidDoubleInput("Weight: ");
        double depth = GetValidDoubleInput("Depth: ");
        double maxKg = GetValidDoubleInput("Max Kg: ");
        GasContainer gc = new GasContainer(height, tareWeight, depth, maxKg);
        Containers.Add(gc);
    }
    
    private static void HandleRefrigeratedContainer()
    {
        double height = GetValidDoubleInput("Height: ");
        double tareWeight = GetValidDoubleInput("Weight: ");
        double depth = GetValidDoubleInput("Depth: ");
        double maxKg = GetValidDoubleInput("Max Kg: ");
        Console.Write("Type of product: ");
        string typeOfProduct = Console.ReadLine();
        double temperature = GetValidDoubleInput("Temperature: ");
        RefrigeratedContainer rc = new RefrigeratedContainer(height, tareWeight, depth, maxKg,typeOfProduct,temperature);
        Containers.Add(rc);
    }

    private static void CreateShip()
    {
        double speed = GetValidDoubleInput("Max speed: ");
        int maxContainers = GetValidIntInput("Max number of containers: ");
        double maxWeight = GetValidDoubleInput("Max weight: ");
        Ships.Add(new Ship(speed,maxContainers,maxWeight));
    }

    private static Ship FindShipById(int id)
    {
        for (int i = 0; i < Ships.Count; i++)
        {
            if (Ships[i].Id == id)
            {
                return Ships[i];
            }
        }

        throw new IdNotFoundException("ID " + id + " does not exist.");
    }

    private static void LoadContainerToShip()
    {
        int shipId = GetValidIntInput("Ship ID: ");
        Ship tempShip = FindShipById(shipId);

        Console.Write("Serial number of the container: ");
        string serialNumber = Console.ReadLine();
        Container tempContainer = GetContainerBySerialNumber(serialNumber);
        
        tempShip.addContainer(tempContainer);
    }
    private static void LoadContainersToShip()
    {
        int shipId = GetValidIntInput("Ship ID: ");
        Ship tempShip = FindShipById(shipId);
        
        
        Console.Write("Please provide serial numbers of the 1 (press enter to stop): ");
        List<Container> tempList = new List<Container>();
        while (true)
        {
            Console.Write("-> ");
            string serialNumber = Console.ReadLine();
            if (string.IsNullOrEmpty(serialNumber))
            {
                break;
            }
            Container tempCont = GetContainerBySerialNumber(serialNumber);
            tempList.Add(tempCont);
        }
        tempShip.addContainer(tempList);
    }

    private static void RemoveContainerFromShip()
    {
        int id = GetValidIntInput("Ship ID: ");
        Ship temp = Ships.FirstOrDefault(s => s.Id == id);
        Console.Write("Container serial number: ");
        string serialNumber = Console.ReadLine();
        temp.RemoveContainerBySerialNumber(serialNumber);
    }

    private static void UnloadContainer()
    {
        Console.Write("Serial number of the container: ");
        string serialNumber = Console.ReadLine();
        Container tempContainer = GetContainerBySerialNumber(serialNumber);
        tempContainer.EmptyTheCargo();
        tempContainer.carrier.GetContainerBySerialNumber(serialNumber).EmptyTheCargo();
    }

    private static void ReplaceContainerWith()
    {
        int id = GetValidIntInput("Ship ID: ");
        Ship temp = Ships.FirstOrDefault(s => s.Id == id);
        Console.Write("Container serial number which you want to replace: ");
        string serialNumber = Console.ReadLine();
        Container container = GetContainerBySerialNumber(serialNumber);
        temp.RemoveContainerBySerialNumber(serialNumber);
        
        Console.Write("Container serial number which you want to add: ");
        string serialNumber2 = Console.ReadLine();
        Container container2 = GetContainerBySerialNumber(serialNumber2);
        temp.addContainer(container2);
        
    }

    private static void TransferContainerBetweenShips()
    {
        int id1 = GetValidIntInput("Ship ID: ");
        Ship ship1 = Ships.FirstOrDefault(s => s.Id == id1);
        Console.Write("Container serial ID: ");
        string serialNumber1 = Console.ReadLine();
        Container container1 = GetContainerBySerialNumber(serialNumber1);
        
        int id2 = GetValidIntInput("Ship ID: ");
        Ship ship2 = Ships.FirstOrDefault(s => s.Id == id2);
        Console.Write("Container serial ID: ");
        string serialNumber2 = Console.ReadLine();
        Container container2 = GetContainerBySerialNumber(serialNumber2);
        
        ship1.addContainer(container2);
        ship2.addContainer(container1);
        ship1.RemoveContainerBySerialNumber(serialNumber1);
        ship2.RemoveContainerBySerialNumber(serialNumber2);

    }
}