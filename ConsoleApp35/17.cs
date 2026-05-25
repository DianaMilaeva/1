/*
class Transport
{
    public string Name { get; set; }
    public int Speed {  get; set; }
    public Transport(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }
    public virtual void Move()
    {
        Console.WriteLine($"{Name} едет со скоростью {Speed} км/ч");
    }
}
class LandTransport : Transport
{
    public int WhelsCount { get; set; }
    public LandTransport(string name, int speed, int whelsCount) : base(name, speed)
    {
        WhelsCount = whelsCount;
    }
    public override void Move()
    {
        Console.WriteLine($"{Name} едет по земле на {WhelsCount} колесах со скоростью {Speed} км/ч");
    }
}
class Car : LandTransport
{
    public string Brand { get; set; }
    public Car(string name, int speed, int whelsCount, string brand) : base(name, speed, whelsCount)
    {
        Brand = brand;
    }
    public override void Move()
    {
        Console.WriteLine($"{Brand} {Name} едет по дороге на {WhelsCount} колесах со скоростью {Speed} км/ч");
    }
    public void Honk()
    {
        Console.WriteLine($"{Brand} {Name} сигналит");
    }
}
class Bike : LandTransport
{
    public bool HasBell { get; set; }
    public Bike(string name, int speed, int whelsCount, bool hasBell) : base(name, speed, whelsCount)
    {
        HasBell = hasBell;
    }
    public void RingBell()
    {
        if (HasBell) Console.WriteLine("Звонок");
        else Console.WriteLine("Звонка нет");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Car car = new Car("efhef", 180, 4, "fvgfij");
        Bike bike = new Bike("jdhfe", 25, 2, true);
        car.Move();
        car.Honk();
        Console.WriteLine();
        bike.Move();
        bike.RingBell();
    }
}*/