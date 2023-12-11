namespace cs_labs.lab8;

class Song
{
    private string name;
    private string author;
    private Song prev;

    public string Author {
        get => author;
        set => author = value;
    }

    public string Name {
        get => name;
        set => name = value;
    }

    public Song Prev {
        get => prev;
        set => prev = value;
    }


    // Метод для печати названия песни и ее исполнителя
    public void PrintInfo()
    {
        Console.WriteLine($"Название: {name}, Исполнитель: {author}");
    }

    // Метод для получения названия песни и ее исполнителя
    public string Title()
    {
        return $"{name} - {author}";
    }

    // Метод для сравнения двух объектов-песен
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Song otherSong = (Song)obj;
        return this.Title() == otherSong.Title();
    }
}
