using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace isttplab2fvAPIWebApp.Models
{

    public partial class Factory
    {
        public int Id { get; set; }
        public string Adress { get; set; } = null!;
        public string Maintenance { get; set; } = null!;
        public string FactoryName { get; set; } = null!;

        public virtual ICollection<FactoryProduct> FactoryProducts { get; set; } = new List<FactoryProduct>();

    }
}