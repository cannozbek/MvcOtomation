namespace MvcOtomation.Models.Classes
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }

        public Invoice Invoice { get; set; }
    }
}