namespace POSTerminal.DataModels
{
    public record Product(string Code, double UnitPrice, BulkPricing? BulkPricing = null);
}