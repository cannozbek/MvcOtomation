namespace MvcOtomation.Models.Classes
{
    public class SalesTransaction
    {
        public int Id { get; set; }
        public int Piece { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }

        public Current Current { get; set; }
        public Employee Employee { get; set; }
        public Product Product { get; set; }
    }
}