/*
class Vehicle
{
    private int _speed;
    public int Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    public Vehicle(int speed)
    {
        _speed = speed;
    }
}
class Car : Vehicle
{
    private string _brand;
    public string Brand
    {
        get { return _brand; }
        set { _brand = value; }
    }
    public Car(int speed,  string brand) : base(speed)
    {
        _brand = brand;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Car car = new Car(100, "Toyota");
        Console.WriteLine($"Скорость: {car.Speed}, Марка: {car.Brand}");
    }
}
*/