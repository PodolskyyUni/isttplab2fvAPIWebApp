using System;
using System.Collections.Generic;
namespace isttplab2fvAPIWebApp.Models

{
    public partial class Order 
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateOnly OrderDate { get; set; }
        public DateOnly ApprComplDate { get; set; }
        public int OrderPrice { get; set; }
        public virtual Client Client { get; set; } = null!;
        public virtual ICollection<ReqProduct> ReqProducts { get; set; } = new List<ReqProduct>();
    }
}
