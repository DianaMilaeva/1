class Employee
{
    public virtual void Work()
    {
        Console.WriteLine("Работаю");
    }
}
class Programmer : Employee
{
    public override void Work()
    {
        Console.WriteLine("Пишу код");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Programmer programmer = new Programmer();
        programmer.Work();
    }
}
