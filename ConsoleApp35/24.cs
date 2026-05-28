class Processor
{
    public string Model { get; set; }
    public int Cores { get; set; }

    public Processor(string model, int cores)
    {
        Model = model;
        Cores = cores;
    }
}
class Computer
{
    public string Brand { get; set; }
    public Processor Processor { get; set; } 
    public Computer(string brand, Processor processor)
    {
        Brand = brand;
        Processor = processor;
    }
    public void ShowInfo()
    {
        Console.WriteLine($"Компьютер: {Brand}, Процессор: {Processor.Model}, Количество ядер: {Processor.Cores}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Processor cpu = new Processor("Intel Core i7-12700K", 12);
        Computer pc = new Computer("Dell XPS", cpu);
        pc.ShowInfo();
    }
}