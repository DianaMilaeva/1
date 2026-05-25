struct Coordinate
{
    public int X {  get; set; }
    public int Y { get; set; }
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Coordinate coordinate(int dx, int dy)
    {
        return new Coordinate(X + dx, Y + dy);
    }
}
class Player
{
    public Coordinate position {  get; set; }
    public void Move(int dx, int dy)
    {
        position = new Coordinate(position.X + dx, position.Y + dy);
    }
}
class Program 
{
    static void Main(string[] args)
    {
        Player player = new Player();
        player.position = new Coordinate(0, 0);
        player.Move(6, 3);
        Console.WriteLine($"X: {player.position.X}, Y: {player.position.Y}");
    }
}
