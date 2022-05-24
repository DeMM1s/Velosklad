using Velosklad.Domain.Models;

namespace Velosklad.Core.Models
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
        //public ICollection<Order>? Orders { get; set; }
    }
}
