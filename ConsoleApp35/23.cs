class Shape { }
class Circle : Shape
{
    public void DrawCircle()
    {
        Console.WriteLine("круг");
    }
}
class Square : Shape
{
    public void DrawSquare()
    {
        Console.WriteLine("квадрат");
    }
}

class Program
{
    static void Main()
    {
        Shape[] shapes = { new Circle(), new Square() };

        foreach (Shape s in shapes)
        {
            if (s is Circle)
            {
                Circle c = (Circle)s;
                c.DrawCircle();
            }
            else if (s is Square)
            {
                Square sq = (Square)s;
                sq.DrawSquare();
            }
        }
    }
}