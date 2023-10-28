using ClassTask;
using MementoMechanism;
using System.Net.Http.Headers;
using Serializer;
using SearchOut;

namespace Lab1
{
    class TaskManager
    {
        private Task_List TL;
        private Client CL;
        private TaskSaver TS;
        private SearchPrint SP;

        public TaskManager(Task_List tl, Client cl, TaskSaver ts, SearchPrint sp)
        {
            TL = tl;
            CL = cl;
            TS = ts;
            SP = sp;
        }
        /////////////////////////////////////
        public void CreateList()
        {
            TL.Create();
            CL.Save();
        }
        public void AddTasks()
        {
            TL.Add();
            CL.Save();
        }
        public void RemoveTasks()
        {
            TL.Remove();
            CL.Save();
        }
        public void EditTasks()
        {
            TL.Edit();
            CL.Save();
        }
        /////////////////////////////////////
        public void SearchTasks()
        {
            SP.SearchBy(TL);
        }
        public void PrintTasks()
        {
            SP.PrintOrdBy(TL);
            Console.ReadKey();
        }
        /////////////////////////////////////
        public void SaveTasks()
        {
            TS.Save(TL);
        }
        public void LoadTasks()
        {
            TS.Load(TL);
        }
        public void ChangeFormat()
        {
            TS.SetStrategy();
        }
        /////////////////////////////////////
        public void BackState()
        {
            CL.ReturnBack(out TL);
            Console.WriteLine("  Canceled!");
            Console.ReadKey();
        }
        public void ForwardState()
        {
            CL.ReturnForward(out TL);
            Console.WriteLine("  Returned!");
            Console.ReadKey();
        }
        /////////////////////////////////////
        public void Menu()
        {
            Console.WriteLine("            Task Manager    ");
            Console.WriteLine("____________________________");
            Console.WriteLine("     1.      Create new list");
            Console.WriteLine("     2.      Add tasks");
            Console.WriteLine("     3.      Remove a task");
            Console.WriteLine("     4.      Edit a task");
            Console.WriteLine("     5.      Search the tasks");
            Console.WriteLine("     6.      Save list");
            Console.WriteLine("     7.      Load list");
            Console.WriteLine("     8.      Change format");
            Console.WriteLine("   Enter.    Print all tasks");
            Console.WriteLine(" Left Arrow. Previous state");
            Console.WriteLine("Right Arrow. Forward state");
            Console.WriteLine("   Escape.   Close the program");
        }
        /////////////////////////////////////
        public void ClientFunction()
        {
            ConsoleKeyInfo key;
            bool flag = true;
            while (flag == true)
            {
                Console.Clear();
                Menu();
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        CreateList();
                        break;
                    case ConsoleKey.D2:
                        AddTasks();
                        break;
                    case ConsoleKey.D3:
                        RemoveTasks();
                        break;
                    case ConsoleKey.D4:
                        EditTasks();
                        break;
                    case ConsoleKey.D5:
                        SearchTasks();
                        break;
                    case ConsoleKey.D6:
                        SaveTasks();
                        break;
                    case ConsoleKey.D7:
                        LoadTasks();
                        break;
                    case ConsoleKey.D8:
                        ChangeFormat();
                        break;
                    case ConsoleKey.Enter:
                        PrintTasks();
                        break;
                    case ConsoleKey.LeftArrow:
                        BackState();
                        break;
                    case ConsoleKey.RightArrow:
                        ForwardState();
                        break;
                    case ConsoleKey.Escape:
                        flag = false;
                        break;
                }
            }
        }
    }


    class Program
    {
        public static void Main()
        {
            try
            {
                Task_List TL = new Task_List();
                Client CL = new Client(ref TL);
                TaskSaver TS = new TaskSaver();
                SearchPrint SP = new SearchPrint();

                TaskManager TASKS = new TaskManager(TL, CL, TS, SP);
                TASKS.ClientFunction();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}




