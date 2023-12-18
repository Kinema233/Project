// реалізувати паттерн Singletone в FunLib

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

        // Приватний статичний екземпляр класу для реалізації Singleton
        private static FunLib instance;

        // Приватний конструктор для запобігання створенню нових екземплярів ззовні
        private FunLib() { }

        // Публічний метод для отримання єдиного екземпляра класу
        public static FunLib Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FunLib();
                }
                return instance;
            }
        }

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

            // Використання єдиного екземпляра бібліотеки за допомогою Singleton
            FunLib library = FunLib.Instance;

            // Додавання книг до бібліотеки, використовуючи клонування прототипів
            library.AddBook(prototypeManager["Programming"].Clone());
            library.AddBook(prototypeManager["Literature"].Clone());

            // Виведення всіх книг в бібліотеці
            library.DisplayBooks();
        }
    }
}