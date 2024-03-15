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
        Task<bool> CreateAsync(Products products);
        Task<bool> UpdateAsync(int Id);
        Task<bool> DeleteAsync(int Id);
        Task<bool> GetByIdAsync(int Id);
        Task<IEnumerable<Products>> GetAllAsync();
    }
}
