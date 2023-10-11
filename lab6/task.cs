namespace cs_labs.lab6;
using System;
using System.Collections.Generic;

class Task
{

    static void T1(string[] args) {
        if (args.Length != 1)
        {
            Console.WriteLine("Пожалуйста, укажите имя файла в аргументе командной строки.");
            return;
        }

        string fileName = args[0];

        if (!File.Exists(fileName))
        {
            Console.WriteLine("Указанный файл не существует.");
            return;
        }

        char[] text = File.ReadAllText(fileName).ToCharArray();
        int vowels;
        vowels = CountVowels(text);

        Console.WriteLine($"Количество гласных букв: {vowels}");
        Console.WriteLine($"Количество согласных букв: {text.Length - vowels}");

    }
    static int CountVowels(char[] text)
    {
        var vowelsSet = new HashSet<char>{'a', 'e', 'i', 'o', 'u'};
        return text.Select(x => vowelsSet.Contains(x) ? 1: 0).Sum();
    }

    static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int cols2 = matrix2.GetLength(1);

        int[,] resultMatrix = new int[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                int sum = 0;
                for (int k = 0; k < cols1; k++)
                {
                    sum += matrix1[i, k] * matrix2[k, j];
                }
                resultMatrix[i, j] = sum;
            }
        }

        return resultMatrix;
    }
    
    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

}