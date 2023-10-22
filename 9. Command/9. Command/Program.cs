using System;
using System.Collections.Generic;

// Receiver – конечный получатель команды. Именно он располагает информацией о том, как надо обрабатывать команду.
class Tic_Tac_Toe 
{
    private int[,] Field = new int[3, 3];
	public Tic_Tac_Toe() 
	{
		for (int i = 0; i < 3; i++) 
			for (int j = 0; j < 3; j++) 
				Field[i, j] = ' ';
	}

	public void Operation(char symbol, int x, int y) 
	{
		if (x > 0 && y > 0 && x < 4 && y < 4)
		{
			if (Field[x - 1, y - 1] == ' ')
			switch (symbol)
			{
				case 'X':
					Field[x - 1, y - 1] = symbol;
					break;
				case 'O':
					Field[x - 1, y - 1] = symbol;
					break;
			}
		}
		else if (x < 0 && y < 0 && x > -4 && y > -4) 
		{
			if (Field[-x - 1, -y - 1] != ' ')
				Field[-x - 1, -y - 1] = ' ';
		}
	}
	public void FieldShow()  // метод для вывода поля
	{
		Console.WriteLine(" -------------");
		for (int i = 0; i < 3; i++) 
		{
			Console.Write(" |");
			for (int j = 0; j < 3; j++) 
			{
				Console.Write(" {0} |", (char)Field[i,j]);
			}
			Console.WriteLine("\n -------------");
		}
	}
	public bool IfBusy(int i, int j)  // проверка, является ли клетка занятой
	{

		if (Field[i - 1, j - 1] != ' ')
			return true;
		else return false;
	}
	public bool IfDraw()  // проверка, сыграли ли игроки вничью 
	{
		int count = 0;

		for (int i = 0; i < 3; i++)
			for (int j = 0; j < 3; j++)
				if (Field[i, j] != ' ')
					count++;
		if (count == 9)
			return true;
		else return false;

	}
	public bool IfWonX() // проверка, выиграл ли крестик
	{
		///  ---
		if (Field[0, 0] == 'X' && Field[0, 1] == 'X' && Field[0, 2] == 'X')
			return true;
		else if (Field[1, 0] == 'X' && Field[1, 1] == 'X' && Field[1, 2] == 'X')
			return true;
		else if (Field[2, 0] == 'X' && Field[2, 1] == 'X' && Field[2, 2] == 'X')
			return true;
		////   |
		else if (Field[0, 0] == 'X' && Field[1, 0] == 'X' && Field[2, 0] == 'X')
			return true;
		else if (Field[0, 1] == 'X' && Field[1, 1] == 'X' && Field[2, 1] == 'X')
			return true;
		else if (Field[0, 2] == 'X' && Field[1, 2] == 'X' && Field[2, 2] == 'X')
			return true;
		/// \
		else if (Field[0, 0] == 'X' && Field[1, 1] == 'X' && Field[2, 2] == 'X')
			return true;
		/// /
		else if (Field[0, 2] == 'X' && Field[1, 1] == 'X' && Field[2, 0] == 'X')
			return true;
		else return false;
	}
	public bool IfWonO() // проверка, выиграл ли нолик
	{
		///  ---
		if (Field[0, 0] == 'O' && Field[0, 1] == 'O' && Field[0, 2] == 'O')
			return true;
		else if (Field[1, 0] == 'O' && Field[1, 1] == 'O' && Field[1, 2] == 'O')
			return true;
		else if (Field[2, 0] == 'O' && Field[2, 1] == 'O' && Field[2, 2] == 'O')
			return true;
		////   |
		else if (Field[0, 0] == 'O' && Field[1, 0] == 'O' && Field[2, 0] == 'O')
			return true;
		else if (Field[0, 1] == 'O' && Field[1, 1] == 'O' && Field[2, 1] == 'O')
			return true;
		else if (Field[0, 2] == 'O' && Field[1, 2] == 'O' && Field[2, 2] == 'O')
			return true;
		/// \
		else if (Field[0, 0] == 'O' && Field[1, 1] == 'O' && Field[2, 2] == 'O')
			return true;
		/// /
		else if (Field[0, 2] == 'O' && Field[1, 1] == 'O' && Field[2, 0] == 'O')
			return true;
		return false;
	}
}

// ICommand - интерфейс, представляющий команду.
interface ICommand 
{
	void Execute() ;
	void UnExecute();
};

// ConcreteCommand – конкретная команда.
class Step : ICommand
{
	private char symbol;
	private int x;
	private int y;
	private Tic_Tac_Toe ttt;
	public Step(Tic_Tac_Toe obj, char s, int i, int j) 
	{
		ttt = obj;
		symbol = s;
		x = i;
		y = j;
	}
	public void Execute() 
	{
		ttt.Operation(symbol, x, y);
	}
	public void UnExecute() 
	{
		ttt.Operation(symbol, -x, -y);
	}
}

