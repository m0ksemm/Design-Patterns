// See https://aka.ms/new-console-template for more information
class Graphics_Card
{
    public bool Launch() //6 ON
    {
        int n = new Random().Next() % 101;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Graphics card is defective.");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Graphics card was launched.");
            return true;
        }
    }
    public bool Check_Monitor_Connection() //7 ON
    {
        int n = new Random().Next() % 101;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Monitor connection was NOT established.");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Monitor connection was established.");
            return true;
        }
    }
    public void RAM_data_output() //12 ON
    {
        Console.WriteLine("RAM data was displayed.");
    }
    public void Disk_Drive_Info_Output()  //16 ON
    {
        Console.WriteLine("Disk drive information was displayed.");
    }
    public void Vinchester_Info_Output() //20 ON
    {
        Console.WriteLine("Vinchester information was displayed.");
    }
    public void Farewell_Message() //4 OFF
    {
        Console.WriteLine("A farewell message was displayed on the monitor.");
    }
}
class RAM
{
    public bool Launch_Devices() //10 ON
    {
        int n = new Random().Next() % 102;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("RAM is defective.");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("RAM was launched.");
            return true;
        }
    }
    public void Memory_Analysis() //11 ON //3 OFF
    {
        Console.WriteLine("Memory was analysed.");
    }
    public bool Clear_Memory()//2 OFF
    {
        int n = new Random().Next() % 103;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Memory clearing error.");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Memory was cleared.");
            return true;
        }
    }
}
class Winchester
{
    public bool Launch() //18 ON
    {
        int n = new Random().Next() % 104;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Winchester is defective.");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Winchester was launched.");
            return true;
        }
    }
    public bool Boot_Sector_Check() //19 ON
    {
        int n = new Random().Next() % 105;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Boot sector error.");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Boot sector was checked.");
            return true;
        }
    }
    public void Device_Stop() //1 OFF
    {
        Console.WriteLine("Winchester was shut down.");
    }
}
class Optical_Disc_Reader
{
    public bool Launch() //14 ON
    {
        int n = new Random().Next() % 106;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Optical disc reader is defective.");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Optical disc reader was launched.");
            return true;
        }
    }
    public bool Disk_Availability() //15 ON
    {
        int n = new Random().Next() % 107;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Disk was NOT detected.");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Disk was detected.");
            return true;
        }
    }
    public void Initial_position() //5 OFF
    {
        Console.WriteLine("Disc reader: returned to initial position.");
    }
}
class Power_Supply
{
    public bool Apply_Power() //1 ON
    {
        int n = new Random().Next() % 10;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The power supply is defective!");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Power was applied!");
            return true;
        }
    }
    public bool Apply_Power_To_Graphics_Card() //5 ON
    {
        int n = new Random().Next() % 109;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Video card was NOT powered up!");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Video card was powered up!");
            return true;
        }
    }
    public bool Apply_Power_To_RAM() //9 ON
    {
        int n = new Random().Next() % 10;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("RAM was NOT powered up!");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("RAM was powered up!");
            return true;
        }
    }
    public bool Apply_Power_To_ODR() //13 ON
    {
        int n = new Random().Next() % 111;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Optical disc reader was NOT powered up!");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Optical disc reader was powered up!");
            return true;
        }
    }
    public bool Apply_Power_To_Winchester() //17 ON
    {
        int n = new Random().Next() % 112;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Winchester was NOT powered up!");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Winchester was powered up!");
            return true;
        }
    }
    public void Stop_Powering_Graphics_Card() //6 OFF
    {
        Console.WriteLine("Graphics card: power off!");
    }
    public void Stop_Powering_RAM() //7 OFF
    {
        Console.WriteLine("RAM: power off!");
    }
    public void Stop_Powering_ODR() //8 OFF
    {
        Console.WriteLine("Optical disc reader: power off!");
    }
    public void Stop_Powering_Winchester() //9 OFF
    {
        Console.WriteLine("Winchester: power off!");
    }
    public void Power_Off() //11 OFF
    {
        Console.WriteLine("Power supply: shutdown!");
    }
}
class Sensors
{

    public bool Check_Temperature_In_the_Power_Supply() //3 ON
    {
        int n = new Random().Next() % 10;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Power supply is overheated!");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Temperature in the power supply is normal!");
            return true;
        }
    }
    public bool Check_Temperature_In_the_Graphics_Card() //4 ON
    {
        int n = new Random().Next() % 114;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Graphics card is overheated!");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Temperature in the graphics card is normal!");
            return true;
        }
    }
    public bool Check_Temperature_In_RAM() //8 ON
    {
        int n = new Random().Next() % 10;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("RAM is overheated!");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Temperature in the RAM is normal!");
            return true;
        }
    }
    public bool Check_Temperature_Of_All_Systems() //21 ON
    {
        int n = new Random().Next() % 116;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("There are overheated systems!");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Temperature of all Systems is normal!");
            return true;
        }
    }
    public bool Check_Voltage() //2 ON //10 OFF
    {
        int n = new Random().Next() % 10;
        if (n == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Voltage is exceeded!");
            Console.BackgroundColor = ConsoleColor.Black;
            return false;
        }
        else
        {
            Console.WriteLine("Voltage is normal!");
            return true;
        }
    }
}

