namespace Velosklad.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

        public Order()
        {
        }
    }
}
