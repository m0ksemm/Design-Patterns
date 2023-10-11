// See https://aka.ms/new-console-template for more information

/*
* Car (продукт) представляет сложный конструируемый объект.
* ConcreteBuilder строит внутреннее представление продукта и определяет процесс его сборки.
*/

//В данном задании реализован дилер машин марки Mazda. 
//Вместо Daewoo Lanos, Ford Probe, UAZ Patriot и Hyundai Getz 
//создаются разные модели машинины марки Mazda: кроссоверы, седан,
//внедорожник, купе, хетчбэк. Всего машин 6:
//Mazda3(седан), Mazda6(хетчбэк), Mazda CX-30(кроссовер),
//Mazda CX-5(кроссовер), Mazda CX-9(внедорожник), Mazda MX-5(купе или роудстер)
//Помимо указанных в задании параметров продукта добавлен параметр цена машины - 
//поле типа decimal. Цена указана в долларах 

class Car
{
	private string name;    // название модели 
	private string type;    // тип/класс модели 
	private int engine;     // двигатель, мощность в лошадиных силах 
	private int wheelR;     // радиус колеса 
	private string gearbox; // коробка передач 
	private decimal price;  // цена машины 


	public void SetName(string _name)
	{
		name = _name;
	}
	public string GetName()
	{
		return name;
	}
	public void SetType(string _type)
	{
		type = _type;
	}
	public new string GetType()
	{
		return type;
	}
	public void SetEngine(int _engine)
	{
		engine = _engine;
	}
	public int GetEngine()
	{
		return engine;
	}
	public void SetWheelR(int _wheelR)
	{
		wheelR = _wheelR;
	}
	public int GetWheelR()
	{
		return wheelR;
	}
	public void SetGearbox(string _gearbox)
	{
		gearbox = _gearbox;
	}
	public string GetGearbox()
	{
		return gearbox;
	}
	public void SetPrice(decimal _price)
	{
		price = _price;
	}
	public decimal GetPrice()
	{
		return price;
	}
	public void ShowCar()
	{
		Console.WriteLine("_____________________________________");
		Console.WriteLine("|Car:     |  {0}", name);
		Console.WriteLine("|Type:    |  {0}", type);
		Console.WriteLine("|Wheel R.:|  {0}", wheelR);
		Console.WriteLine("|Gearbox: |  {0}", gearbox); 
		Console.WriteLine("|Price:   |  {0}", price);
		Console.WriteLine("_____________________________________");
	}
};

////////////////////////////////////////////////////////////////
// Abstract Builder задает абстрактный интерфейс (класс) 
// для создания частей объекта Product (в нашем случае, Car);
/* "Abstract Builder" */
////////////////////////////////////////////////////////////////
class CarBuilder 
{
	protected Car car = new Car();
	public Car GetCar()
	{
		return car;
	}
	public virtual void CreateName() { }
	public virtual void CreateType() { }
	public virtual void CreateEngine() { }
	public virtual void CreateWheels() { }
	public virtual void CreateGearbox() { }
	public virtual void CreatePrice() { }

};
//////////////////////////////////////////////////////////////////////
///// ConcreteBuilder выполняет следующие действия:
// - конструирует и собирает вместе части продукта посредством реализации интерфейса Builder;
// - определяет создаваемое представление и следит за ним;
// - предоставляет интерфейс для доступа к продукту
///////////////////////////////////////////////////////////////////

class Mazda6Builder : CarBuilder     // Мазда 6, седан.
{
	public override void CreateName() 
	{
		car.SetName("Mazda 6");
	}
	public override void CreateType()
	{
		car.SetType("Sedan, class D");
	}
	public override void CreateEngine()
	{
		car.SetEngine(194);
	}
	public override void CreateWheels()
	{
		car.SetWheelR(16);
	}
	public override void CreateGearbox()
	{
		car.SetGearbox("6 Auto");
	}

	public override void CreatePrice() 
	{
		car.SetPrice(30280);
	}
};

class MazdaCX5Builder : CarBuilder       // Мазда СХ-5, кроссовер.
{
	public override void CreateName()
	{
		car.SetName("Mazda CX-5");
	}
	public override void CreateType()
	{
		car.SetType("Crossover, class K1");
	}
	public override void CreateEngine()
	{
		car.SetEngine(194);
	}
	public override void CreateWheels()
	{
		car.SetWheelR(19);
	}
	public override void CreateGearbox()
	{
		car.SetGearbox("6 Auto");
	}
	public override void CreatePrice()
	{
		car.SetPrice(33100);
	}
};

class MazdaCX30Builder : CarBuilder      // Мазда СХ-30, кроссовер.
{
	public override void CreateName()
	{
		car.SetName("Mazda CX-30");
	}
	public override void CreateType()
	{
		car.SetType("Crossover, class K1");
	}
	public override void CreateEngine()
	{
		car.SetEngine(180);
	}
	public override void CreateWheels()
	{
		car.SetWheelR(17);
	}
	public override void CreateGearbox()
	{
		car.SetGearbox("6 Auto");
	}
	public override void CreatePrice()
	{
		car.SetPrice(28500);
	}
};

