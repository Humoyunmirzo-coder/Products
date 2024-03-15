using Aplication.Service;
using Domain.Entity;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbcontext;

        public ProductService(ProductDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Products> CreateAsync(Products products)
        {
            await _dbcontext.Products.AddAsync(products);
            await _dbcontext.SaveChangesAsync();
            return products ;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            Products? products = await _dbcontext.Products.FindAsync(Id);
            if (products == null )
            {
                return false ;
            }
            _dbcontext.Remove( products );
                await _dbcontext.SaveChangesAsync();
            return true ;
        }

        public Task<IEnumerable<Products>> GetAllAsync()
        {
            IEnumerable<Products> products= _dbcontext.Products.Include(x=>x.Id).AsNoTracking().AsEnumerable();
            return Task.FromResult(products);
        }

        public async Task<Products> GetByIdAsync(int Id)
        {
            Products? products = await _dbcontext.Products.FindAsync(Id);
            return products;
        }

        public async Task<bool> UpdateAsync(Products products)
        {
            _dbcontext.Products.Update(products);
            var exsucutedRows = await _dbcontext.SaveChangesAsync();
            return exsucutedRows > 0;
        }
    }
}
