namespace cs_labs.lab9;

using System;

class Song
{
    private string name;
    private string author;
    private Song prev;

    // Конструктор без параметров
    public Song()
    {
        name = "Unknown";
        author = "Unknown";
        prev = null;
    }

    // Конструктор с параметрами – название и автор песни, указатель на предыдущую песню инициализировать null.
    public Song(string songName, string songAuthor, Song previousSong)
    {
        name = songName;
        author = songAuthor;
        prev = previousSong;
    }

    // Конструктор с параметрами – название, автор песни, предыдущая песня.
    public Song(string songName, string songAuthor)
    {
        name = songName;
        author = songAuthor;
        prev = null;
    }

    // Метод для заполнения поля name
    public void SetName(string songName)
    {
        name = songName;
    }

    // Метод для заполнения поля author
    public void SetAuthor(string songAuthor)
    {
        author = songAuthor;
    }

    // Метод для заполнения поля prev
    public void SetPrev(Song previousSong)
    {
        prev = previousSong;
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

class Program
{
    static void Main()
    {
        // Использование конструктора без параметров
        Song mySong = new Song();
        mySong.PrintInfo();
    }
}
