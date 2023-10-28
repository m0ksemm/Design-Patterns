using System.Collections;
using ClassTask;

namespace MementoMechanism
{
    public class Memento
    {
        private Task_List str;
        public Memento(Task_List s)
        {
            str = s.Copy();
        }
        public Task_List Str
        {
            get
            {
                return str.Copy();
            }
            set
            {
                str = value.Copy();
            }
        }
    }

    // Originator
    public class List_Originator
    {
        private Task_List str;
        public List_Originator(Task_List s)
        {
            str = s;
        }
        public Task_List Str
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
    public class Caretaker
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
    public class Client
    {
        private static Client instance;  // 
        public static Client getInstance()
        {
            if (instance == null)
                instance = new Client();
            return instance;
        }
        private Client()
        {
        }

        private Caretaker m;
        private List_Originator l;
        private int pos = 0;
        public Client(ref Task_List tsk)
        {
            m = new Caretaker();
            l = new List_Originator(tsk);
            m.Add(l.SaveMemento());
            pos = 0;
        }
        public void Save()
        {
            if (pos != m.GetCount() - 1)
            {
                for (int i = pos; i < m.GetCount(); i++)
                {
                    m.Delete();
                }
                m.Delete();
            }
            m.Add(l.SaveMemento());
            pos++;
        }
        public void ReturnBack(out Task_List tasks)
        {
            tasks = new Task_List();
            if (m.GetCount() != 0 && pos != 0)
            {
                l.RestoreMemento(m[--pos]);
                foreach (Task_ t in l.Str.List)
                {
                    tasks.List.Add(t);
                }
                Console.WriteLine("State: {0}",pos);
            }
        }
        public void ReturnForward(out Task_List tasks)
        {
            tasks = new Task_List();
            if (m.GetCount() != 0 && pos < m.GetCount() - 1)
            {
                l.RestoreMemento(m[++pos]);
                foreach (Task_ t in l.Str.List)
                {
                    tasks.List.Add(t);
                }
                Console.WriteLine(pos);
            }
        }
    }
}