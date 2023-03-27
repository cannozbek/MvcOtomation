using System;
using System.ComponentModel.DataAnnotations;

namespace MvcOtomation.Models.Classes
{
    public class SalesTransaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int Piece { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }

        public int CurrentId { get; set; }
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }
        public virtual Current Current { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Product Product { get; set; }
    }
}