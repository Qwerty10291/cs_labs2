namespace cs_labs.lab4;
using System;

class Task{
    public static void T1() {
        Console.Write("Введите год: ");
        int year = int.Parse(Console.ReadLine());

        if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
        {
            Console.Write("Введите номер дня в году (от 1 до 366): ");
            int dayOfYear = int.Parse(Console.ReadLine());

            if (dayOfYear < 1 || dayOfYear > 366)
            {
                Console.WriteLine("Недопустимое значение. Введите число от 1 до 366.");
            }
            else
            {
                int month = 0;
                int day = dayOfYear;

                int[] daysInMonth = year % 4 == 0 ? new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 } : new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

                for (int i = 0; i < 12; i++)
                {
                    if (day <= daysInMonth[i])
                    {
                        month = i + 1;
                        break;
                    }
                    day -= daysInMonth[i];
                }

                Console.WriteLine($"День {dayOfYear} соответствует {day}.{month}.");
            }
        }
        else
        {
            Console.WriteLine("Год не является високосным.");
        }

    }
}