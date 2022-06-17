using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        public MySqlContext() { }

        public DbSet<EmailLog> EmailLogs { get; set; }
    }
}
