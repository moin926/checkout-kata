using System.Collections.Generic;

namespace Kata.Rules
{
    /// <summary>
    /// The IOffer interface allows implementation of various offers with varying complexity.
    /// It can account for 2 for 1 type offers (see implamented QuantityForOffer class) and offers including multiple SKUs by altering the SKU property type to a collection.
    /// </summary>
    public interface IOffer
    {
        string SKU { get; }

        int Quantity { get; }

        decimal OfferPrice { get; }

        string Name { get; }

        bool Apply(Item item, IEnumerable<Item> items);
    }
}
