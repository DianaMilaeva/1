class Book
{
    private string title;
    private string author;
    private int page;
    private int year;

    public string Author
    {
        get { return author; }
        set
        {
            if (value == null) throw new ArgumentException("Ошибка");
            author = value;
        }
    }
    public int Year
    {
        get { return year; }
        set
        {
            if (value < 1400 || value > 2026) throw new ArgumentException("Неверный год");
            year = value;
        }
    }
    public int Page
    {
        get { return page; }
        set
        {
            if (value <= 0) throw new ArgumentException("Неверное кол-во страниц");
            page = value;
        }
    }
    public string Title
    {
        get { return title; }
        set
        {
            if (value == null) throw new ArgumentException("Ошибка");
            title = value;
        }
    }
    public Book(string title, string author, int page, int year)
    {
        Title = title;
        Author = author;
        Page = page;
        Year = year;
    }
    public virtual bool IsClassic()
    {
        if (year < 1950) return true;
        else return false;
    }
    public override string ToString()
    {
        return $"Название: {title}, Автор: {author}, Кол-во страниц: {page}, Год издания: {year}";
    }
    public virtual int CalculateFine(int days)
    {
        return days * 10;
    }
}
class Magazine : Book
{
    private int release;
    private string name;

    public int Release
    {
        get { return release; }
        set
        {
            if (value <= 0) throw new ArgumentException("Ошибка");
            release = value;
        }
    }
    public string Name
    {
        get { return name; }
        set
        {
            if (value == null) throw new ArgumentException("Ошибка");
            name = value;
        }
    }
    public Magazine(string title, string author, int page, int year, int release, string name) : base(title, author, page, year)
    {
        Release = release;
        Name = name;
    }
    public override bool IsClassic()
    {
        return false;
    }
    public override string ToString()
    {
        return base.ToString() + $", Номер выпуска: {release}, Издательство: {name}";
    }
    public override int CalculateFine(int days)
    {
        return days * 5;
    }
}
class EBook : Book
{
    private string format;
    public string Format
    {
        get { return format; }
        set
        {
            if (value == null) throw new ArgumentException("Ошибка");
            format = value;
        }
    }
    public override int CalculateFine(int days)
    {
        return 0;
    }
    public override bool IsClassic()
    {
        if (Year < 1950 && Page > 800) return true;
        else return false;
    }
    public EBook(string title, string author, int page, int year, string format) : base(title, author, page, year)
    {
        Format = format;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Book[] library = new Book[]
        {
            new Book("Война и мир", "Лев Толстой", 1300, 1869),
            new Book("Мастер и Маргарита", "Михаил Булгаков", 480, 1967),
            new Magazine("Наука и жизнь", "Редакция", 80, 2023, 12, "Наука-Пресс"),
            new EBook("1984", "Джордж Оруэлл", 328, 1949, "PDF"),
            new EBook("Преступление и наказание", "Фёдор Достоевский", 672, 1866, "EPUB")
        };
        foreach (Book book in library)
        {
            Console.WriteLine(book.ToString());
            Console.WriteLine($"Штраф за 7 дней: {book.CalculateFine(7)} руб.");
            Console.WriteLine($"Является классикой: {book.IsClassic()}");
        }
    }
}