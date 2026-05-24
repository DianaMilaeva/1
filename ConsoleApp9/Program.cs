class Seat
{
    public bool IsBooked { get; private set; }
    public string BookedBy { get; private set; }

    public void Book(string name)
    {
        IsBooked = true;
        BookedBy = name;
    }

    public void Cancel()
    {
        IsBooked = false;
        BookedBy = null;
    }
}


class Hall
{
    private Seat[,] seats = new Seat[5, 10];
    public string ConcertName;

    public Hall(string name)
    {
        ConcertName = name;
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 10; j++)
                seats[i, j] = new Seat();
    }

    public void Show()
    {
        Console.WriteLine($"\n{ConcertName}");
        Console.WriteLine("    1  2  3  4  5  6  7  8  9  10");
        Console.WriteLine("");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"{i + 1}  ");
            for (int j = 0; j < 10; j++)
            {
                if (seats[i, j].IsBooked)
                    Console.Write(" X ");
                else
                    Console.Write($" {j + 1} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public bool Book(int row, int col, string name)
    {
        if (seats[row, col].IsBooked) return false;
        seats[row, col].Book(name);
        return true;
    }

    public bool Cancel(int row, int col, string name)
    {
        if (!seats[row, col].IsBooked) return false;
        if (seats[row, col].BookedBy != name) return false;
        seats[row, col].Cancel();
        return true;
    }
}


class Program
{
    static void Main()
    {
        List<Hall> halls = new List<Hall>();
        halls.Add(new Hall("Шаманчик :D - 1 мая"));
        halls.Add(new Hall("Шаманчик :D - 2 мая"));
        halls.Add(new Hall("Шаманчик :D - 3 мая"));
        halls.Add(new Hall("Шаманчик :D - 4 мая"));
        halls.Add(new Hall("Шаманчик :D - 5 мая"));

        string userName;
        Console.Write("Ваше имя: ");
        userName = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("\n меню");
            Console.WriteLine("1  Выбрать концерт");
            Console.WriteLine("2  Мои брони");
            Console.WriteLine("3  Отменить бронь");
            Console.WriteLine("4  Выход");
            Console.Write(">_: ");

            string num = Console.ReadLine();

            if (num == "1")
            {

                for (int i = 0; i < halls.Count; i++)
                    Console.WriteLine($"{i + 1} - {halls[i].ConcertName}");

                Console.Write("Выберите :) ");
                int choice = int.Parse(Console.ReadLine()) - 1;

                if (choice >= 0 && choice < halls.Count)
                {
                    Hall hall = halls[choice];

                    while (true)
                    {
                        Console.WriteLine($"\n{hall.ConcertName}");
                        Console.WriteLine("1  Зал");
                        Console.WriteLine("2  Бронь");
                        Console.WriteLine("3  Назад");
                        Console.Write(">_: ");

                        string str1 = Console.ReadLine();

                        if (str1 == "1")
                        {
                            hall.Show();
                        }
                        else if (str1 == "2")
                        {
                            Console.Write("Ряд 1-5 ");
                            int r = int.Parse(Console.ReadLine()) - 1;
                            Console.Write("Место 1-10 ");
                            int c = int.Parse(Console.ReadLine()) - 1;

                            if (hall.Book(r, c, userName))
                                Console.WriteLine("Готово");
                            else
                                Console.WriteLine("Место занято");
                        }
                        else if (str1 == "3")
                        {
                            break;
                        }
                    }
                }
            }
            else if (num == "2")
            {
                Console.WriteLine($"\nТвои брони, {userName}:");
                Console.WriteLine("смотри в залах");
            }
            else if (num == "3")
            {
                for (int i = 0; i < halls.Count; i++)
                    Console.WriteLine($"{i + 1} - {halls[i].ConcertName}");

                Console.Write("Выберите концерт ");
                int choice = int.Parse(Console.ReadLine()) - 1;

                if (choice >= 0 && choice < halls.Count)
                {
                    Hall hall = halls[choice];
                    Console.Write("Ряд 1-5 ");
                    int r = int.Parse(Console.ReadLine()) - 1;
                    Console.Write("Место 1-10 ");
                    int c = int.Parse(Console.ReadLine()) - 1;

                    if (hall.Cancel(r, c, userName))
                        Console.WriteLine("Бронь отменена");
                    else
                        Console.WriteLine("Не твоя бронь или место свободно");
                }
            }
            else if (num == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Неверно");
            }
        }
    }
}