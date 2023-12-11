namespace cs_labs.lab12;

using System;
using System.Collections.Generic;

// Класс, представляющий книгу
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }

    // Конструктор книги
    public Book(string title, string author, string publisher)
    {
        Title = title;
        Author = author;
        Publisher = publisher;
    }

    public override string ToString()
    {
        return $"{Title} by {Author}, published by {Publisher}";
    }
}

// Делегат для сравнения книг
delegate int BookComparer(Book x, Book y);

// Класс, представляющий контейнер для книг
class BookContainer
{
    private List<Book> books = new List<Book>();

    // Добавление книги в контейнер
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    // Метод сортировки книг с использованием делегата
    public void SortBooks(BookComparer comparer)
    {
        books.Sort((x, y) => comparer(x, y));
    }

    // Вывод списка книг
    public void DisplayBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }
}
