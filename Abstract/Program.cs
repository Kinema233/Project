//Це Абстрактна фабрика библиотекы FunLib

using System;

// Абстрактний клас для представлення книги
public abstract class Book
{
    public abstract void Display();
}

// Клас для представлення книги про FunLib
public class FunLibBook : Book
{
    private string title;
    private string author;

    public FunLibBook(string title, string author)
    {
        this.title = title;
        this.author = author;
    }

    public override void Display()
    {
        Console.WriteLine($"FunLib Book: {title} by {author}");
    }
}

// Абстрактний клас для представлення автора
public abstract class Author
{
    public abstract void Info();
}

// Клас для представлення автора FunLib
public class FunLibAuthor : Author
{
    private string name;

    public FunLibAuthor(string name)
    {
        this.name = name;
    }

    public override void Info()
    {
        Console.WriteLine($"FunLib Author: {name}");
    }
}

// Абстрактна фабрика
public abstract class LibraryFactory
{
    public abstract Book CreateBook(string title, string author);
    public abstract Author CreateAuthor(string name);
}

// Фабрика для FunLib
public class FunLibFactory : LibraryFactory
{
    public override Book CreateBook(string title, string author)
    {
        return new FunLibBook(title, author);
    }

    public override Author CreateAuthor(string name)
    {
        return new FunLibAuthor(name);
    }
}

// Клієнтський код
class Program
{
    static void Main()
    {
        // Створюємо фабрику FunLib
        LibraryFactory factory = new FunLibFactory();

        // Створюємо книгу та автора за допомогою фабрики
        Book book = factory.CreateBook("C# Basics", "John Doe");
        Author author = factory.CreateAuthor("Jane Smith");

        // Виводимо інформацію про книгу та автора
        book.Display();
        author.Info();

        Console.ReadLine();
    }
}