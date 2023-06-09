﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOtomation.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1)]
        public string SerialNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string OrderNo { get; set; }
    
        public DateTime Date { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TaxAdminstration { get; set; }
        
        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string Time { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Submitter { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Receiver { get; set; }

        public decimal Amount { get; set; }

        public int InvoiceDetailsId { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}