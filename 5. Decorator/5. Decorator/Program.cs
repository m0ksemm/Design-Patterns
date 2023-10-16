
interface iCharacter
{
    protected int Attack { get; set; }
    protected int Speed { get; set; }
    protected int Health { get; set; }
    protected int Protection { get; set; }
    protected string Name { get; set; }
    protected string Info { get; set; }
}

class Human : iCharacter 
{
    public string Info { get; set; }
    public int Attack { get; set; }
    public int Speed { get; set; }
    public int Health { get; set; }
    public int Protection { get; set; }
    public string Name { get; set; }
    public Human() 
    {
        Attack = 20;
        Speed = 20;  
        Health = 150; 
        Protection = 0;
        Name = "Human";
        Info = "";
    }
    public virtual void Show()
    {
        Console.WriteLine("=Human==Level_0==========");
        Console.WriteLine("{0}", Name);
        Console.WriteLine("Attack:     | {0}", Attack);
        Console.WriteLine("Speed:      | {0}", Speed);
        Console.WriteLine("Health:     | {0}", Health);
        Console.WriteLine("Protection: | {0}", Protection);
        Console.WriteLine(Info);
    }    
}

class Human_Decorator : Human
{
    protected Human h;

    public Human_Decorator(Human m)  : base()
    {
        h = m;
    }
}

class Human_Warrior : Human_Decorator 
{
    public Human_Warrior(Human pers) : base(pers)
    {
        Attack = pers.Attack + 20;
        Speed = pers.Speed + 10;
        Health = pers.Health + 50;
        Protection = pers.Protection + 20;
        Name = pers.Name + " warrior";
        Info = pers.Info + "Some additional info about this character:" +
                    "\n(1) Possesses all the qualities inherent in a " +
                    "\n    warrior: strength, courage, confidence.";
    }
    public override void Show()
    {
        Console.WriteLine("=Human==Level_1==========");
        Console.WriteLine("{0}", Name);
        Console.WriteLine("Attack:     | {0}", Attack);
        Console.WriteLine("Speed:      | {0}", Speed);
        Console.WriteLine("Health:     | {0}", Health);
        Console.WriteLine("Protection: | {0}", Protection);
        Console.WriteLine(Info);
    }
}

class Swordsman : Human_Warrior
{
    public Swordsman(Human pers) : base(pers)
    {
        Attack = pers.Attack + 40;
        Speed = pers.Speed - 10;
        Health = pers.Health + 50;
        Protection = pers.Protection + 40;
        Name = pers.Name + ", swordsman";
        Info = pers.Info + "\n(2) Possesses the art of swordsmanship.";
    }
    public override void Show()
    {
        Console.WriteLine("=Human==Level_2======S===");
        Console.WriteLine("{0}", Name);
        Console.WriteLine("Attack:     | {0}", Attack);
        Console.WriteLine("Speed:      | {0}", Speed);
        Console.WriteLine("Health:     | {0}", Health);
        Console.WriteLine("Protection: | {0}", Protection);
        Console.WriteLine(Info);
    }
}

class Archer : Human_Warrior
{
    public Archer(Human pers) : base(pers)
    {
        Attack = pers.Attack + 20;
        Speed = pers.Speed + 20;
        Health = pers.Health + 50;
        Protection = pers.Protection + 10;
        Name = pers.Name + ", archer";
        Info = pers.Info + "\n(2) Capable of archery, to fight at a distance.";
    }
    public override void Show()
    {
        Console.WriteLine("=Human==Level_2====A=====");
        Console.WriteLine("{0}", Name);
        Console.WriteLine("Attack:     | {0}", Attack);
        Console.WriteLine("Speed:      | {0}", Speed);
        Console.WriteLine("Health:     | {0}", Health);
        Console.WriteLine("Protection: | {0}", Protection);
        Console.WriteLine(Info);
    }
}

class Horseman : Swordsman
{
    public Horseman(Human pers) : base(pers)
    {
        Attack = pers.Attack - 10;
        Speed = pers.Speed + 40;
        Health = pers.Health + 200;
        Protection = pers.Protection + 100;
        Name = pers.Name + ", horseman";
        Info = pers.Info + "\n(3) Able to ride a horse and fight on horseback.";
    }
    public override void Show()
    {
        Console.WriteLine("=Human==Level_3==========");
        Console.WriteLine("{0}", Name);
        Console.WriteLine("Attack:     | {0}", Attack);
        Console.WriteLine("Speed:      | {0}", Speed);
        Console.WriteLine("Health:     | {0}", Health);
        Console.WriteLine("Protection: | {0}", Protection);
        Console.WriteLine(Info);
    }
}

class Elf : iCharacter
{
    public string Info { get; set; }
    public int Attack { get; set; }
    public int Speed { get; set; }
    public int Health { get; set; }
    public int Protection { get; set; }
    public string Name { get; set; }
    public Elf()
    {
        Attack = 15;
        Speed = 30;
        Health = 100;
        Protection = 0;
        Name = "Elf";
        Info = "";
    }
    public virtual void Show()
    {
        Console.WriteLine("==Elf===Level_0==========");
        Console.WriteLine("{0}", Name);
        Console.WriteLine("Attack:     | {0}", Attack);
        Console.WriteLine("Speed:      | {0}", Speed);
        Console.WriteLine("Health:     | {0}", Health);
        Console.WriteLine("Protection: | {0}", Protection);
        Console.WriteLine(Info);
    }
}

class Elf_Decorator : Elf
{
    protected Elf el;

    public Elf_Decorator(Elf e) : base()
    {
        el = e;
    }
}

