using Kata.Rules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Checkout
    {
        public List<Item> SKUs { get; }

        public List<IOffer> Offers { get; }

        /// <summary>
        /// Idividual SKUs can have multiple offers
        /// </summary>
        public List<OfferResult> AppliedOffers { get; }

        public Checkout(List<IOffer> rules)
        {
            SKUs = new List<Item>();            
            AppliedOffers = new List<OfferResult>();
            Offers = rules ?? new List<IOffer>();
        }

        public decimal Total()
        {
            // Apply totals to offers
            var total = AppliedOffers.Sum(i => i.TotalPrice);

            return total += NoneQualiyingTotal();
        }

        private decimal NoneQualiyingTotal()
        {
            var total = 0m;

            // Sum and total SKUs that don't qualify for offers
            var groupedSkus = SKUs.GroupBy(r => r.SKU);

            foreach (var sku in groupedSkus)
            {
                var skusRuleAppliedQty = AppliedOffers.Where(r => r.SKU == sku.Key).Sum(r => r.Quantity);
                var skuScannedQty = SKUs.Count(s => s.SKU == sku.Key);

                if (skuScannedQty > skusRuleAppliedQty)
                    total += sku.First().UnitPrice * (skuScannedQty - skusRuleAppliedQty);
            }

            return total;
        }

        public void Scan(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            SKUs.Add(item);

            var applied = Offers
                .Where(r => r.SKU == item.SKU)
                .Where(r => r.Apply(item, SKUs))
                .Select(r => new OfferResult(r.SKU, r.Name, r.Quantity, r.OfferPrice));

            AppliedOffers.AddRange(applied);            
        }
    }
}
