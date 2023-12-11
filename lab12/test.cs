namespace cs_labs.lab12;

class Program
{
    static void Books()
    {
        // Создаем экземпляры книг
        Book book1 = new Book("Book1", "Author1", "Publisher1");
        Book book2 = new Book("Book2", "Author2", "Publisher2");
        Book book3 = new Book("Book3", "Author3", "Publisher3");

        // Создаем контейнер для книг
        BookContainer bookContainer = new BookContainer();

        // Добавляем книги в контейнер
        bookContainer.AddBook(book2);
        bookContainer.AddBook(book1);
        bookContainer.AddBook(book3);

        Console.WriteLine("Books before sorting:");
        bookContainer.DisplayBooks();

        // Создаем делегаты для сравнения книг по разным полям
        BookComparer sortByTitle = (x, y) => x.Title.CompareTo(y.Title);
        BookComparer sortByAuthor = (x, y) => x.Author.CompareTo(y.Author);
        BookComparer sortByPublisher = (x, y) => x.Publisher.CompareTo(y.Publisher);

        // Сортируем книги по разным полям, используя делегаты
        bookContainer.SortBooks(sortByTitle);
        Console.WriteLine("\nBooks after sorting by title:");
        bookContainer.DisplayBooks();

        bookContainer.SortBooks(sortByAuthor);
        Console.WriteLine("\nBooks after sorting by author:");
        bookContainer.DisplayBooks();

        bookContainer.SortBooks(sortByPublisher);
        Console.WriteLine("\nBooks after sorting by publisher:");
        bookContainer.DisplayBooks();
    }
}
