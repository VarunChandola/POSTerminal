using System.Linq;
using NUnit.Framework;
using POSTerminal;

namespace POSTerminalTests
{
    public class PointOfSalesTerminalTests
    {
        [TestCase("ABCDABA", 13.25)]
        [TestCase("CCCCCCC", 6.00)]
        [TestCase("ABCD", 7.25)]
        public void Test1(string inputs, double expectedPrice)
        {
            IPointOfSalesTerminal engine = new PointOfSalesTerminal(new TestPricingRepository());
            engine.StartSession();
            foreach (var productCode in inputs.Select(@char =>  @char.ToString()))
            {
                engine.ScanProduct(productCode);
            }
            
            Assert.That(engine.CalculateTotal(), Is.EqualTo(expectedPrice));
            engine.EndSession();
        }
    }
}