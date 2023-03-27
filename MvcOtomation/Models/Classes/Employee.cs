using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOtomation.Models.Classes
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Surname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Photo { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }


        public int SalesTransactionsId { get; set; }

        public virtual ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}