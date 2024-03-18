using Microsoft.EntityFrameworkCore;
using Prodation.MVC.Models.DbModel;

namespace Prodation.MVC.DataDB
{
    public class ProductDbcontext  : DbContext
    { 

        public ProductDbcontext(DbContextOptions<ProductDbcontext> options) : base()
        {

        }
        public DbSet<ProductDB> ProductDB { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       }
    }
}
