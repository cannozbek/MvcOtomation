using System;

namespace MvcOtomation.Models.Classes
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
    }
}