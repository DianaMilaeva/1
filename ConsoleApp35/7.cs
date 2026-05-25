class Animal
{
    public void Eat()
    {
        Console.WriteLine("Животное ест");
    }
}
class Cat : Animal
{
    public void Meow()
    {
        Console.WriteLine("Мяу");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Cat cat = new Cat();
        cat.Eat();
        cat.Meow();
    }
}
