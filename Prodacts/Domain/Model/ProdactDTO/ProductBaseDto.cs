using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ProdactDTO
{
    public  class ProductBaseDto
    {
        public int Id { get; set; }
        public int Prise { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<Products> Products { get; set; }

    }
}