class MazdaMX5Builder : CarBuilder      // Мазда МХ-5, роудстер, купе.
{
	public override void CreateName()
	{
		car.SetName("Mazda MX-5");
	}
	public override void CreateType()
	{
		car.SetType("Roadster, class H1");
	}
	public override void CreateEngine()
	{
		car.SetEngine(184);
	}
	public override void CreateWheels()
	{
		car.SetWheelR(16);
	}
	public override void CreateGearbox()
	{
		car.SetGearbox("6 Mnual");
	}
	public override void CreatePrice()
	{
		car.SetPrice(41110);
	}
};

class MazdaCX9Builder : CarBuilder    // Мазда СХ-9, внедорожник.
{
	public override void CreateName()
	{
		car.SetName("Mazda CX-9");
	}
	public override void CreateType()
	{
		car.SetType("SUV, class K3");
	}
	public override void CreateEngine()
	{
		car.SetEngine(231);
	}
	public override void CreateWheels()
	{
		car.SetWheelR(20);
	}
	public override void CreateGearbox()
	{
		car.SetGearbox("6 Auto");
	}
	public override void CreatePrice()
	{
		car.SetPrice(54630);
	}
};

class Mazda3Builder : CarBuilder   // Мазда 3 хетчбэк. Строитель был добавлен дополнительно 
{
	public override void CreateName()
	{
		car.SetName("Mazda 3");
	}
	public override void CreateType()
	{
		car.SetType("Hatchback, class C");
	}
	public override void CreateEngine()
	{
		car.SetEngine(180);
	}
	public override void CreateWheels()
	{
		car.SetWheelR(16);
	}
	public override void CreateGearbox()
	{
		car.SetGearbox("6 Auto");
	}
	public override void CreatePrice()
	{
		car.SetPrice(26000);
	}
};
////////////////////////////////////////////////////////////////////////////////////////////
// Director(распорядитель) - конструирует объект (Car), пользуясь интерфейсом Builder //////
////////////////////////////////////////////////////////////////////////////////////////////
////// Этот класс заменяет класс Shop   ////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////

class Mazda_Car_Dealership
{
	private CarBuilder carBuilder = new CarBuilder();

    public void SetCarBuilder(CarBuilder cb)
    {
		carBuilder = cb;
    }
	public Car GetCar()
    {
        return carBuilder.GetCar();
    }
	public void ConstructCar()
    {
		carBuilder.CreateName();
		carBuilder.CreateType();
		carBuilder.CreateEngine();
		carBuilder.CreateWheels();
		carBuilder.CreateGearbox();
		carBuilder.CreatePrice();
	}
};

////////////////////////////////////////////////////////////////////////////////////////////
// клиент создает объект-распорядитель Director и конфигурирует его нужным объектом-строителем Builder
////////////////////////////////////////////////////////////////////////////////////////////
class Client 
{
	public void client(CarBuilder  builder)
	{
		Mazda_Car_Dealership dealer = new Mazda_Car_Dealership();
		dealer.SetCarBuilder(builder);
		dealer.ConstructCar();
		Car car = dealer.GetCar();
		car.ShowCar();
	}
}

class MainClass 
{
	public static void Menu() 
	{
		Console.WriteLine("Choose the car that you want to create: ");
		Console.WriteLine("1 - Mazda 3");
		Console.WriteLine("2 - Mazda 6");
		Console.WriteLine("3 - Mazda CX-5");
		Console.WriteLine("4 - Mazda CX-30");
		Console.WriteLine("5 - Mazda CX-9");
		Console.WriteLine("6 - Mazda MX-5");
		Console.WriteLine("Esc - exit");
	}
	public static void Main() 
	{
		try
		{
			Client c = new Client();
			while (true) 
			{
				Console.Clear();
				Menu();
				ConsoleKeyInfo keyInfo = Console.ReadKey(true);
				Console.Clear();
				if (keyInfo.Key == ConsoleKey.D1) 
				{
					CarBuilder builder = new Mazda3Builder();
					c.client(builder);
					Console.ReadKey();
				}
				else if (keyInfo.Key == ConsoleKey.D2)
				{
					CarBuilder builder = new Mazda6Builder();
					c.client(builder);
					Console.ReadKey();
				}
				else if (keyInfo.Key == ConsoleKey.D3)
				{
					CarBuilder builder = new MazdaCX5Builder();
					c.client(builder);
					Console.ReadKey();
				}
				else if (keyInfo.Key == ConsoleKey.D4)
				{
					CarBuilder builder = new MazdaCX30Builder();
					c.client(builder);
					Console.ReadKey();
				}
				else if (keyInfo.Key == ConsoleKey.D5)
				{
					CarBuilder builder = new MazdaCX9Builder();
					c.client(builder);
					Console.ReadKey();
				}
				else if (keyInfo.Key == ConsoleKey.D6)
				{
					CarBuilder builder = new MazdaMX5Builder();
					c.client(builder);
					Console.ReadKey();
				}
				else if (keyInfo.Key == ConsoleKey.Escape) 
				{
					break;
				}
			}
			
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		Console.ReadKey();
	}
}