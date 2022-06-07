using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponAPI.Model.Context
{
    public class MySqlContext : DbContext
    {

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        public MySqlContext() { }

        public DbSet<Product> Products { get; set; }
    }
}
