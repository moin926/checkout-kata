using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Checkout
    {
        public List<Item> SKUs { get; }

        public List<IPriceRule> PriceRules { get; }

        public List<PriceRuleResult> AppliedRules { get; }

        public Checkout(List<IPriceRule> rules)
        {
            SKUs = new List<Item>();            
            AppliedRules = new List<PriceRuleResult>();
            PriceRules = rules ?? new List<IPriceRule>();
        }

        public decimal Total()
        {
            return AppliedRules.Sum(i => i.TotalPrice);
        }

        public void Scan(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            SKUs.Add(item);

            var applied = PriceRules
                .Where(r => r.SKU == item.SKU)
                .Where(r => r.Apply(item, SKUs))
                .Select(r => new PriceRuleResult(r.SKU, r.Name, r.Quantity, r.OfferPrice));

            AppliedRules.AddRange(applied);            
        }
    }







}
