//Builder бібліотеки FunLib


using System;

namespace FunLib
{
    // Предметна область: книга
    public class Book
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public Author Author { get; set; }

        public void Display()
        {
            Console.WriteLine($"Назва: {Title}, Жанр: {Genre}, Автор: {Author.Name}");
        }
    }

    // Предметна область: автор
    public class Author
    {
        public string Name { get; set; }

        public void Display()
        {
            Console.WriteLine($"Автор: {Name}");
        }
    }

    // Будівельник для книги
    public class BookBuilder
    {
        private Book _book = new Book();

        public BookBuilder SetTitle(string title)
        {
            _book.Title = title;
            return this;
        }

        public BookBuilder SetGenre(string genre)
        {
            _book.Genre = genre;
            return this;
        }

        public BookBuilder SetAuthor(Author author)
        {
            _book.Author = author;
            return this;
        }

        public Book Build()
        {
            return _book;
        }
    }

    // Будівельник для автора
    public class AuthorBuilder
    {
        private Author _author = new Author();

        public AuthorBuilder SetName(string name)
        {
            _author.Name = name;
            return this;
        }

        public Author Build()
        {
            return _author;
        }
    }

    class Program
    {
        static void Main()
        {
            // Використання Builder для книги
            Book book = new BookBuilder()
                .SetTitle("Таємниці природи")
                .SetGenre("Наукова")
                .SetAuthor(new AuthorBuilder().SetName("Іван Іванов").Build())
                .Build();

            // Використання Builder для автора
            Author author = new AuthorBuilder()
                .SetName("Марія Петренко")
                .Build();

            // Виведення результату
            book.Display();
            author.Display();
        }
    }
}