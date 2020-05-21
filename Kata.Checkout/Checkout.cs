using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    public class Checkout
    {
        public IList<Item> ScannedItems { get; }

        public Checkout()
        {
            ScannedItems = new List<Item>();
        }

        public decimal Total()
        {
            return ScannedItems.Sum(i => i.UnitPrice);
        }
        public void Scan(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            ScannedItems.Add(item);
        }
    }

}
