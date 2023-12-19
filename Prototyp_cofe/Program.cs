// Модуль прототип для кав`ярня

using System;

// Абстрактный класс для создания напитков
abstract class Beverage
{
    public string Description { get; set; }

    public abstract double Cost();
}

// Конкретные классы напитков
class Espresso : Beverage
{
    public Espresso()
    {
        Description = "Эспрессо";
    }

    public override double Cost()
    {
        return 1.99;
    }
}

class Latte : Beverage
{
    public Latte()
    {
        Description = "Латте";
    }

    public override double Cost()
    {
        return 2.49;
    }
}

// Декоратор - абстрактный класс для добавления дополнительных опций
abstract class CondimentDecorator : Beverage
{
    public abstract new string Description { get; }
}

// Конкретные декораторы для добавления опций к напиткам
class Milk : CondimentDecorator
{
    private Beverage _beverage;

    public Milk(Beverage beverage)
    {
        _beverage = beverage;
    }

    public override string Description
    {
        get { return _beverage.Description + ", Молоко"; }
    }

    public override double Cost()
    {
        return _beverage.Cost() + 0.30;
    }
}

class Vanilla : CondimentDecorator
{
    private Beverage _beverage;

    public Vanilla(Beverage beverage)
    {
        _beverage = beverage;
    }

    public override string Description
    {
        get { return _beverage.Description + ", Ваниль"; }
    }

    public override double Cost()
    {
        return _beverage.Cost() + 0.50;
    }
}

// Пример использования
class Program
{
    static void Main()
    {
        // Заказ эспрессо с молоком и ванилью
        Beverage espresso = new Espresso();
        espresso = new Milk(espresso);
        espresso = new Vanilla(espresso);

        Console.WriteLine($"Напиток: {espresso.Description}");
        Console.WriteLine($"Цена: ${espresso.Cost()}");

        // Заказ латте с ванилью
        Beverage latte = new Latte();
        latte = new Vanilla(latte);

        Console.WriteLine($"Напиток: {latte.Description}");
        Console.WriteLine($"Цена: ${latte.Cost()}");

        Console.ReadLine();
    }
}