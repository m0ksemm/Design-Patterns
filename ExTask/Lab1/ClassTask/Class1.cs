using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace ClassTask
{
    [Serializable]
    [DataContract]
    public class Task_
    {
        [DataMember]
        public int Priority { get; set; }
        [DataMember]
        public string Formulation { get; set; }
        [DataMember]
        public string Date { get; set; }
        [DataMember]
        public string Tag { get; set; }
        
        public Task_()
        {
            Priority = 0;
            Formulation = "This is a task";
            Date = "22.11.2003";
            Tag = "Studying";
        }
        public Task_(int t, string d, string tg, string f)
        {
            Priority = t;
            Date = d;
            Tag = tg;
            Formulation = f;
        }
        public void Print()
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("| Priority:    | {0}", Priority);
            Console.WriteLine("| Date:        | {0}", Date);
            Console.WriteLine("| Tag:         | {0}", Tag);
            Console.WriteLine("| Formulation: | {0}", Formulation);  
        }
    }

    [Serializable]
    [DataContract]
    public class Task_List
    {
        [DataMember]
        public List<Task_> List;
        public Task_List()
        {

            List = new List<Task_>();
        }
        public Task_List Copy()
        {
            Task_List copy = new Task_List();
            foreach (Task_ t in List)
            {
                Task_ p = new Task_(t.Priority, t.Formulation, t.Tag, t.Date);
                copy.List.Add(p);
            }
            return copy;
        }
        public void Show()
        {
            foreach (Task_ t in List)
            {
                t.Print();
            }
        }
        public void Create() 
        {
            if (List.Count != 0) 
            {
                

                while (true) 
                {
                    Console.Clear();
                    Console.WriteLine(" \nAre you sure that you want to create a new Task List?");
                    Console.WriteLine(" Make sure you have saved the old one. ");
                    Console.WriteLine(" 1 - Thank you, i have forgotten to save. ");
                    Console.WriteLine(" 2 - I have already saved. ");

                    ConsoleKeyInfo cnt = Console.ReadKey(true);
                    if (cnt.Key == ConsoleKey.D1)
                        return;
                    else if (cnt.Key == ConsoleKey.D2)
                        break;
                }
            }
            Console.WriteLine("  ---CREATION OF NEW TASK LIST---");
            Add();
        } 
        public void Add() 
        {
            Console.WriteLine("  How many tasks do you want to add?");
            int count = Convert.ToInt32(Console.ReadLine());

            if (count < 0) 
            { 
                Console.WriteLine("  You can not add negative number of tasks.\n");
                return; 
            }
            else 
            {
                for (int i = 0; i < count; i++) 
                {
                    Console.WriteLine("  =======================");
                    Console.WriteLine("  Task {0}: ",i + 1);
                    Console.WriteLine("  * Input the priority of this task: ");
                    int prty = Convert.ToInt32(Console.ReadLine());

                    string dat = "";
                    string pattern = @"^((0[1-9]|[12][0-9])|(3[01])|0[1-9])(:|\.)([1][012]|[0][1-9]|0[1-9])((:|\.)\d{1,})?$";
                    Regex regex = new Regex(pattern);
                    while (true) 
                    {
                        Console.WriteLine("  * Input the date of this task: ");
                        dat = Console.ReadLine();
                        if (regex.IsMatch(dat))
                            break;
                        else
                        { 
                            Console.WriteLine(  "!!! Date is INcorrect! Try again. !!!");
                            continue;
                        }
                    }

                    Console.WriteLine("  * Input the tag of this task: ");
                    string tg = Console.ReadLine();
                    Console.WriteLine("  * Write the formulation: ");
                    string frml = Console.ReadLine();

                    Task_ task = new Task_(prty, dat, tg, frml);
                    List.Add(task);
                }
                Console.WriteLine("\n\n  {0} tasks were added! ", count);
                Console.ReadKey();
            }
        }
        public void Remove() 
        {
            Console.WriteLine("\n  Here is the list:\n");

            int n = 1;
            foreach (Task_ v in List)
            {
                Console.WriteLine("   | PRIORITY:    | [{0}]       №[{1}]", v.Priority, n++);
                Console.WriteLine("   | Date:        | {0}", v.Date);
                Console.WriteLine("   | Tag:         | {0}", v.Tag);
                Console.WriteLine("   | Formulation: | {0}", v.Formulation);
                Console.WriteLine("   ===============o==============");
            };

            Console.WriteLine(" Input the number of the task that you want to remove:");
            int i = Convert.ToInt32(Console.ReadLine());

            if (i - 1 < 0 || i - 1 > List.Count) 
            {
                Console.WriteLine(" !!! You have entered wrong priority! !!!");
            }
            else 
            {
                Console.WriteLine("\n\n  This task was removed: ");
                List[i - 1].Print();
                List.RemoveAt(i - 1);
                Console.ReadKey();
            }
        }
        public void Edit() 
        {
            Console.WriteLine("\n  Here is the list:\n");

            int n = 1;
            foreach (Task_ v in List)
            {
                Console.WriteLine("   | PRIORITY:    | [{0}]       №[{1}]", v.Priority, n++);
                Console.WriteLine("   | Date:        | {0}", v.Date);
                Console.WriteLine("   | Tag:         | {0}", v.Tag);
                Console.WriteLine("   | Formulation: | {0}", v.Formulation);
                Console.WriteLine("   ===============o==============");
            };
            Console.WriteLine(" Input the number of the task that you want to edit:");
            int i = Convert.ToInt32(Console.ReadLine());

            if (i - 1 < 0 || i - 1 > List.Count)
            {
                Console.WriteLine(" You have entered wrong priority!");
            }
            else
            {
                Console.WriteLine(" Enter new data:");

                Console.WriteLine("  * Input the priority of this task: ");
                int prty = Convert.ToInt32(Console.ReadLine());

                string dat = "";
                string pattern = @"^((0[1-9]|[12][0-9])|(3[01])|0[1-9])(:|\.)([1][012]|[0][1-9]|0[1-9])((:|\.)\d{1,})?$";
                Regex regex = new Regex(pattern);
                while (true)
                {
                    Console.WriteLine("  * Input the date of this task: ");
                    dat = Console.ReadLine();
                    if (regex.IsMatch(dat))
                        break;
                    else
                    {
                        Console.WriteLine(" !!! Date is INcorrect! Try again. !!!");
                        continue;
                    }
                }

                Console.WriteLine("  * Input the tag of this task: ");
                string tg = Console.ReadLine();
                Console.WriteLine("  * Write the formulation: ");
                string frml = Console.ReadLine();

                List[i - 1].Priority = prty;
                List[i - 1].Date = dat;
                List[i - 1].Tag = tg;
                List[i - 1].Formulation = frml;
                
                Console.WriteLine("\n\n  Task was edited. ");
                Console.ReadKey();
            }
        }
    }
}