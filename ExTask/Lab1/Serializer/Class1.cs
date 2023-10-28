using ClassTask;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace Serializer
{
    public interface ISerialize
    { 
        void Serialize(Task_List tl);
        void DeSerialize(Task_List tl);

    }
    public class TaskSaver 
    {
        private static TaskSaver instance;  // 
        public static TaskSaver getInstance()
        {
            if (instance == null)
                instance = new TaskSaver();
            return instance;
        }

        ISerialize strategy = new TXTSaver();

        public void Save(Task_List t) 
        {
            strategy.Serialize(t);
        }
        public void Load(Task_List t) 
        {
            strategy.DeSerialize(t);
        }

        public void SetStrategy() 
        {
            Console.WriteLine(" Choose the format: ");
            Console.WriteLine(" 1. TXT");
            Console.WriteLine(" 2. BINARY");
            Console.WriteLine(" 3. XML");
            Console.WriteLine(" 4. JSON");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 0 || choice > 4)
            {
                Console.WriteLine("\n !!! You have entered wrong number! !!!");
                Console.ReadKey();
                return;
            }
            switch (choice) 
            {
                case 1:
                    strategy = new TXTSaver();
                    Console.WriteLine(" TXT format was settled!");
                    Console.ReadKey();
                    break;
                case 2:
                    strategy = new BINARYSaver();
                    Console.WriteLine(" BINARY format was settled!");
                    Console.ReadKey();
                    break; 
                case 3:
                    strategy = new XMLSaver();
                    Console.WriteLine(" XML format was settled!");
                    Console.ReadKey();
                    break;
                case 4:
                    strategy = new JSONSaver();
                    Console.WriteLine(" JSON format was settled!");
                    Console.ReadKey();
                    break;
            }
        }
    }
    public class TXTSaver : ISerialize
    {
        public void Serialize(Task_List tl)
        {

            StreamWriter sw = new StreamWriter("tasksTXT.log", false, Encoding.Default);

            sw.WriteLine(Convert.ToString(tl.List.Count));
            foreach (Task_ obj in tl.List)
            {
                sw.WriteLine(obj.Priority);
                sw.WriteLine(obj.Date);
                sw.WriteLine(obj.Tag);
                sw.WriteLine(obj.Formulation);
            }
            sw.Close();
            Console.WriteLine("\n  Serialized TO tasksTXT.log." +
                "\n  Press any key to continue");
            Console.ReadKey();
        }
        public void DeSerialize(Task_List tl)
        {
            tl.List.Clear();
            StreamReader sr = new StreamReader("tasksTXT.log", Encoding.Default);
            int n = Convert.ToInt32(sr.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Task_ obj = new Task_();
                obj.Priority = Convert.ToInt32(sr.ReadLine());
                obj.Date = sr.ReadLine();
                obj.Tag = sr.ReadLine();
                obj.Formulation = sr.ReadLine();

                tl.List.Add(obj);
            }
            sr.Close();
            Console.WriteLine("\n  Deserialized FROM tasksTXT.log." +
                "\n  Press any key to continue");
            Console.ReadKey();
        }
    }

    public class BINARYSaver : ISerialize
    { 
        public void Serialize(Task_List tl)
        {
            FileStream stream = new FileStream("tasksBIN.txt", FileMode.Create); ;
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, tl.List);
            stream.Close();
            Console.WriteLine("\n  Serialized TO tasksBIN.log." +
                "\n  Press any key to continue");
            Console.ReadKey();
        }
        public void DeSerialize(Task_List tl)
        {
            tl.List.Clear();
            FileStream stream = new FileStream("tasksBIN.txt", FileMode.Open); ;
            BinaryFormatter formatter = new BinaryFormatter();
            tl.List = (List<Task_>)formatter.Deserialize(stream);
            stream.Close();
            Console.WriteLine("\n  Serialized from tasksBIN.log." +
                "\n  Press any key to continue");
            Console.ReadKey();
        }
    }

    public class XMLSaver : ISerialize
    {
        public void Serialize(Task_List tl)
        {
            List<Task_> L = new List<Task_>();
            foreach (Task_ s in tl.List)
                L.Add(s);

            FileStream stream = new FileStream("tasksXML.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Task_>));
            serializer.Serialize(stream, L);
            stream.Close();
            Console.WriteLine("\n  Serialized TO tasksXML.xml" +
                "\n  Press any key to continue");
            Console.ReadKey();
        }
        public void DeSerialize(Task_List tl)
        {
            tl.List.Clear();
            List<Task_> L = new List<Task_>();
            FileStream stream = new FileStream("tasksXML.xml", FileMode.Open); ;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Task_>));
            L = (List<Task_>)serializer.Deserialize(stream);
            stream.Close();

            foreach (Task_ t in L)
                tl.List.Add(t);
            Console.WriteLine("\n  Deserialized FROM tasksXML.xml." +
                "\n  Press any key to continue");
            Console.ReadKey();
        }
    }
    public class JSONSaver : ISerialize
    {
        public void Serialize(Task_List tl)
        {
            List<Task_> L = new List<Task_>();
            foreach (Task_ s in tl.List)
                L.Add(s);

            FileStream stream = new FileStream("tasksJSON.json", FileMode.Create);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Task_>));
            jsonFormatter.WriteObject(stream, L);
            stream.Close();
            Console.WriteLine("\n  Serialized TO tasksJSON.json" +
                "\n  Press any key to continue");
            Console.ReadKey();
        }
        public void DeSerialize(Task_List tl)
        {
            tl.List.Clear();
            List<Task_> L = new List<Task_>();

            FileStream stream = new FileStream("tasksJSON.json", FileMode.Open);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Task_>));
            L = (List<Task_>)jsonFormatter.ReadObject(stream);
            stream.Close();

            foreach (Task_ s in L)
                tl.List.Add(s);

            Console.WriteLine("\n  Deserialized FROM tasksJSON.json" +
                "\n  Press any key to continue");
            Console.ReadKey();
        }
    }
}



