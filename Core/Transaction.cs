using System;

namespace Core
{
    public class Transaction
    {
        public string Description { get; set; } = "";
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public bool IsIncome { get; set; }

        public override string ToString()
        {
            return $"Description: {Description}, Amount: {Amount}, Date: {Date}, Income: {IsIncome}";
        }
    }
}