namespace cs_labs.lab10;

using System;

// Базовый класс Figure
public class Figure
{
    private string color;
    private bool isVisible;

    // Конструктор
    public Figure(string color, bool isVisible)
    {
        this.color = color;
        this.isVisible = isVisible;
    }

    // Методы для передвижения по горизонтали и вертикали
    public virtual void MoveHorizontal(int distance)
    {
        Console.WriteLine($"Moving horizontally by {distance} units.");
    }

    public virtual void MoveVertical(int distance)
    {
        Console.WriteLine($"Moving vertically by {distance} units.");
    }

    // Метод для изменения цвета
    public void ChangeColor(string newColor)
    {
        color = newColor;
        Console.WriteLine($"Changing color to {newColor}.");
    }

    // Метод для опроса состояния (видимый/невидимый)
    public void ToggleVisibility()
    {
        isVisible = !isVisible;
        Console.WriteLine($"Toggling visibility to {(isVisible ? "visible" : "invisible")}.");
    }

    // Метод для вывода состояния на экран
    public void DisplayStatus()
    {
        Console.WriteLine($"Color: {color}, Visibility: {(isVisible ? "visible" : "invisible")}");
    }
}

// Класс Point (точка) как потомок геометрической фигуры
public class Point : Figure
{
    protected int x;
    protected int y;
    public Point(string color, bool isVisible, int x, int y) : base(color, isVisible)
    {
        this.x = x;
        this.y = y;
    }

    // Перегруженные методы для передвижения по горизонтали и вертикали
    public override void MoveHorizontal(int distance)
    {
        x += distance;
    }

    public override void MoveVertical(int distance)
    {
        y += distance;
    }
}

// Класс Circle (окружность) как потомок точки
public class Circle : Point
{
    private double radius;

    public Circle(string color, bool isVisible, int x, int y, double radius ) : base(color, isVisible, x, y)
    {
        this.radius = radius;
    }

    // Метод для вычисления площади окружности
    public double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

// Класс Rectangle (прямоугольник) как потомок точки
public class Rectangle : Point
{
    private double length;
    private double width;

    public Rectangle(string color, bool isVisible, int x, int y, double length, double width) : base(color, isVisible, x, y)
    {
        this.length = length;
        this.width = width;
    }

    // Метод для вычисления площади прямоугольника
    public double CalculateArea()
    {
        return length * width;
    }
}
