using System.Collections.Generic;

namespace Kata.Rules
{
    public interface IOffer
    {
        string SKU { get; }

        int Quantity { get; }

        decimal OfferPrice { get; }

        string Name { get; }

        bool Apply(Item item, IEnumerable<Item> items);
    }
}