// Invoker – это инициатор выполнения команды.
class User
{
	private List<ICommand> commands = new List<ICommand>();
	private int current = 0;
	public void Redo(int levels)
    {
        for (int i = 0; i < levels; i++)
            if (current <= commands.Count - 1)
                commands[current++].Execute();
    }
	public void Undo(int levels)
    {
        for (int i = 0; i < levels; i++)
            if (current > 0)
                commands[--current].UnExecute();
    }
	public void Compute(ICommand command)
    {
        command.Execute();
        commands.Add(command);
        current++;
    }
};

class MainClass 
{
    public static void Invoker(User user, ICommand command)
    {
        user.Compute(command);
    }
	
	public static void Menu() 
	{
		Console.WriteLine("Enter	    - make a step");
		Console.WriteLine("Left arrow  - cancel the step");
		Console.WriteLine("Right arrow - renew the step");
		Console.WriteLine("Escape      - left the game");
	}

	public static void Main() 
	{
		ConsoleKeyInfo play;
		while (true)
		{

			Console.Clear();
			Console.WriteLine("  Tic-tac-toe game ");
			Console.WriteLine("   For 2 players");
			Console.WriteLine("Enter  - to PLAY");
			Console.WriteLine("Escape - to LEFT the game");
			play = Console.ReadKey();

			if (play.Key == ConsoleKey.Enter)
			{

				Tic_Tac_Toe t = new Tic_Tac_Toe();
				User user = new User();

				bool turn = true;
				ConsoleKeyInfo key;

				while (true)
				{
					Console.Clear();
					Menu();
					t.FieldShow();
					key = Console.ReadKey(true);
					if (key.Key == ConsoleKey.Enter && turn == true)
					{
						turn = false;
						while (true)
						{
							Console.WriteLine("X: ");
							Console.WriteLine("Enter the row: ");
							int x = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Enter the column: ");
							int y = Convert.ToInt32(Console.ReadLine());
							if (x < 1 || y < 1 || x > 3 || y > 3)
							{
								Console.WriteLine("You are out of the field! Try again.");
								Console.WriteLine("Press any key to continue: ");
								Console.ReadKey();
								continue;
							}
							else if (t.IfBusy(x, y) == false)
							{
								ICommand command = new Step(t, 'X', x, y);
								Invoker(user, command);
								break;
							}
							else
							{
								Console.WriteLine("This place is busy! Try again.");
								Console.WriteLine("Press any key to continue: ");
								Console.ReadKey();
								continue;
							}

						}
					}
					else if (key.Key == ConsoleKey.Enter && turn == false)
					{
						turn = true;
						while (true)
						{
							Console.WriteLine("O: ");

							Console.WriteLine("Enter the row: ");
							int x = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Enter the column: ");
							int y = Convert.ToInt32(Console.ReadLine());
							if (x < 1 || y < 1 || x > 3 || y > 3)
							{
								Console.WriteLine("You are out of the field! Try again.");
								Console.WriteLine("Press any key to continue: ");
								Console.ReadKey();
								continue;
							}
							else if (t.IfBusy(x, y) == false)
							{
								ICommand command = new Step(t, 'O', x, y);
								Invoker(user, command);
								break;
							}
							else
							{
								Console.WriteLine("This place is busy! Try again.");
								Console.WriteLine("Press any key to continue: ");
								Console.ReadKey();
								continue;
							}
						}
					}
					else if (key.Key == ConsoleKey.Escape)
					{
						break;
					}
					else if (key.Key == ConsoleKey.LeftArrow)
					{
						user.Undo(1);
						if (turn == false)
							turn = true;
						else if (turn == true)
							turn = false;
					}
					else if (key.Key == ConsoleKey.RightArrow)
					{
						user.Redo(1);
						if (turn == false)
							turn = true;
						else if (turn == true)
							turn = false;
					}

					if (t.IfWonX() == true)
					{
						Console.Clear();
						t.FieldShow();
						Console.WriteLine("X has won!!! ");
						Console.WriteLine("Press any key to continue:");
						Console.ReadKey();
						break;
					}
					if (t.IfWonO() == true)
					{
						Console.Clear();
						t.FieldShow();
						Console.WriteLine("O has won!!! ");
						Console.WriteLine("Press any key to continue:");
						Console.ReadKey();
						break;
					}
					if (t.IfDraw() == true)
					{
						Console.Clear();
						t.FieldShow();
						Console.WriteLine("It's draw!!! You can try to play again ");
						Console.WriteLine("Press any key to continue:");
						Console.ReadKey();
						break;
					}
				}
			}
			else if (play.Key == ConsoleKey.Escape) 
			{
				break;
			}
		}
	}
}

