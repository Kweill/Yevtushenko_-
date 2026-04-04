using System;
using System.Collections.Generic;
using System.Linq;
using Core;

class Program
{
    static void Main()
    {
        Console.WriteLine("LAB 3\n");
 
        // 1. Extension method

        double money = 123.456;
        Console.WriteLine("Money: " + money.ToCurrencyString());


        // 2. TransactionManager + List

        TransactionManager manager = new TransactionManager();

        manager.Add(new Transaction { Description = "Food", Amount = 50, Date = DateTime.Now, IsIncome = false });
        manager.Add(new Transaction { Description = "Salary", Amount = 2000, Date = DateTime.Now, IsIncome = true });
        manager.Add(new Transaction { Description = "Taxi", Amount = 150, Date = DateTime.Now, IsIncome = false });
        manager.Add(new Transaction { Description = "Game", Amount = 400, Date = DateTime.Now, IsIncome = false });

        Console.WriteLine("\n ALL TRANSACTIONS");
        Console.WriteLine("{0,-15} {1,-10} {2,-12} {3,-8}", "Desc", "Amount", "Date", "Income");

        foreach (var t in manager)
        {
            Console.WriteLine(t);
        }

        // 3. Dictionary

        manager.AddToDictionary(1, new Transaction { Description = "Bonus", Amount = 800, Date = DateTime.Now, IsIncome = true });

        var found = manager.FindById(1);

        if (found != null)
        {
            Console.WriteLine(found);
        }
        else
        {
            Console.WriteLine("Not found");
        }

        // 4. HashSet

        HashSet<string> tags1 = new HashSet<string> { "Food", "Taxi", "Game" };
        HashSet<string> tags2 = new HashSet<string> { "Food", "Fuel", "Game" };

        tags1.IntersectWith(tags2);

        Console.WriteLine("\nCOMMON TAGS");
        foreach (var tag in tags1)
        {
            Console.WriteLine(tag);
        }


        // 5. LINQ

        var filtered = manager.GetAll().Where(t => t.Amount > 100);

        Console.WriteLine("\nFILTERED (>100)");
        foreach (var t in filtered)
        {
            Console.WriteLine(t);
        }
    }
}