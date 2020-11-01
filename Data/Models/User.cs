using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
