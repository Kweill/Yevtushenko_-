using System;
using Core;

class Program
{
    static void Main()
    {
        Console.WriteLine("OS Version: " + Environment.OSVersion);
        Console.WriteLine("Memory used: " + GC.GetTotalMemory(false));

        Category category = new Category
        {
            Id = 1,
            Name = "Food",
            Type = "Expense"
        };

        Transaction transaction = new Transaction
        {
            Description = "Buy pizza",
            Amount = 12.5,
            Date = DateTime.Now,
            IsIncome = false
        };

        UserAccount account = new UserAccount
        {
            OwnerName = "Kyrylo",
            Balance = 1000,
            IsActive = true
        };

        Console.WriteLine("\nCategory:");
        Console.WriteLine(category);

        Console.WriteLine("\nTransaction:");
        Console.WriteLine(transaction);

        Console.WriteLine("\nAccount:");
        Console.WriteLine(account);
    }
}