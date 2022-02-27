using Microsoft.EntityFrameworkCore;

namespace Backend_1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<DeliveryTypes> DeliveryTypes { get; set; }
        public DbSet<OrderLines> OrderLines { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<UserAddresses> UserAddresses { get; set; }
        public DbSet<UserHashes> UserHashes { get; set; }



    }
}
