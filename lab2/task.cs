namespace cs_labs.lab2;

using System;

class Task{
    public static void T1()
    {
        Console.Write("Введите букву: ");
        char inputChar = Console.ReadKey().KeyChar;

        if (char.IsLetter(inputChar))
        {
            char nextChar = (char)(inputChar + 1);
            Console.WriteLine($"\nСледующая буква: {nextChar}");
        }
        else
        {
            Console.WriteLine("\nВведен символ, который не является буквой.");
        }

    }

    public static void T2() {
        Console.WriteLine("Введите коэффициенты квадратного уравнения ax^2 + bx + c = 0:");

        Console.Write("Введите a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Введите b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Введите c: ");
        double c = double.Parse(Console.ReadLine());

        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"Уравнение имеет два корня: x1 = {x1}, x2 = {x2}");
        }
        else if (discriminant == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine($"Уравнение имеет один корень: x = {x}");
        }
        else
        {
            Console.WriteLine("Уравнение не имеет действительных корней.");
        }

    }
}