class PC 
{
    private Graphics_Card _Graphics_Card;
    private RAM _RAM;
    private Winchester _Winchester;
    private Optical_Disc_Reader _Optical_Disc_Reader;
    private Power_Supply _Power_Supply;
    private Sensors _Sensors;

    public PC(Graphics_Card GC, RAM RM, Winchester W, 
        Optical_Disc_Reader ODR, Power_Supply PS, Sensors S) 
    {
        _Graphics_Card = GC;
        _RAM = RM;
        _Winchester = W;
        _Optical_Disc_Reader = ODR;
        _Power_Supply = PS;
        _Sensors = S;
    }
    public void BeginWork() 
    {
        bool flag = true;
        while (flag == true) 
        {
            Console.Clear();
            Console.Beep();
            Thread.Sleep(300);
            Console.Write("1. ");
            if (_Power_Supply.Apply_Power() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("2. ");
            if (_Sensors.Check_Voltage() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("3. ");
            if (_Sensors.Check_Temperature_In_the_Power_Supply() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("4. ");
            if (_Sensors.Check_Temperature_In_the_Graphics_Card() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("5. ");
            if (_Power_Supply.Apply_Power_To_Graphics_Card() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("6. ");
            if (_Graphics_Card.Launch() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("7. ");
            if (_Graphics_Card.Check_Monitor_Connection() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("8. ");
            if (_Sensors.Check_Temperature_In_RAM() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("9. ");
            if (_Power_Supply.Apply_Power_To_Graphics_Card() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("10. ");
            if (_RAM.Launch_Devices() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("11. ");
            _RAM.Memory_Analysis();
            Thread.Sleep(200);
            Console.Write("12. ");
            _Graphics_Card.RAM_data_output();
            Thread.Sleep(200);
            Console.Write("13. ");
            if (_Power_Supply.Apply_Power_To_ODR() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("14. ");
            if (_Optical_Disc_Reader.Launch() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("15. ");
            if (_Optical_Disc_Reader.Disk_Availability() == false)
            {
                Console.Beep();
                Console.Beep();
                break;
            }
            Thread.Sleep(200);
            Console.Write("16. ");
            _Graphics_Card.Disk_Drive_Info_Output();
            Thread.Sleep(200);
            Console.Write("17. ");
            if (_Power_Supply.Apply_Power_To_Winchester() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("18. ");
            if (_Winchester.Launch() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            };
            Thread.Sleep(200);
            Console.Write("19. ");
            if (_Winchester.Boot_Sector_Check() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("20. ");
            _Graphics_Card.Vinchester_Info_Output();
            Thread.Sleep(200);
            Console.Write("21. ");
            if (_Sensors.Check_Temperature_Of_All_Systems() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }

            Console.Beep();
            flag = false;
        }
    }
    public void StopWork() 
    {
        bool flag = true;
        while (flag == true)
        {
            Console.Clear();
            Console.Beep();
            Thread.Sleep(300);
            Console.Write("1. ");
            _Winchester.Device_Stop();
            Thread.Sleep(200);
            Console.Write("2. ");
            if (_RAM.Clear_Memory() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("3. ");
            _RAM.Memory_Analysis();
            Thread.Sleep(200);
            Console.Write("4. ");
            _Graphics_Card.Farewell_Message();
            Thread.Sleep(200);
            Console.Write("5. ");
            _Optical_Disc_Reader.Initial_position();
            Thread.Sleep(200);
            Console.Write("6. ");
            _Power_Supply.Stop_Powering_Graphics_Card();
            Thread.Sleep(200);
            Console.Write("7. ");
            _Power_Supply.Stop_Powering_RAM();
            Thread.Sleep(200);
            Console.Write("8. ");
            _Power_Supply.Stop_Powering_ODR();
            Thread.Sleep(200);
            Console.Write("9. ");
            _Power_Supply.Stop_Powering_Winchester();
            Thread.Sleep(200);
            Console.Write("10. ");
            if (_Sensors.Check_Voltage() == false)
            {
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nPress any key to try again");
                Console.ReadKey();
                continue;
            }
            Thread.Sleep(200);
            Console.Write("11. ");
            _Power_Supply.Power_Off();


            flag = false;
        }
    }

}

class MainClass 
{
    public static void Main() 
    {
        Graphics_Card G = new Graphics_Card();
        RAM R = new RAM();
        Winchester W = new Winchester();
        Optical_Disc_Reader O = new Optical_Disc_Reader();
        Power_Supply P = new Power_Supply();
        Sensors S = new Sensors();

        PC pc = new PC(G, R, W, O, P, S);
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Press ENTER to turn ON the computer");
            Console.WriteLine("\n\n\t\t\tESC to exit");

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter) 
            {
                pc.BeginWork();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nComputer was turned ON");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Press ENTER to turn OFF the computer");

                while (true)
                {
                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Enter)
                    {
                        pc.StopWork();
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nComputer was turned OFF. " +
                            "\nPress any key to continue");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ReadKey();
                        break;
                    }
                }
                    //Console.Clear();

                
            }
            if (key.Key == ConsoleKey.Escape)
            {
                break;
            }    
        }
        
    }
     
}