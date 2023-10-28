using ClassTask;

namespace SearchOut
{
    public class SearchPrint
    {
        private static SearchPrint instance;  
        public static SearchPrint getInstance()
        {
            if (instance == null)
                instance = new SearchPrint();
            return instance;
        }
        public void SearchBy(Task_List t) 
        {
            Console.WriteLine("Choose the criteria for searching: ");
            Console.WriteLine("1. Priority");
            Console.WriteLine("2. Date");
            Console.WriteLine("3. Tag");
            Console.WriteLine("4. Formulation");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 0 || choice > 4) 
            {
                Console.WriteLine("\nYou have entered wrong number!");
                Console.ReadKey();
                return;
            }
            if (choice == 1) 
            {
                bool consists = false;
                Console.WriteLine("  Input the priority: ");
                int prrt = Convert.ToInt32(Console.ReadLine());

                if (prrt < 1 || prrt >= t.List.Count)
                {
                    Console.WriteLine("\nYou have entered wrong priority!");
                    Console.ReadKey();
                    return;
                }
                else 
                {
                    foreach (Task_ tsk in t.List) 
                    {
                        if (tsk.Priority == prrt) 
                        {
                            tsk.Print();
                            consists = true;
                        }
                            
                    }
                }
                if (consists == false)
                    Console.WriteLine("Matches were not found :( ");
                Console.ReadKey();
            }
            else if (choice == 2) 
            {
                bool consists = false;
                Console.WriteLine("  Input the date: ");
                string dt = Console.ReadLine();

                foreach (Task_ tsk in t.List)
                {
                    if (tsk.Date.Contains(dt) == true) 
                    {
                        tsk.Print();
                        consists = true;
                    }
                        
                }
                if (consists == false)
                    Console.WriteLine("Matches were not found :( ");
                Console.ReadKey();
            }
            else if (choice == 3)
            {
                bool consists = false;
                Console.WriteLine("  Input the tag: ");
                string tg = Console.ReadLine();

                foreach (Task_ tsk in t.List)
                {
                    if (tsk.Tag.Contains(tg) == true)
                    {
                        tsk.Print();
                        consists = true;
                    }

                }
                if (consists == false)
                    Console.WriteLine("Matches were not found :( ");
                Console.ReadKey();
            }
            else if (choice == 4)
            {
                bool consists = false;
                Console.WriteLine("  Input the formulation: ");
                string frm = Console.ReadLine();

                foreach (Task_ tsk in t.List)
                {
                    if (tsk.Formulation.Contains(frm) == true)
                    {
                        tsk.Print();
                        consists = true;
                    }
                }
                if (consists == false)
                    Console.WriteLine("Matches were not found :( ");
                Console.ReadKey();
            }
        }
        public void PrintOrdBy(Task_List t) 
        {
            Console.WriteLine("\n\nHow do the tasks have to be ordered?");
            Console.WriteLine("1. Priority");
            Console.WriteLine("2. Date");
            Console.WriteLine("3. Tag");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 0 || choice > 3) 
            {
                Console.WriteLine("\nYou have entered wrong number!");
                Console.ReadKey();
                return;
            }
            if (choice == 1)
            {
                var tsks = (from ts in t.List
                            orderby ts.Priority ascending
                            select new
                            {
                                ts.Priority,
                                ts.Date,
                                ts.Tag,
                                ts.Formulation,
                            }).ToList();

                int n = 1;
                Console.WriteLine(" ==========To=Do=List=========");
                foreach (var v in tsks)
                {
                    Console.WriteLine(" | PRIORITY:    | [{0}]       [{1}]", v.Priority, n++);
                    Console.WriteLine(" | Date:        | {0}", v.Date);
                    Console.WriteLine(" | Tag:         | {0}", v.Tag);
                    Console.WriteLine(" | Formulation: | {0}", v.Formulation);
                    Console.WriteLine(" ===============o==============");
                };
            }
            else if (choice == 2)
            {
                for (int i = 0; i < t.List.Count; i++) 
                {
                    for (int j = t.List.Count - 1; j > i; j--) 
                    {
                        if (Convert.ToInt32(t.List[j - 1].Date.Substring(6, 4)) > Convert.ToInt32(t.List[j].Date.Substring(6)))
                        {
                            int p = t.List[j - 1].Priority;
                            t.List[j - 1].Priority = t.List[j].Priority;
                            t.List[j].Priority = p;

                            string s = t.List[j - 1].Date;
                            t.List[j - 1].Date = t.List[j].Date;
                            t.List[j].Date = s;

                            s = t.List[j - 1].Tag;
                            t.List[j - 1].Tag = t.List[j].Tag;
                            t.List[j].Tag = s;

                            s = t.List[j - 1].Formulation;
                            t.List[j - 1].Formulation = t.List[j].Formulation;
                            t.List[j].Formulation = s;
                        }
                        else if (Convert.ToInt32(t.List[j - 1].Date.Substring(3, 2)) > Convert.ToInt32(t.List[j].Date.Substring(3, 2)) 
                            && (Convert.ToInt32(t.List[j - 1].Date.Substring(6)) == Convert.ToInt32(t.List[j].Date.Substring(6))))
                        {
                            int p = t.List[j - 1].Priority;
                            t.List[j - 1].Priority = t.List[j].Priority;
                            t.List[j].Priority = p;

                            string s = t.List[j - 1].Date;
                            t.List[j - 1].Date = t.List[j].Date;
                            t.List[j].Date = s;

                            s = t.List[j - 1].Tag;
                            t.List[j - 1].Tag = t.List[j].Tag;
                            t.List[j].Tag = s;

                            s = t.List[j - 1].Formulation;
                            t.List[j - 1].Formulation = t.List[j].Formulation;
                            t.List[j].Formulation = s;
                        }
                        else if (Convert.ToInt32(t.List[j - 1].Date.Substring(0, 2)) > Convert.ToInt32(t.List[j].Date.Substring(0, 2)) 
                            && (Convert.ToInt32(t.List[j - 1].Date.Substring(6)) == Convert.ToInt32(t.List[j].Date.Substring(6))) 
                            && (Convert.ToInt32(t.List[j - 1].Date.Substring(3, 2)) == Convert.ToInt32(t.List[j].Date.Substring(3, 2))))
                        {
                            int p = t.List[j - 1].Priority;
                            t.List[j - 1].Priority = t.List[j].Priority;
                            t.List[j].Priority = p;

                            string s = t.List[j - 1].Date;
                            t.List[j - 1].Date = t.List[j].Date;
                            t.List[j].Date = s;

                            s = t.List[j - 1].Tag;
                            t.List[j - 1].Tag = t.List[j].Tag;
                            t.List[j].Tag = s;

                            s = t.List[j - 1].Formulation;
                            t.List[j - 1].Formulation = t.List[j].Formulation;
                            t.List[j].Formulation = s;
                        }
                    }
                }

                //for (int i = 0; i < t.List.Count; i++)
                //{
                //    for (int j = i; j < t.List.Count; j++)
                //    {
                //        if (Convert.ToInt32(t.List[i].Date.Substring(6)) > Convert.ToInt32(t.List[j].Date.Substring(6)))
                //        {
                //            string s = t.List[i].Date;
                //            t.List[i].Date = t.List[j].Date;
                //            t.List[j].Date = s;
                //        }
                //        else if (Convert.ToInt32(t.List[i].Date.Substring(3, 2)) > Convert.ToInt32(t.List[j].Date.Substring(3, 2)))
                //        {
                //            string s = t.List[i].Date;
                //            t.List[i].Date = t.List[j].Date;
                //            t.List[j].Date = s;
                //        }
                //        else if (Convert.ToInt32(t.List[i].Date.Substring(0, 2)) > Convert.ToInt32(t.List[j].Date.Substring(0, 2)))
                //        {
                //            int p = t.List[i].Priority;
                //            t.List[i].Priority = t.List[j].Priority;
                //            t.List[j].Priority = p;

                //            string s = t.List[i].Date;
                //            t.List[i].Date = t.List[j].Date;
                //            t.List[j].Date = s;

                //            s = t.List[i].Tag;
                //            t.List[i].Tag = t.List[j].Tag;
                //            t.List[j].Tag = s;

                //            s = t.List[i].Formulation;
                //            t.List[i].Formulation = t.List[j].Formulation;
                //            t.List[j].Formulation = s;
                //        }
                //    }
                //}
                int n = 1;
                Console.WriteLine(" ==========To=Do=List=========");
                foreach (Task_ v in t.List)
                {
                    Console.WriteLine(" | PRIORITY:    | [{0}]       [{1}]", v.Priority, n++);
                    Console.WriteLine(" | Date:        | {0}", v.Date);
                    Console.WriteLine(" | Tag:         | {0}", v.Tag);
                    Console.WriteLine(" | Formulation: | {0}", v.Formulation);
                    Console.WriteLine(" ===============o==============");
                };


            }
            else if (choice == 3) 
            {
                var tsks = (from ts in t.List
                            orderby ts.Tag ascending
                            select new
                            {
                                ts.Priority,
                                ts.Date,
                                ts.Tag,
                                ts.Formulation,
                            }).ToList();

                int n = 1;
                Console.WriteLine(" ==========To=Do=List=========");
                foreach (var v in tsks)
                {
                    Console.WriteLine(" | PRIORITY:    | [{0}]       [{1}]", v.Priority, n++);
                    Console.WriteLine(" | Date:        | {0}", v.Date);
                    Console.WriteLine(" | Tag:         | {0}", v.Tag);
                    Console.WriteLine(" | Formulation: | {0}", v.Formulation);
                    Console.WriteLine(" ===============o==============");
                };
            }
        }
    }
}