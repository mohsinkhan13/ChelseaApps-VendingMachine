namespace ChelseaApps.VendingMachine.Shared.DataModels
{
    public class Product
    {
        public string ProductNumber { get; set; }
        public string ProductTitle { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
