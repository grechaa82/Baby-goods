namespace Baby_goods.Common.Models
{
    public class ShoppingCartItem
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Product Product { get; }
        public int Quantity { get; private set; }
        public decimal Price { get; }

        public ShoppingCartItem(
            Guid userId,
            Product product, 
            Guid id = new Guid(), 
            int quantity = 1)
        {
            Id = id;
            UserId = userId;
            Product = product;
            Quantity = quantity;
            Price = CalculatePrice();
        }

        public decimal CalculatePrice()
        {
            return Product.Price * Quantity;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException($"'{nameof(quantity)}' cannot be zero or less.");
            }

            Quantity = quantity;
        }
    }
}
