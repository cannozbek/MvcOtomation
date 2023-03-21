using System.Collections.Generic;

namespace MvcOtomation.Models.Classes
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePice { get; set; }
        public bool State { get; set; }
        public string Photo { get; set; }

        public Category Category { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }


    }
}