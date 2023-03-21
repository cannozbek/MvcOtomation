using System.Collections.Generic;

namespace MvcOtomation.Models.Classes
{
    public class Current
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string Mail { get; set; }

        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}