class Human
{
    // Когда C# выделяет память данные автоматически инициализируются начальными значениями
    public string Name; // null - отсутствие ссылки на объект
    public int Age; // 0
}

struct Point2D
{
    public int x {  get; set; }
    public int y { get; set; }

    public Point2D(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Point2D() : this(10, 10)
    {

    }
}

class Program
{
    static void Main(string[] args)
    {
        /*
        // Значимый тип данных хранится в стеке
        int num1 = 123;
        int num2 = num1; // При передпче данных в другую переменную значение из num1 копируется в num2
        Console.WriteLine($"num1 {num1}, num2 {num2}");
        num2 = 55;
        Console.WriteLine($"num1 {num1}, num2 {num2}");
        // Ссылочный тип данных хранится в куче
        Human vasya = new Human() { Name = "Vasya" };
        Human petya = vasya; // Мы передаем ссылку на уже существующий объект
        Console.WriteLine($"vasya name: {vasya.Name} petya name: {petya.Name}");
        petya.Name = "Petya";
        Console.WriteLine($"vasya name: {vasya.Name} petya name: {petya.Name}");
        // Неизменяемый ссылочный тип данных
        string str1 = "Hello";
        string str2 = str1; // Мы создаем новый объект и копируем данные с исходного
        Console.WriteLine($"первая строка: {str1} вторая строка {str2}");
        str2 = "World";
        Console.WriteLine($"первая строка: {str1} вторая строка {str2}");


        Human human = new Human();
        Console.WriteLine(human.Name == "");
        */

        Point2D a = new Point2D();
        Point2D b = a;
        Console.WriteLine($"b.X{b.x} b.y {b.y} | a.X {a.x} a.Y {a.y}");
        a.x = 122;
        a.y = 512;
        Console.WriteLine($"b.X{b.x} b.y {b.y} | a.X {a.x} a.Y {a.y}");
    }
}