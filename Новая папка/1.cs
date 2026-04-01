// Класс-родитель базовый класс для классов Cat и Dog
class Animal(string name, string type, int age)
{
    public string Name { get; set; } = name;  
    public string Type { get; set; } = type;  
    public int Age { get; set; } = age;

    // virtual — разрешаем переопределять
    public virtual void MakeSound()   
    {
        Console.WriteLine($"Животное {Name} издает звук");
    }
}
// Классы-наследники
class Cat(string name, string type, int age) : Animal(name, type, age)
{
    // Переопределяем метод для кошки
    public override void MakeSound()
    {
        Console.WriteLine($"Кошка {Name} говорит: Мяу");
    }
}

class Dog(string name, string type, int age) : Animal(name, type, age)
{
    // Переопределяем метод для собаки
    public override void MakeSound()
    {
        Console.WriteLine($"Собака {Name} говорит: Гав");
    }
}
class Program
{
    static void Main(string[] args)
    {
        var dog = new Dog("Бобик", "Дворняга", 5);
        var cat = new Cat("Пушок", "Каштан", 4);
        dog.MakeSound();  
        cat.MakeSound();  
    }
}
