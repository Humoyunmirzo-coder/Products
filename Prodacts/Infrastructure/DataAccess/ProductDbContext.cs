using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
    public  class ProductDbContext : DbContext
    {
        public ProductDbContext()  {    }
        public ProductDbContext (DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host= ::1; Port=5432 ;Database = Production; UserId = postgres; Password = 2244");
        }
        public DbSet<Products> Products { get; set; }

    }
}
