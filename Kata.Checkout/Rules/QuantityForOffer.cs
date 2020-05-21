using System.Collections.Generic;
using System.Linq;

namespace Kata.Rules
{
    public class QuantityForOffer : IOffer
    {
        public QuantityForOffer(string sku, string name, int quantity, decimal offerPrice)
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
}
