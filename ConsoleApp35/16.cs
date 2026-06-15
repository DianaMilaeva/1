struct Coordinate
{
    public int X { get; set; }
    public int Y {  get; set; }
    public Coordinate(int x, int y)
    {
        X = x; 
        Y = y; 
    }
}
class Player
{
    public Coordinate position;
    public Player(int x, int y)
    {
        position = new Coordinate(x, y); 
    }
    public void Move(int dx, int dy)
    {
        position.X += dx;
        position.Y += dy;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Player player = new Player(0, 0);
        player.Move(10, 1);
        Console.WriteLine($"X: {player.position.X}, Y: {player.position.Y}");
    }
}
