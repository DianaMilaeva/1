/*
// Класс-родитель базовый класс для классов Cat и Dog
class Animal (string Name, string Type, int Age)
{
    public string Name { get; set; } = Name;
    public string Type { get; set; } = Type;
    public int Age { get; set; } = Age;

    public void MakeSound() { Console.WriteLine($"Животное {Name} издает звук"); }
}
// Класс-наследник производственный класс для класса Animal
class Cat(string Name, string Type, int Age) : Animal(Name, Type, Age) { }
class Dog(string Name, string Type, int Age) : Animal(Name, Type, Age) { }
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
*/

