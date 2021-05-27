namespace POSTerminal.DataModels
{
    public class ScannedProductDetails
    {
        public int Qty { get; set; }
        public  Product Product { get; init; }
    }
}