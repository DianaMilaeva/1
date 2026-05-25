class Shape
{
    public virtual double Area()
    {
        return 0;
    }
}
class Circle : Shape
{
    public double Radius {  get; set; }
    public Circle(double radius)
    {
        Radius = radius;
    }
    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }
}
class Square : Shape
{
    public double Side { get; set; }
    public Square(double side)
    {
        Side = side;
    }
    public override double Area()
    {
        return Side * Side;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Circle circle = new Circle(10);
        Square square = new Square(20);
        Console.WriteLine(circle.Area());
        Console.WriteLine(square.Area());
    }
}
