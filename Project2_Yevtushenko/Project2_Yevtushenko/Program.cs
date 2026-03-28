using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== LAB 2 ===\n");


        // 1. Struct 

        Console.WriteLine("1. Struct test:");

        Price price = new Price { Value = 100 };

        ChangePrice(price);

        Console.WriteLine("Price after method: " + price.Value);


        // 2. Boxing / Unboxing


        Console.WriteLine("\n2. Boxing / Unboxing:");

        object obj = 5;
        int num = (int)obj;
        Console.WriteLine("Value: " + num);


        // 3. Performance test

        Console.WriteLine("\n3. Performance test:");

        var stopwatch = new Stopwatch();

        ArrayList arrayList = new ArrayList();
        stopwatch.Start();

        for (int i = 0; i < 1_000_000; i++)
        {
            arrayList.Add(i);
        }

        stopwatch.Stop();
        Console.WriteLine("ArrayList time: " + stopwatch.ElapsedMilliseconds + " ms");

        stopwatch.Reset();
        List<int> list = new List<int>();

        stopwatch.Start();

        for (int i = 0; i < 1_000_000; i++)
        {
            list.Add(i);
        }

        stopwatch.Stop();
        Console.WriteLine("List<int> time: " + stopwatch.ElapsedMilliseconds + " ms");

        // 4. collection of objects

        Console.WriteLine("\n4. Transactions list:");

        List<Transaction> transactions = new List<Transaction>
        {
            new Transaction { Description = "Food", Amount = 50, Date = DateTime.Now, IsIncome = false },
            new Transaction { Description = "Salary", Amount = 2000, Date = DateTime.Now, IsIncome = true },
            new Transaction { Description = "Taxi", Amount = 150, Date = DateTime.Now, IsIncome = false },
            new Transaction { Description = "Gift", Amount = 500, Date = DateTime.Now, IsIncome = true },
            new Transaction { Description = "Coffee", Amount = 30, Date = DateTime.Now, IsIncome = false },
            new Transaction { Description = "Shop", Amount = 300, Date = DateTime.Now, IsIncome = false },
            new Transaction { Description = "Bonus", Amount = 800, Date = DateTime.Now, IsIncome = true },
            new Transaction { Description = "Game", Amount = 400, Date = DateTime.Now, IsIncome = false },
            new Transaction { Description = "Fuel", Amount = 600, Date = DateTime.Now, IsIncome = false },
            new Transaction { Description = "Freelance", Amount = 1200, Date = DateTime.Now, IsIncome = true }
        };

        foreach (var t in transactions)
        {
            Console.WriteLine(t);
        }


        // 5. linq where 
        
        Console.WriteLine("\n5. Transactions > 500:");

        var filtered = transactions.Where(t => t.Amount > 500);

        foreach (var t in filtered)
        {
            Console.WriteLine(t);
        }

        // 6. licq sort (OrderBy)

        Console.WriteLine("\n6. Sorted:");

        var sorted = transactions
            .OrderBy(t => t.Amount)
            .ThenBy(t => t.Description);

        foreach (var t in sorted)
        {
            Console.WriteLine(t);
        }

        // 7. linq select

        Console.WriteLine("\n7. Descriptions:");

        var names = transactions.Select(t => t.Description);

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        // 8. linq first

        Console.WriteLine("\n8. Find transaction > 1500:");

        var found = transactions.FirstOrDefault(t => t.Amount > 1500);

        if (found != null)
        {
            Console.WriteLine(found);
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }


    // Метод для проверки struct
    static void ChangePrice(Price p)
    {
        p.Value = 999;
    }
}