class Person
{
    private int _age;
    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 0) Console.WriteLine("Ошибка: Возраст не может быть отрицательным");
            else if (value > 120) Console.WriteLine("Ошибка: Возраст не может превышать 120 лет");
            else _age = value;
        }
    }
    public Person(int age)
    {
        Age = age; 
    }
    public void ShowInfo()
    {
        Console.WriteLine($"{Age} лет");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person person1 = new Person(25);
        person1.ShowInfo(); 
        Person person2 = new Person(-5);  
        person2.ShowInfo();
    }
}