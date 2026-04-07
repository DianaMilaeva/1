using System;
using System.Drawing;
using System.Security.Cryptography;

abstract class Figure
{
    public abstract void Draw();
    public abstract double GetArea();
}

class Circle : Figure
{
    private double radius;
    public Circle(double radius)
    {
        this.radius = radius;
    }
    public override void Draw()
    {
        var text = """
           *****
         *       *
        *         *
         *       *
           *****

        """;
        Console.WriteLine(text);
    }

    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

class Rectangle : Figure
{
    private double width;
    private double height;
    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override void Draw()
    {
        var text = """
        ****
        *  *
        ****

        """;
        Console.WriteLine(text);
    }

    public override double GetArea()
    {
        return width * height;
    }
}

class Square : Figure
{
    private double side;
    public Square(double side)
    {
        this.side = side;
    }
    public override void Draw()
    {
        var text = """
        ████████████
        ██        ██
        ██        ██
        ██        ██
        ████████████

        """;
        Console.WriteLine(text);
    }
    public override double GetArea()
    {
        return side * side;
    }
}

class FigureManager
{
    public Figure CreateFigure(string type, params double[] parameters)
    {
        if (type == "circle")
        {
            return new Circle(parameters[0]);
        } else if (type == "rectangle")
        {
            return new Rectangle(parameters[0], parameters[1]);
        } else if (type == "square")
        {
            return new Square(parameters[0]);
        }
        else
        {
            throw new ArgumentException("Неизвестный тип фигуры");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        FigureManager manager = new FigureManager();

        Figure circle = manager.CreateFigure("circle", 3.0);
        circle.Draw();
        Console.WriteLine($"Площадь: {circle.GetArea():F2}");

        Figure rect = manager.CreateFigure("rectangle", 4.0, 2.5);
        rect.Draw();
        Console.WriteLine($"Площадь: {rect.GetArea():F2}");

        Figure square = manager.CreateFigure("square", 6.0);
        square.Draw();
        Console.WriteLine($"Площадь: {square.GetArea():F2}");
    }
}

/*
Класс Figure абстрактный родительский класс с чистыми виртуальными функциями (без реализации), задающий общий функционал для геометрических фигур.
Его наследники круг, квадрат и прямоугольник реализуют конкретные правила: например, вычисляют площадь и рисуют фигуру.
При вызове метода Draw через тип  Figure программа автоматически использует реализацию из соответствующего класса наследника
*/