/*
class RefBox
{
    public int Value;
}
struct ValBox
{
    public int Value;
}
class Program
{
    static void ChangeValue(RefBox refBox, ValBox valBox)
    {
        refBox.Value = 99;
        valBox.Value = 99;
    }
    static void Main(string[] args)
    {
        RefBox refBox = new RefBox();
        refBox.Value = 10;
        ValBox valBox = new ValBox();
        valBox.Value = 10;
        ChangeValue(refBox, valBox);
        Console.WriteLine($"Struct: {valBox.Value}");
        Console.WriteLine($"Class: {refBox.Value}");
    }
}*/