namespace cs_labs.lab8;

public class Task{
    
    public static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }


    public static void FileToUpper() {
        Console.Write("Введите имя файла: ");
        string inputFileName = Console.ReadLine();

        // Проверка наличия файла
        if (!File.Exists(inputFileName))
        {
            Console.WriteLine($"Файл '{inputFileName}' не существует. Программа завершает работу.");
            return;
        }

        // Создаем имя выходного файла (добавляем "_OUTPUT" к исходному имени файла)
        string outputFileName = Path.Combine(Path.GetDirectoryName(inputFileName), 
                                            Path.GetFileNameWithoutExtension(inputFileName) + "_OUTPUT" + Path.GetExtension(inputFileName));

        try
        {
            // Чтение содержимого исходного файла
            string content = File.ReadAllText(inputFileName);

            // Преобразование содержимого в верхний регистр
            string upperCaseContent = content.ToUpper();

            // Запись преобразованного содержимого в выходной файл
            File.WriteAllText(outputFileName, upperCaseContent);

            Console.WriteLine($"Содержимое файла успешно записано в файл '{outputFileName}'.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    public static void CheckIFormattable(object value)
    {
        if (value is IFormattable formattableObject)
        {
            Console.WriteLine("Объект реализует интерфейс IFormattable.");

            // Дополнительные действия с объектом, реализующим интерфейс IFormattable
            // Например, вызов методов интерфейса IFormattable:
            string formattedValue = formattableObject.ToString("G", null);
            Console.WriteLine($"Форматированное значение: {formattedValue}");
        }
        else
        {
            Console.WriteLine("Объект не реализует интерфейс IFormattable.");
        }
    }

    public static void GetEmails()
    {
        string inputFileName = "input.txt";
        string outputFileName = "output.txt";

        // Проверка наличия исходного файла
        if (!File.Exists(inputFileName))
        {
            Console.WriteLine($"Файл '{inputFileName}' не существует.");
            return;
        }

        try
        {
            // Чтение из исходного файла и запись в новый файл
            using (StreamReader reader = new StreamReader(inputFileName))
            using (StreamWriter writer = new StreamWriter(outputFileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    // Используем метод SearchMail для поиска адреса электронной почты в строке
                    string email = SearchMail(ref line);

                    // Записываем адрес электронной почты в новый файл
                    writer.WriteLine(email);
                }
            }

            Console.WriteLine($"Адреса электронной почты успешно записаны в файл '{outputFileName}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    // Метод для поиска адреса электронной почты в строке
    public static string SearchMail(ref string s)
    {
        // Разделяем строку на части по символу '#'
        string[] parts = s.Split('#');

        // Если есть хотя бы две части, возвращаем вторую часть (адрес электронной почты)
        if (parts.Length >= 2)
        {
            s = parts[1].Trim(); // Обновляем исходную строку, убирая лишние пробелы
            return parts[1].Trim();
        }

        // В противном случае, возвращаем пустую строку (или можно выбрать другое значение по умолчанию)
        return string.Empty;
    }

    public static void CompareSongs() {
         List<Song> songs = new List<Song>();
        for (int i = 0; i < 4; i++)
        {
            Song song = new Song();
            song.Name = $"Песня {i + 1}";
            song.Author = $"Исполнитель {i + 1}";

            // Связываем с предыдущей песней (кроме первой песни)
            if (i > 0)
            {
                song.Prev = songs[i - 1];
            }

            songs.Add(song);
        }

        // Выводим информацию о каждой песне
        foreach (var song in songs)
        {
            song.PrintInfo();
        }

        // Сравниваем первую и вторую песню в списке
        bool areEqual = songs[0].Equals(songs[1]);
        Console.WriteLine($"Первая и вторая песни {(areEqual ? "равны" : "не равны")}");
    }


}