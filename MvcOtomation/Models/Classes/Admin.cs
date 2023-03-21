﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOtomation.Models.Classes
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Username { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Password { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Authority { get; set; }
    }
}