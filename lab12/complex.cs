namespace cs_labs.lab12;
using System;

class ComplexNumber
{
    private double real;
    private double imaginary;

    // Конструктор для инициализации действительной и мнимой части
    public ComplexNumber(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    // Метод для сложения комплексных чисел
    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.real + b.real, a.imaginary + b.imaginary);
    }

    // Метод для вычитания комплексных чисел
    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.real - b.real, a.imaginary - b.imaginary);
    }

    // Метод для умножения комплексных чисел
    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(
            a.real * b.real - a.imaginary * b.imaginary,
            a.real * b.imaginary + a.imaginary * b.real
        );
    }

    // Метод для проверки на равенство комплексных чисел
    public static bool operator ==(ComplexNumber a, ComplexNumber b)
    {
        return a.real == b.real && a.imaginary == b.imaginary;
    }

    // Метод для проверки на неравенство комплексных чисел
    public static bool operator !=(ComplexNumber a, ComplexNumber b)
    {
        return !(a == b);
    }

    // Переопределение метода ToString() для вывода комплексного числа
    public override string ToString()
    {
        return $"({real} + {imaginary}i)";
    }
}