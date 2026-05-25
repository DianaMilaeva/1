abstract class Figure
{
    public abstract double GetPerimeter();
}
class Triangle : Figure
{
    public double A {  get; set; }
    public double B {  get; set; }
    public double C {  get; set; }
    public Triangle(double  a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }
    public override double GetPerimeter()
    {
        return A + B + C;
    }
}
class Rectangle : Figure
{
    public double Width { get; set; }
    public double Height { get; set; }
    public Rectangle (double width, double height)
    {
        Width = width;
        Height = height;
    }
    public override double GetPerimeter()
    {
        return 2 * (Width + Height);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle(10, 10);
        rectangle.GetPerimeter();
        Triangle triangle = new Triangle(5, 2, 5);
        triangle.GetPerimeter(); 
    }
}
