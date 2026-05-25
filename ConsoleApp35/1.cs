class Dog
{
    private string _name;
    private int _age;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Age
    {
        get { return _age; }
        set { _age = value; }
    }
    public Dog(string name, int age)
    {
        _name = name;
        _age = age;
    }
    public void Bark()
    {
        Console.WriteLine("Гав-гав");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog("dfef", 2);
        dog.Bark();
    }
}
