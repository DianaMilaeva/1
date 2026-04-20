using System.Threading.Channels;
// interface - контракт Задаёт правила меджу собой и классом-наследником
// Служит основой для других классов Мы не можем создавать его объект
// Интерфейс описывает контракт которому классы наследнику следуют
// 1. Когда не знаем точной реализации но знаем что должен быть такой механизм
// 2. Когда необходим общий род. тип данных для классов наследников
// 3. Для разделения логики в программе
interface IProperty
{
    string Color { get; set; }
}
interface IDrawable
{
    void Draw(); // Содержит только методы
}
class Square : IDrawable, IProperty{
    public string Color { get; set; }
    public void Draw() => Console.WriteLine("Рисует квадрат");
}
class Circle : IDrawable, IProperty
{
    public string Color { get; set; }
    public void Draw() => Console.WriteLine("Рисует круг");
}
class Program
{
    static void Main(string[] args)
    {
        IDrawable figure = new Square();
        figure.Draw();
        figure = new Circle();
        figure.Draw();
    }
}