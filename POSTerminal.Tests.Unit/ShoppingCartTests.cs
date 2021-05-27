using System.Linq;
using NUnit.Framework;
using POSTerminal;
using POSTerminal.DataModels;

namespace POSTerminalTests
{
    public class ShoppingCartTests
    {
        private const double DummyPrice = -1;

        [Test]
        public void NewCart_IsInitiallyEmpty()
        {
            var shoppingCart = new ShoppingCart();

            Assert.That(shoppingCart.Contents, Is.Empty);
        }

        [Test]
        public void AddToCart_ForNewProduct_AddsNewEntryToCart()
        {
            var product = new Product("Dummy Code", DummyPrice);
            var shoppingCart = new ShoppingCart();

            shoppingCart.Add(product);

            Assert.That(shoppingCart.Contents, Has.One.Items, "Cart should have exactly one element");
            Assert.That(shoppingCart.Contents.First(), Is.EqualTo(new ProductDetails(product, 1)),
                "Cart entries are incorrect");
        }

        [Test]
        public void AddToCart_ForRepeatedProduct_IncrementsQuantityForExistingEntryInCart()
        {
            var product = new Product("Dummy Code", DummyPrice);
            var shoppingCart = new ShoppingCart();

            shoppingCart.Add(product);
            shoppingCart.Add(product);

            Assert.Multiple(() =>
            {
                Assert.That(shoppingCart.Contents, Has.One.Items, "Cart should have exactly one element");
                Assert.That(shoppingCart.Contents.First(), Is.EqualTo(new ProductDetails(product, 2)),
                    "Cart entries are incorrect");
            });
        }
    }
}