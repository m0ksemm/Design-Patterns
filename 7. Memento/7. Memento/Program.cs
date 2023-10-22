using System;
using System.Collections;
// Memento
class Memento 
{
    private string str;
    public Memento(string s) 
    { 
        str = s; 
    }
    public string Str 
    {
        get 
        {
            return str;
        }
        set 
        { 
            str = value; 
        }
    }
}

// Originator
class Line 
{
    private string str;
    public Line(string s) 
    {
        str = s;
    }
    public string Str
    {
        get
        {
            return str;
        }
        set
        {
            str = value;
        }
    }
    public Memento SaveMemento()
    {
        Memento memento = new Memento(str);
        return memento;
    }
    public void RestoreMemento(Memento memento) 
    {
        str = memento.Str;
    }
}

// Caretaker
class Caretaker 
{
    private ArrayList L;
    private int currpos;
    public Caretaker()
    {
        L = new ArrayList();
        currpos = -1;
    }
    public int GetCount()   
    { 
        return L.Count; 
    }
    public void Add(Memento m) 
    {
        if (currpos + 1 < L.Count)
        {
            for (int i = currpos + 1; i < L.Count; i++)
            {
                L.RemoveAt(i);
            }
        }
        L.Add(m);
        currpos++;
    }
    public void Delete()
    {
        L.RemoveAt(L.Count - 1);

    }
    public Memento this[int i]
    {
        get 
        {
            int j = 0;
            foreach (Memento obj in L)
            {
                if (j == i)
                    return obj;
                j++;
            }
            return null;
        }
    }
}

// Client Function
class Client 
{
    private Caretaker m;
    private Line l;
    private int pos = 0;
    public Client() 
    {
        m = new Caretaker();
        l = new Line("");
        m.Add(l.SaveMemento());
        pos = 0;
    }
    public void Save() 
    {
        if (pos != m.GetCount() - 1)
        {
            for (int i = pos ; i < m.GetCount(); i++)
            {
                m.Delete();
            }
           m.Delete();
        }
        m.Add(l.SaveMemento());
        pos++;
    }
    public void ReturnBack() 
    {
        if (m.GetCount() != 0 && pos != 0)
        {
            Console.Clear();
            l.RestoreMemento(m[--pos]);
            Console.WriteLine(l.Str);
            Console.WriteLine(pos);
        }
    }
    public void ReturnForward()
    {
        if (m.GetCount() != 0 && pos < m.GetCount() - 1)
        {
            Console.Clear();
            l.RestoreMemento(m[++pos]);
            Console.WriteLine(l.Str);
            Console.WriteLine(pos);
        }
    }
    public void AddAndPrint(char ch) 
    {
        Console.Clear();
        l.Str += ch;
        Console.WriteLine(l.Str);
        Console.WriteLine(pos);
    }
}


class Program
{
    public static void Main() 
    {
        try
        {
            Client client = new Client();

            ConsoleKeyInfo key;
            while (true)
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    client.Save();
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    client.ReturnBack();
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    client.ReturnForward();
                }
                else
                {
                    client.AddAndPrint(key.KeyChar);
                }
            }
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }
    }
}