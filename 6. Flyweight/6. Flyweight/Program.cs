abstract class CombatObject
{
    protected string picture;   // Картинкa для отображения
    protected int speed;        // Скорость перемещения
    protected int power;        // Коэффициент силы
    public abstract void Show(int longitude, int latitude);
                                // Принимает в качестве параметра позицию объекта.
}

class LightInfantry: CombatObject
{
    public LightInfantry()
    {
        picture = "Soldier's battalion";
        speed = 20;
        power = 10;
    }

    public override void Show(int longitude, int latitude)
    {
        Console.WriteLine("The soldiers' battalion has been placed; " +
            "\n\tcoordinates:\n\tlongitude: {0}\n\tlatitude:  {1} \n",
            latitude, longitude);
    }
}
class TransportVehicles: CombatObject
{
    public TransportVehicles()
    {
        picture = "Transport brigade";
        speed = 70;
        power = 0;
    }

    public override void Show(int longitude, int latitude)
    {
        Console.WriteLine("The military transport has been placed; " +
            "\n\tcoordinates:\n\tlongitude: {0}\n\tlatitude:  {1} \n",
            latitude, longitude);
    }
}

class HeavyCombatVehicle : CombatObject 
{
    public HeavyCombatVehicle()
    {
        picture = "Heavy combat vehicle";
        speed = 15;
        power = 150;
    }

    public override void Show(int longitude, int latitude)
    {
        Console.WriteLine("The heavy combat vehicle has been placed; " +
            "\n\tcoordinates:\n\tlongitude: {0}\n\tlatitude:  {1} \n",
            latitude, longitude);
    }
}

class LightCombatVehicle : CombatObject
{
    public LightCombatVehicle()
    {
        picture = "Light combat vehicle";
        speed = 50;
        power = 30;
    }

    public override void Show(int longitude, int latitude)
    {
        Console.WriteLine("The light combat vehicle has been placed; " +
            "\n\tcoordinates:\n\tlongitude: {0}\n\tlatitude:  {1} \n",
            latitude, longitude);
    }
}
class CombatAircraft : CombatObject
{
    public CombatAircraft()
    {
        picture = "Combat aircraft";
        speed = 300;
        power = 100;
    }

    public override void Show(int longitude, int latitude)
    {
        Console.WriteLine("The combat aircrafts have been placed; " +
            "\n\tcoordinates:\n\tlongitude: {0}\n\tlatitude:  {1} \n",
            latitude, longitude);
    }
}

class MilitaryBase

{
    Dictionary<string, CombatObject> CombatUnits = new Dictionary<string, CombatObject>();

    int[,] Field = new int[10, 10];

    public CombatObject GetCombatObject(string key)
    {
        if (CombatUnits.ContainsKey(key) == false)
        {
            if (key == "Soldier's battalion")
            {
                CombatUnits.Add(key, new LightInfantry());
                return CombatUnits[key];
            }
            else if (key == "Transport brigade")
            {
                CombatUnits.Add(key, new TransportVehicles());
                return CombatUnits[key];
            }
            else if (key == "Heavy combat vehicle") 
            {
                CombatUnits.Add(key, new HeavyCombatVehicle());
                return CombatUnits[key];
            }  
            else if (key == "Light combat vehicle") 
            {
                CombatUnits.Add(key, new LightCombatVehicle());
                return CombatUnits[key];
            } 
            else 
            {
                CombatUnits.Add(key, new CombatAircraft());
                return CombatUnits[key];
            }      
        }
        else
            return CombatUnits[key];
    }
    public void SetUnit(int longitude, int latitude, int Unit) 
    {
        Field[longitude, latitude] = Unit;
    }
    public int GetPosition(int longitude, int latitude) 
    {
        return Field[longitude, latitude];
    }
    public void ShowBaze() 
    {
        Console.WriteLine("\t\tMilitary Base");
        Console.WriteLine("     0   1   2   3   4   5   6   7   8   9");
        for (int i = 0; i < 10; i++) 
        {
            Console.WriteLine("   -----------------------------------------");
            Console.Write(" {0} |", i);
            for (int j = 0; j < 10; j++) 
            {
                switch (Field[i, j])
                {
                    case 0:
                        Console.Write("   |");
                        break;
                    case 1:
                        Console.Write(" S |");
                        break;
                    case 2:
                        Console.Write(" T |");
                        break;
                    case 3:
                        Console.Write(" H |");
                        break;
                    case 4:
                        Console.Write(" L |");
                        break;
                    case 5:
                        Console.Write(" A |");
                        break;

                }
                
            }
            Console.WriteLine();
        }
        Console.WriteLine("   -----------------------------------------\n");
        Console.WriteLine("S - Location of soldiers' battalions");
        Console.WriteLine("T - Location of military vehicles for soldairs");
        Console.WriteLine("H - Location of heavy military vehicles");
        Console.WriteLine("L - Location of light military vehicles");
        Console.WriteLine("A - Location of military aviation ");

    }
}



