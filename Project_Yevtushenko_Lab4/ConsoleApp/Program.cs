using System;
using System.Collections.Generic;
using Core;

class Program
{
    static void Main()
    {
        Console.WriteLine("Лабораторна робота №4\n");

        // 1. арегація
        Console.WriteLine(" Арегація");

        List<Transaction> list = new List<Transaction>
        {
            new IncomeTransaction { Description = "Salary", Amount = 2000, Date = DateTime.Now },
            new ExpenseTransaction { Description = "Food", Amount = 100, Date = DateTime.Now }
        };

        TransactionManager manager = new TransactionManager(list);

        foreach (var t in manager)
        {
            Console.WriteLine(t.GetInfo());
        }

        // 2. поліморфізм
        Console.WriteLine("\n Поліморфізм");

        foreach (var t in list)
        {
            Console.WriteLine($"{t.GetTypeName()} | {t.GetInfo()}");
        }


        // 3. Інтерфейс
        Console.WriteLine("\n Інтерфейс");

        IPrintable[] items =
        {
            new IncomeTransaction { Description = "Bonus", Amount = 500 },
            new ExpenseTransaction { Description = "Taxi", Amount = 50 }
        };

        foreach (var item in items)
        {
            item.Print();
        }

        // 4. композиція
        Console.WriteLine("\n Композиція");

        Controller controller = new Controller();
        controller.ShowConfig();

        manager.AddToDictionary(1, new IncomeTransaction { Description = "Freelance", Amount = 1200 });

        var found = manager.FindById(1);

        if (found != null)
        {
            Console.WriteLine(found.GetInfo());
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }
}