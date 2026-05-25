class Rectangle
{
    private int _width;
    private int _height;
    public int Width
    {
        get { return _width; }
        set { _width = value; }
    }
    public int Height
    {
        get { return _height; }
        set { _height = value; }
    }
    public Rectangle()
    {
        _width = 1;
        _height = 1;
    }
    public Rectangle(int width, int height)
    {
        _width = width;
        _height = height;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Rectangle r = new Rectangle();
        Rectangle rectangle = new Rectangle(6, 9);
        Console.WriteLine($"{r.Width} x {r.Height}");
        Console.WriteLine($"{rectangle.Width} x {rectangle.Height}");
    }
}
