using System;
using System.Collections.Generic;

namespace isttplab2fvAPIWebApp.Models
{

    public partial class Client
    {
        public int Id { get; set; }

        public string ClientName { get; set; } = null!;

        public string Contacts { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}