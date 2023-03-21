using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOtomation.Models.Classes
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
    }
}