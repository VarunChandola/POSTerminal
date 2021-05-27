namespace POSTerminal.DataModels
{
    public record Product (double UnitPrice, BulkPricing? BulkPricing = null);
}