class Elf_Warrior : Elf_Decorator
{
    public Elf_Warrior(Elf elf) : base(elf)
    {
        Attack = elf.Attack + 20;
        Speed = elf.Speed - 10;
        Health = elf.Health + 100;
        Protection = elf.Protection + 20;
        Name = elf.Name + " warrior";
        Info = elf.Info + "Some additional info about this character:" +
                    "\n(1) A strong elf, always ready to fight with enemies";
    }
    public override void Show()
    {
        Console.WriteLine("==Elf===Level_1==========");
        Console.WriteLine("{0}", Name);
        Console.WriteLine("Attack:     | {0}", Attack);
        Console.WriteLine("Speed:      | {0}", Speed);
        Console.WriteLine("Health:     | {0}", Health);
        Console.WriteLine("Protection: | {0}", Protection);
        Console.WriteLine(Info);
    }
}

class Wizard : Elf_Decorator
{
    public Wizard(Elf elf) : base(elf)
    {
        Attack = elf.Attack + 10;
        Speed = elf.Speed + 10;
        Health = elf.Health - 50;
        Protection = elf.Protection + 10;
        Name = elf.Name + ", wizard";
        Info = elf.Info + "Some additional info about this character:" +
                    "\n(1) Possesses normal combat magic";
    }
    public override void Show()
    {
        Console.WriteLine("==Elf===Level_1==========");
        Console.WriteLine("{0}", Name);
        Console.WriteLine("Attack:     | {0}", Attack);
        Console.WriteLine("Speed:      | {0}", Speed);
        Console.WriteLine("Health:     | {0}", Health);
        Console.WriteLine("Protection: | {0}", Protection);
        Console.WriteLine(Info);
    }
}

class Crossbowman : Elf_Warrior
{
    public Crossbowman(Elf elf) : base(elf)
    {
        Attack = elf.Attack + 20;
        Speed = elf.Speed + 10;
        Health = elf.Health + 50;
        Protection = elf.Protection - 10;
        Name = elf.Name + ", crossbowman";
        Info = elf.Info + "\n(2) Able to use a crossbow during the fight";
    }
    public override void Show()
    {
        Console.WriteLine("==Elf===Level_2==========");
        Console.WriteLine("{0}", Name);
        Console.WriteLine("Attack:     | {0}", Attack);
        Console.WriteLine("Speed:      | {0}", Speed);
        Console.WriteLine("Health:     | {0}", Health);
        Console.WriteLine("Protection: | {0}", Protection);
        Console.WriteLine(Info);
    }
}

class Evil_Wizard : Wizard
{
    public Evil_Wizard(Elf elf) : base(elf)
    {
        Attack = elf.Attack + 70;
        Speed = elf.Speed + 20;
        Health = elf.Health;
        Protection = elf.Protection;
        Name = elf.Name + ", evil wizard";
        Info = elf.Info + "\n(2) Uses dark magik for fight";
    }
    public override void Show()
    {
        Console.WriteLine("==Elf===Level_2==========");
        Console.WriteLine("{0}", Name);
        Console.WriteLine("Attack:     | {0}", Attack);
        Console.WriteLine("Speed:      | {0}", Speed);
        Console.WriteLine("Health:     | {0}", Health);
        Console.WriteLine("Protection: | {0}", Protection);
        Console.WriteLine(Info);
    }
}

class Kind_Wizard : Wizard
{
    public Kind_Wizard(Elf elf) : base(elf)
    {
        Attack = elf.Attack + 50;
        Speed = elf.Speed + 30;
        Health = elf.Health + 100;
        Protection = elf.Protection + 30;
        Name = elf.Name + ", kind wizard";
        Info = elf.Info + "\n(2) Uses white magik. Does not start fight first.";
    }
    public override void Show()
    {
        Console.WriteLine("==Elf===Level_2==========");
        Console.WriteLine("{0}", Name);
        Console.WriteLine("Attack:     | {0}", Attack);
        Console.WriteLine("Speed:      | {0}", Speed);
        Console.WriteLine("Health:     | {0}", Health);
        Console.WriteLine("Protection: | {0}", Protection);
        Console.WriteLine(Info);
    }
}

class Client
{
    public static void Client_human(Human h) 
    {
        h.Show();
        Console.WriteLine();
    }
    public static void Client_elves(Elf e)
    {
        e.Show();
        Console.WriteLine();
    }
    public static void Main()
    {
        try
        {
            Console.WriteLine("\n\n===========================================");
            Console.WriteLine("====================People=================");
            Console.WriteLine("===========================================\n\n");
            Human h1 = new Human();
            Client_human(h1);

            Console.WriteLine();

            h1 = new Human_Warrior(h1);
            Client_human(h1);
            h1 = new Swordsman(h1);
            Client_human(h1);
            h1 = new Horseman(h1);
            Client_human(h1);

            Console.WriteLine("===========================================");

            Human h2 = new Human();
            h2 = new Human_Warrior(h2);
            h2 = new Archer(h2);
            Client_human(h2);


            Console.WriteLine("\n\n===========================================");
            Console.WriteLine("====================Elves==================");
            Console.WriteLine("===========================================\n\n");

            Elf e1 = new Elf();
            Client_elves(e1);

            e1 = new Elf_Warrior(e1);
            Client_elves(e1);

            e1 = new Crossbowman(e1);
            Client_elves(e1);

            Console.WriteLine("===========================================");

            Elf e2 = new Elf();

            e2 = new Wizard(e2);
            Client_elves(e2);

            e2 = new Evil_Wizard(e2);
            Client_elves(e2);

            Console.WriteLine("===========================================");

            Elf e3 = new Elf();

            e3 = new Wizard(e3);
            Client_elves(e3);

            e3 = new Kind_Wizard(e3);
            Client_elves(e3);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.Read();
    }    
}