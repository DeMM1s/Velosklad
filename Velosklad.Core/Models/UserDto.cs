using Velosklad.Domain.Models;

namespace Velosklad.Core.Models
{
    public class UserDto
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string Login { get; set; }

        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
