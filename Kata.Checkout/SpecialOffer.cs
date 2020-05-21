using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public interface IPriceRule
    {
        string SKU { get; }

        int Quantity { get; }

        decimal OfferPrice { get; }

        string Name { get; }

        bool Apply(Item item, IEnumerable<Item> items);
    }

    public class QuantityForSpecialOffer : IPriceRule
    {
        public QuantityForSpecialOffer(string sku, string name, int quantity, decimal offerPrice)
        {
            this.SKU = sku;
            this.Name = name;
            this.Quantity = quantity;
            this.OfferPrice = offerPrice;
        }

        public string SKU { get; }

        public string Name { get; set; }

        public int Quantity { get; }

        public decimal OfferPrice { get;  }
                
        public bool Apply(Item item, IEnumerable<Item> items)
        {
            return items.Count(s => s.SKU == item.SKU) % Quantity == 0;
        }
    }

    public class PriceRuleResult
    {
        public string SKU { get; }

        public string Name { get; set; }

        public int Quantity { get; }

        public decimal TotalPrice { get; }

        public PriceRuleResult(string sku, string name, int quantity, decimal totalPrice)
        {
            this.SKU = sku;
            this.Name = name;
            this.Quantity = quantity;
            this.TotalPrice = totalPrice;
        }
    }
}
