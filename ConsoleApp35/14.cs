struct Point
{
    private int _x;
    private int _y;
    public int X
    {
        get { return _x; }
        set { _x = value; }
    }
    public int Y
    {
        get { return _y; }
        set { _y = value; }
    }
    public Point(int x, int y)
    {
        _x = x;
        _y = y;
    }
    public void Show()
    {
        Console.WriteLine($"X: {X} | Y: {Y}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Point p1 = new Point(2,9);
        Point p2 = new Point(6,12);
        p1.Show();
        p2.Show();
    }
}
