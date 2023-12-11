namespace cs_labs.lab14;

using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class DeveloperInfoAttribute : Attribute
{
    public string DeveloperName { get; }
    public DateTime DevelopmentDate { get; }

    public DeveloperInfoAttribute(string developerName)
    {
        DeveloperName = developerName;
    }

    public DeveloperInfoAttribute(string developerName, string developmentDate)
    {
        DeveloperName = developerName;
        if (DateTime.TryParse(developmentDate, out var date))
        {
            DevelopmentDate = date;
        }
        else
        {
            throw new ArgumentException("Invalid date format. Please provide a valid date.");
        }
    }
}

[DeveloperInfo("Andrey Tazetdinov", "2023-12-13")]
[DeveloperInfo("Sineev Nikita")] 
class RationalNumber
{
    private int numerator;
    private int denominator;

    // Конструктор для инициализации числителя и знаменателя
    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен нулю.");
        }

        this.numerator = numerator;
        this.denominator = denominator;
        Simplify(); // Упростим дробь при создании
    }

    // Метод для упрощения дроби
    private void Simplify()
    {
        int gcd = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));
        numerator /= gcd;
        denominator /= gcd;

        // Установим знак дроби
        if (numerator < 0 && denominator < 0)
        {
            numerator = Math.Abs(numerator);
            denominator = Math.Abs(denominator);
        }
        else if (denominator < 0)
        {
            numerator = -numerator;
            denominator = Math.Abs(denominator);
        }
    }

    // Метод для вычисления НОД
    private int GreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Переопределение метода ToString() для вывода дроби
    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }

    // Перегрузка операторов == и !=
    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        return a.numerator * b.denominator == b.numerator * a.denominator;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        return !(a == b);
    }

    // Перегрузка операторов <, >, <=, >=
    public static bool operator <(RationalNumber a, RationalNumber b)
    {
        return a.numerator * b.denominator < b.numerator * a.denominator;
    }

    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        return a.numerator * b.denominator > b.numerator * a.denominator;
    }

    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        return a.numerator * b.denominator <= b.numerator * a.denominator;
    }

    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        return a.numerator * b.denominator >= b.numerator * a.denominator;
    }

    // Перегрузка операторов + и -
    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        return new RationalNumber(a.numerator * b.denominator + b.numerator * a.denominator,
                                  a.denominator * b.denominator);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        return new RationalNumber(a.numerator * b.denominator - b.numerator * a.denominator,
                                  a.denominator * b.denominator);
    }

    // Перегрузка операторов ++ и --
    public static RationalNumber operator ++(RationalNumber a)
    {
        return new RationalNumber(a.numerator + a.denominator, a.denominator);
    }

    public static RationalNumber operator --(RationalNumber a)
    {
        return new RationalNumber(a.numerator - a.denominator, a.denominator);
    }
}