//предметна область бібліотеки FunLib

using System;

// Інтерфейс для представлення книг
interface IBook
{
    void Display();
}

// Конкретні класи книг
class FantasyBook : IBook
{
    public void Display()
    {
        Console.WriteLine("Fantasy Book");
    }
}

class ScienceFictionBook : IBook
{
    public void Display()
    {
        Console.WriteLine("Science Fiction Book");
    }
}

// Фабрика для створення різних видів книг
class BookFactory
{
    public IBook CreateBook(string genre)
    {
        switch (genre.ToLower())
        {
            case "fantasy":
                return new FantasyBook();
            case "sciencefiction":
                return new ScienceFictionBook();
            default:
                throw new ArgumentException("Unknown genre");
        }
    }
}

// Приклад використання фабрики
class Program
{
    static void Main()
    {
        BookFactory bookFactory = new BookFactory();

        // Створюємо книгу жанру "Фентезі"
        IBook fantasyBook = bookFactory.CreateBook("fantasy");
        fantasyBook.Display();

        // Створюємо книгу жанру "Наукова фантастика"
        IBook scienceFictionBook = bookFactory.CreateBook("sciencefiction");
        scienceFictionBook.Display();
    }
}