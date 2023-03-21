using System;
using System.Collections.Generic;

namespace MvcOtomation.Models.Classes
{
    public class Invoice
    {
        public int Id { get; set; }
        public char SerialNo { get; set; }
        public string OrderNo { get; set; }
        public DateTime Date { get; set; }
        public string TaxAdminstration { get; set; }
        public DateTime Time { get; set; }
        public string Submitter { get; set; }
        public string Receiver { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}