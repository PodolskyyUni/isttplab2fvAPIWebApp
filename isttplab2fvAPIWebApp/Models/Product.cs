﻿using System;
using System.Collections.Generic;

namespace isttplab2fvAPIWebApp.Models
{


    public partial class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public string ProductDescription { get; set; } = null!;

        public int MarketPrice { get; set; }

        public virtual ICollection<FactoryProduct> FactoryProducts { get; set; } = new List<FactoryProduct>();

        public virtual ICollection<ReqProduct> ReqProducts { get; set; } = new List<ReqProduct>();
    }
}