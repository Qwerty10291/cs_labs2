namespace cs_labs.lab10;

using System;

// Интерфейс определяющий методы для шифрования и дешифрования строк
public interface ICipher
{
    string Encode(string input);
    string Decode(string input);
}

// Класс ACipher реализующий интерфейс ICipher
public class ACipher : ICipher
{
    public string Encode(string input)
    {
        char[] chars = input.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            // Сдвигаем каждый символ на одну алфавитную позицию вверх
            chars[i] = (char)(chars[i] + 1);
        }

        return new string(chars);
    }

    public string Decode(string input)
    {
        char[] chars = input.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            // Сдвигаем каждый символ на одну алфавитную позицию вниз
            chars[i] = (char)(chars[i] - 1);
        }

        return new string(chars);
    }
}

// Класс BCipher реализующий интерфейс ICipher
public class BCipher : ICipher
{
    public string Encode(string input)
    {
        char[] chars = input.ToCharArray();

        for (int i = 0; i < chars.Length; i++)
        {
            // Заменяем каждую букву на букву того же регистра,
            // расположенную в алфавите на i-й позиции с конца алфавита
            chars[i] = (char)(90 - (chars[i] - 65)); // 90 - код буквы 'Z', 65 - код буквы 'A'
        }

        return new string(chars);
    }

    public string Decode(string input)
    {
        // Декодирование BCipher совпадает с кодированием
        return Encode(input);
    }
}
