﻿using System;
using System.Collections.Generic;
namespace isttplab2fvAPIWebApp.Models
{
    public partial class FactoryProduct
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int FactoryId { get; set; }

        public int ProductionCost { get; set; }

        public int AmountProduced { get; set; }

        public virtual Factory Factory { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;
    }
}