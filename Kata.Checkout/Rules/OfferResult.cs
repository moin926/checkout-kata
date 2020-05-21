namespace Kata.Rules
{
    public class OfferResult
    {
        public string SKU { get; }

        public string Name { get; set; }

        public int Quantity { get; }

        public decimal TotalPrice { get; }

        public OfferResult(string sku, string name, int quantity, decimal totalPrice)
        {
            this.SKU = sku;
            this.Name = name;
            this.Quantity = quantity;
            this.TotalPrice = totalPrice;
        }
    }
}
