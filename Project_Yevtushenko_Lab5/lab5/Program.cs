using Core;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Лабораторна робота №5\n");

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

        //dictionary
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

        // 6. JSON
        Console.WriteLine("\nJSON");

        string jsonPath = "data.json";

        // збереження
        using (FileStream fs = new FileStream(jsonPath, FileMode.Create))
        {
            JsonSerializer.Serialize(fs, manager.GetAll(), new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

        // завантаження
        using (FileStream fs = new FileStream(jsonPath, FileMode.Open))
        {
            var loaded = JsonSerializer.Deserialize<List<TransactionDTO>>(fs);

            if (loaded != null)
            {
                foreach (var t in loaded)
                {
                    Console.WriteLine($"{t.Description} - {t.Amount}");
                }
            }
        }

        // 7. XML
        Console.WriteLine("\nXML");

        var xml = new XDocument(
            new XElement("Transactions",
                manager.GetAll()
                    .Where(t => t.Amount > 100)
                    .Select(t =>
                        new XElement("Transaction",
                            new XElement("Description", t.Description),
                            new XElement("Amount", t.Amount)
                        )
                    )
            )
        );

        xml.Save("data.xml");

        Console.WriteLine("XML файл створено");

        // 8. IDisposable
        Console.WriteLine("\nIDisposable");

        using (var logger = new ResourceManager("log.txt"))
        {
            logger.Log("Програма запущена");
            logger.Log("Дані оброблено");
        }

        Console.WriteLine("Лог записано");

        // 9. TRY-CATCH
        Console.WriteLine("\nTRY-CATCH");

        try
        {
            using (FileStream fs = new FileStream("data.json", FileMode.Open))
            {
                var data = JsonSerializer.Deserialize<List<TransactionDTO>>(fs);

                if (data != null)
                {
                    foreach (var t in data)
                    {
                        Console.WriteLine($"{t.Description} - {t.Amount}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }
}