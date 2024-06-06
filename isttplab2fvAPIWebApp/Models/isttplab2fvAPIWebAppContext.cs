using Microsoft.EntityFrameworkCore;

namespace isttplab2fvAPIWebApp.Models
{
    public class isttplab2fvAPIWebAppContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Factory> Factories { get; set; }
        public virtual DbSet<FactoryProduct> FactoryProducts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ReqProduct> ReqProducts { get; set; }

        public isttplab2fvAPIWebAppContext(DbContextOptions<isttplab2fvAPIWebAppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
