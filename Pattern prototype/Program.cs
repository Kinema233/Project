// Реалізувати паттерн в FunLib


using System;
using System.Collections.Generic;

namespace FunLibNamespace
{
    // Абстрактний клас для представлення книги
    abstract class BookPrototype
    {
        public abstract BookPrototype Clone();
        public abstract void Display();
    }

    // Конкретний клас для книги про програмування
    class ProgrammingBook : BookPrototype
    {
        private string title;

        public ProgrammingBook(string title)
        {
            this.title = title;
        }

        public override BookPrototype Clone()
        {
            return new ProgrammingBook(title);
        }

        public override void Display()
        {
            Console.WriteLine($"Programming Book: {title}");
        }
    }

    // Конкретний клас для книги про літературу
    class LiteratureBook : BookPrototype
    {
        private string title;

        public LiteratureBook(string title)
        {
            this.title = title;
        }

        public override BookPrototype Clone()
        {
            return new LiteratureBook(title);
        }

        public override void Display()
        {
            Console.WriteLine($"Literature Book: {title}");
        }
    }

    // Клас для керування прототипами книг
    class BookPrototypeManager
    {
        private Dictionary<string, BookPrototype> prototypes = new Dictionary<string, BookPrototype>();

        public BookPrototype this[string key]
        {
            get { return prototypes[key].Clone(); }
            set { prototypes[key] = value; }
        }
    }

    // Клас бібліотеки, який використовує прототипи для створення книг
    class FunLib
    {
        private List<BookPrototype> books = new List<BookPrototype>();

        public void AddBook(BookPrototype book)
        {
            books.Add(book);
        }

        public void DisplayBooks()
        {
            foreach (var book in books)
            {
                book.Display();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            // Використання прототипів для створення книг та додавання їх до бібліотеки
            BookPrototypeManager prototypeManager = new BookPrototypeManager();

            prototypeManager["Programming"] = new ProgrammingBook("C# Programming");
            prototypeManager["Literature"] = new LiteratureBook("Classic Literature");

            FunLib library = new FunLib();

            // Додавання книг до бібліотеки, використовуючи клонування прототипів
            library.AddBook(prototypeManager["Programming"].Clone());
            library.AddBook(prototypeManager["Literature"].Clone());

            // Виведення всіх книг в бібліотеці
            library.DisplayBooks();
        }
    }
}