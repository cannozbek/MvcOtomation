using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOtomation.Models.Classes
{
    public class Current
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage ="En fazla 30 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public string Surname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13, ErrorMessage = "En fazla 13 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public string City { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz...")]
        public string Mail { get; set; }

        public bool State { get; set; }
        public virtual ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}