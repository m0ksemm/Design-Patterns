using System;
using System.Collections;
class Observer 
{
    public virtual void Update() { }
}

// ConcreteObserver
class ConcreteObserver : Observer
{
    int x;
    int y;
    EmodjiMove emodji;
    string name;
    public ConcreteObserver(EmodjiMove e, string n) 
    { 
        Random r = new Random();
        emodji = e;
        name = n;
        x = 10;
        y = 10;
    }
    public override void Update()
    {
        if (emodji.Move == 1)
        {
            x--;
        }
        if (emodji.Move == 2)
        {
            y++;
        }
        if (emodji.Move == 3)
        {
            x++;
        }
        if (emodji.Move == 4)
        {
            y--;
        }
        //Console.WriteLine("x - {0}  y - {1}",x,y);
    }
    public int X 
    {
        get { return x; }
        set { x = value; }
    }
    public int Y
    {
        get { return y; }
        set { y = value; }
    }
    public EmodjiMove GetEmodji() 
    {
        return emodji;
    }
    public void SetEmodji(EmodjiMove e) 
    {
        emodji = e;
    }
}

class Subject 
{
	ArrayList observers = new ArrayList();
    public void Attach(Observer observer) 
    {
        observers.Add(observer);
    }
    public bool IsAttached(Observer observer) 
    {
        if (observers.Contains(observer))
            return true;
        else return false;
    }
    public void Detach(Observer observer) 
    {
        int i = 0;
        foreach (Observer obj in observers) 
        {
            if (obj == observer)
                break;
            i++;
        }
        observers.RemoveAt(i);
    }
    public void Notify() 
    {
        foreach (Observer observer in observers) 
        {
            observer.Update();
        }
    }
};

// ConcreteSubject
class EmodjiMove : Subject
{
    int move;
    public EmodjiMove() { }

    public int Move 
    {
        get { return move; }    
        set { move = value; }   
    }
}

class Client
{
    int[,] Field = new int[40, 100];

    public EmodjiMove e;
    public ConcreteObserver o1;
    public ConcreteObserver o2;

    public Client() 
    {
        e = new EmodjiMove();
        o1 = new ConcreteObserver(e, "o1");
        o2 = new ConcreteObserver(e, "o2");

        o2.Y += 7;

        e.Attach(o1);
        e.Attach(o2);

        Field[o1.X, o1.Y] = 1;
        Field[o2.X, o2.Y] = 2;
    }

    public void SetXY(int x, int y, int value) 
    {
        if (x < 40)
        {
            if (y < 100)
            {
                Field[x, y] = value;
            }
        }
    }

    public void Show() 
    {
        for (int i = 0; i < 40; i++) 
        {
            for (int j = 0; j < 100; j++) 
            {
                if (Field[i, j] == 1)
                    Console.Write(char.ConvertFromUtf32(1));
                else if (Field[i, j] == 2)
                    Console.Write(char.ConvertFromUtf32(2));
                else Console.Write(" ");
            }
            Console.WriteLine("|");
        }
        for (int i = 0; i < 101; i++)
            Console.Write("-");
        }
    public void ClientFunc()
    {
        ConsoleKeyInfo key;
        while (true) 
        {
            SetXY(o1.X, o1.Y, 1);
            SetXY(o2.X, o2.Y, 2);
            Console.Clear();
            Show();
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow)
            {
                e.Move = 1;
                e.Notify();
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                e.Move = 2;
                e.Notify();
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                e.Move = 3;
                e.Notify();
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
                e.Move = 4;
                e.Notify();
            }
            else if (key.Key == ConsoleKey.L) 
            {
                if (e.IsAttached(o1) == true)
                    e.Detach(o1);
                else e.Attach(o1);
            }
            else if (key.Key == ConsoleKey.R)
            {
                if (e.IsAttached(o2) == true)
                    e.Detach(o2);
                else e.Attach(o2);
            }
            else if (key.Key == ConsoleKey.Escape)
                break; 
        }
    }
}


class MainClass 
{
    public static void Main() 
    {
        try 
        {
            Client c = new Client();
            c.ClientFunc();
        }
        catch (Exception ex)
        { 
            Console.WriteLine(ex.Message); 
        }  
    }
}