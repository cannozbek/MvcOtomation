using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOtomation.Models.Classes
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePice { get; set; }
        public bool State { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Photo { get; set; }

        public Category Category { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }


    }
}