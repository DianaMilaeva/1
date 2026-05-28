abstract class Animal
{
    public int Age { get; set; }
    public string Name { get; set; }
    public abstract void MakeSound();
}
interface IFlyable
{
    void Fly();
}
class Lion : Animal
{
    public override void MakeSound() => Console.WriteLine("ррррр");
}
class Parrot : Animal, IFlyable
{
    public override void MakeSound() => Console.WriteLine("crack-crack");
    public void Fly() => Console.WriteLine("Fly");
}
class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        animals.Add(new Parrot());
        animals.Add(new Lion());
        foreach (var animal in animals)
        {
            animal.MakeSound();
            if (animal is IFlyable)
            {
                var animal_flyable = (IFlyable) animal;
                animal_flyable.Fly();
            }
        }
    }
}
