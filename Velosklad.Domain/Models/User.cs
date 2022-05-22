using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velosklad.Domain.Models
{
    public class User
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string Login { get; set; }

        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public User( string name,
                     string login,
                     string password,
                     ICollection<Order> orders)
        {
            Name = name;
            Login = login;
            Password = password;
            Orders = orders;
        }
    }
}
