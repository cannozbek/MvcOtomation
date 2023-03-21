using System.Collections.Generic;

namespace MvcOtomation.Models.Classes
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }

        public Department Department { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}