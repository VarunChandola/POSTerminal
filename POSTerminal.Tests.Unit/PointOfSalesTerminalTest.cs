using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using POSTerminal;
using POSTerminal.DataModels;
using POSTerminal.Exceptions;
using POSTerminal.Repositories;

namespace POSTerminalTests
{
    public class PointOfSalesTerminalTests
    {
        [Test]
        public async Task ScanProduct_ForAnyProductCode_GetsProductUsingProductCodeFromProductRepository()
        {
            const string dummyProductCode = "D";
            var dummyProduct = new Product(dummyProductCode, 54);
            var stubRepositoryMock = new Mock<IProductRepository>();
            stubRepositoryMock.Setup(repository => repository.GetProductByCode(It.IsAny<string>()))
                .Returns(Task.FromResult(dummyProduct));
            var stubRepository = stubRepositoryMock.Object;

            var terminal = new PointOfSalesTerminal(stubRepository);
            await terminal.ScanProductAsync(dummyProductCode);

            stubRepositoryMock.Verify(repository => repository.GetProductByCode(dummyProductCode), Times.Once,
                "Product repository was called incorrectly on scanning");
        }

        [Test]
        public void ScanProduct_WithNonExistentProductCode_ThrowsProductNotFoundException()
        {
            var stubRepository = GetFakeRepository().Object;

            var terminal = new PointOfSalesTerminal(stubRepository);

            Assert.ThrowsAsync<ProductNotFoundException>(() => terminal.ScanProductAsync("E"),
                "Did not throw expected error for invalid Product Code");
        }

        [TestCase("ABCDABA", 13.25)]
        [TestCase("CCCCCCC", 6.00)]
        [TestCase("ABCD", 7.25)]
        public async Task CalculateTotal_AfterScanningProducts_ReturnsExpectedPrice(string inputs, double expectedPrice)
        {
            var stubRepository = GetFakeRepository().Object;
            var terminal = new PointOfSalesTerminal(stubRepository);

            foreach (var productCode in inputs.Select(@char => @char.ToString()))
            {
                await terminal.ScanProductAsync(productCode);
            }

            var calculatedTotal = terminal.CalculateTotal();

            Assert.That(calculatedTotal, Is.EqualTo(expectedPrice), "The calculated total was incorrect");
        }

        [Test]
        public void CalculateTotal_WithoutScanningProducts_ReturnsZero()
        {
            var stubRepository = GetFakeRepository().Object;
            var terminal = new PointOfSalesTerminal(stubRepository);

            var calculatedTotal = terminal.CalculateTotal();

            Assert.That(calculatedTotal, Is.Zero, "The calculated total was not zero");
        }

        private static Mock<IProductRepository> GetFakeRepository()
        {
            var pricing = new Dictionary<string, Product>
            {
                {"A", new Product("A", 1.25, new BulkPricing(3, 3))},
                {"B", new Product("B", 4.25)},
                {"C", new Product("C", 1, new BulkPricing(6, 5))},
                {"D", new Product("D", 0.75)}
            };

            var fakeRepository = new Mock<IProductRepository>();
            fakeRepository.Setup(repository => repository.GetProductByCode(It.IsAny<string>()))
                .Returns((string productCode) => Task.FromResult(pricing.GetValueOrDefault(productCode, null)));
            return fakeRepository;
        }
    }
}