class Program
{
    static void Main()
    {   
        try 
        {
            MilitaryBase Base = new MilitaryBase();;

            while (true) 
            {
                Console.Clear();
                Console.WriteLine("\tMilitary Base\n");
                Console.WriteLine("Which unit do you want to add?");
                Console.WriteLine(" 1 - Soldiers' battalion");
                Console.WriteLine(" 2 - Military vehicles for soldairs");
                Console.WriteLine(" 3 - Heavy military vehicles");
                Console.WriteLine(" 4 - Light military vehicles");
                Console.WriteLine(" 5 - Military aviation\n");

                Console.WriteLine(" ENTER  - show the Military Base");
                Console.WriteLine(" ESCAPE - close the program");

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1) 
                {
                    Console.Clear();
                    Console.WriteLine("Enter the coordinates:");
                    Console.Write("longitude (0 - 9): ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("latitude (0 - 9):  ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    if (x > -1 && x < 10 && y > -1 && y < 10)
                    {
                        if (Base.GetPosition(x, y) == 0)
                        {
                            CombatObject CO = Base.GetCombatObject("Soldier's battalion");
                            CO.Show(x, y);
                            Base.SetUnit(x, y, 1);
                        }
                        else Console.WriteLine("The place with these coordinates is already busy");
                    }
                    else Console.WriteLine("Wrong coordinates");
                    
                    Console.WriteLine("\n\nPress any key to continue");
                    Console.ReadKey();
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the coordinates:");
                    Console.Write("longitude (0 - 9): ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("latitude (0 - 9):  ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    if (x > -1 && x < 10 && y > -1 && y < 10)
                    {
                        if (Base.GetPosition(x, y) == 0)
                        {
                            CombatObject CO = Base.GetCombatObject("Transport brigade");
                            CO.Show(x, y);
                            Base.SetUnit(x, y, 2);
                        }
                        else Console.WriteLine("The place with these coordinates is already busy");
                    }
                    else Console.WriteLine("Wrong coordinates");

                    Console.WriteLine("\n\nPress any key to continue");
                    Console.ReadKey();
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the coordinates:");
                    Console.Write("longitude (0 - 9): ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("latitude (0 - 9):  ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    if (x > -1 && x < 10 && y > -1 && y < 10)
                    {
                        if (Base.GetPosition(x, y) == 0)
                        {
                            CombatObject CO = Base.GetCombatObject("Heavy combat vehicle");
                            CO.Show(x, y);
                            Base.SetUnit(x, y, 3);
                        }
                        else Console.WriteLine("The place with these coordinates is already busy");
                    }
                    else Console.WriteLine("Wrong coordinates");

                    Console.WriteLine("\n\nPress any key to continue");
                    Console.ReadKey();
                }
                else if (key.Key == ConsoleKey.D4)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the coordinates:");
                    Console.Write("longitude (0 - 9): ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("latitude (0 - 9):  ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    if (x > -1 && x < 10 && y > -1 && y < 10)
                    {
                        if (Base.GetPosition(x, y) == 0)
                        {
                            CombatObject CO = Base.GetCombatObject("Light combat vehicle");
                            CO.Show(x, y);
                            Base.SetUnit(x, y, 4);
                        }
                        else Console.WriteLine("The place with these coordinates is already busy");
                    }
                    else Console.WriteLine("Wrong coordinates");

                    Console.WriteLine("\n\nPress any key to continue");
                    Console.ReadKey();
                }
                else if (key.Key == ConsoleKey.D5)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the coordinates:");
                    Console.Write("longitude (0 - 9): ");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("latitude (0 - 9):  ");
                    int y = Convert.ToInt32(Console.ReadLine());
                    if (x > -1 && x < 10 && y > -1 && y < 10)
                    {
                        if (Base.GetPosition(x, y) == 0)
                        {
                            CombatObject CO = Base.GetCombatObject("Combat aircraft");
                            CO.Show(x, y);
                            Base.SetUnit(x, y, 5);
                        }
                        else Console.WriteLine("The place with these coordinates is already busy");
                    }
                    else Console.WriteLine("Wrong coordinates");

                    Console.WriteLine("\n\nPress any key to continue");
                    Console.ReadKey();
                }
                else if (key.Key == ConsoleKey.Escape) 
                {
                    break;
                }
                else if(key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Base.ShowBaze();
                    Console.WriteLine("\n\nPress any key to continue");
                    Console.ReadKey();
                }

            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }

    }
}
