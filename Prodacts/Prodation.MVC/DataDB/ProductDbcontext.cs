using Microsoft.EntityFrameworkCore;
using Prodation.MVC.Models;

namespace Prodation.MVC.DataDB
{
    public class ProductDbcontext  : DbContext
    { 

        public ProductDbcontext(DbContextOptions<ProductDbcontext> options) : base( options)
        {

        }
        public DbSet<Products> Products { get; set; }

        
    }
}
