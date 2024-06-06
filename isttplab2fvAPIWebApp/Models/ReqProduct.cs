﻿using System;
using System.Collections.Generic;

namespace isttplab2fvAPIWebApp.Models

{
    public partial class ReqProduct 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ReqProductAmount { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
