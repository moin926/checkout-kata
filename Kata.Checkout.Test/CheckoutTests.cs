using System;
using Xunit;

namespace Kata.Test
{
    public class CheckoutTests
    {
        private readonly Item itemA99 = new Item
        {
            SKU = "A99",
            Name = "Apple",
            UnitPrice = 0.50m
        };
        private readonly Item itemB15 = new Item
        {
            SKU = "B15",
            Name = "Biscuits",
            UnitPrice = 0.30m
        };
        private readonly Item itemC40 = new Item
        {
            SKU = "C40",
            Name = "Orange",
            UnitPrice = 0.60m
        };

        [Fact]
        public void Scan_Items_Are_Added_To_Collection()
        {
            var expected = 3;

            var checkout = new Checkout();
            checkout.Scan(itemA99);
            checkout.Scan(itemB15);
            checkout.Scan(itemC40);

            Assert.Equal(expected, checkout.ScannedItems.Count);
        }

        [Fact]
        public void Null_Scanned_Item_Throws_ArgumentNullException()
        {
            var checkout = new Checkout();
  
            var exception = Assert.Throws<ArgumentNullException>("item", () => checkout.Scan(null));

            Assert.NotNull(exception);
        }

        [Fact]
        public void Zero_Total_For_No_Scanned_Items()
        {
            var expected = 0m;

            var checkout = new Checkout();

            var total = checkout.Total();

            Assert.Equal(expected, total);
        }

        [Fact]
        public void Total_From_Scanned_Items()
        {
            var expected = 0.50m + 0.30m + 0.60m;

            var checkout = new Checkout();
            checkout.Scan(itemA99);
            checkout.Scan(itemB15);
            checkout.Scan(itemC40);

            var total = checkout.Total();

            Assert.Equal(expected, total);
        }

    }
}
