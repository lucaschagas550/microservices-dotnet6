﻿using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class MySqlContext : DbContext
    {

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) {}
        public MySqlContext() {}

        public DbSet<Product> Products { get; set; }
    }
}
