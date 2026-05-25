class Book
{
    private string _title;
    private string _author;
    public string Title
    {
        get { return _title; }
        set { _title = value; }
    }
    public string Author
    {
        get { return _author; }
        set { _author = value; }
    }
    public Book(string  title, string author)
    {
        _title = title;
        _author = author;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Book book1 = new Book("Война и мир", "Толстой");
        Book book2 = new Book("Преступление и наказание", "Достоевский");
        Console.WriteLine($"{book1.Title} - {book1.Author}");
        Console.WriteLine($"{book2.Title} - {book2.Author}");
    }
}
