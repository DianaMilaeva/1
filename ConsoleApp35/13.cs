/*
interface IReadable
{
    void Read();
}
interface IWritable
{
    void Write();
}
class Notebook : IReadable, IWritable
{
    public void Read()
    {
        Console.WriteLine("Читаю записи");
    }

    public void Write()
    {
        Console.WriteLine("Пишу заметки");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Notebook notebook = new Notebook();
        notebook.Read();
        notebook.Write();
    }
}
*/