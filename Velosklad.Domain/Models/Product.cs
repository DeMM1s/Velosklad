namespace Velosklad.Domain.Models
{
    public class Product
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public decimal Price { get; set; }

        public int Amount { get; set; }

        public Product(
            string name,
            decimal price,
            int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }
    }
}
