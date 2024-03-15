using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Repository
{
    public  interface IRepository
    {
        Task<Products> CreateAsync(Products products);
        Task<bool> UpdateAsync(Products products);
        Task<bool> DeleteAsync(int Id);
        Task<Products> GetByIdAsync(int Id);
        Task<IEnumerable<Products>> GetAllAsync();
    }
}
