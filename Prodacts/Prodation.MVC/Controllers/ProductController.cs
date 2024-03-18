using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Prodation.MVC.DataDB;
using Prodation.MVC.Models;

namespace Prodation.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbcontext _dbcontext;

        public ProductController(ProductDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var product = _dbcontext.ProductDB.ToList();
            List<Products> products = new List<Products>();
            if (product !=null)
            {
                foreach( var productlist in product) {
                    var productView = new Products()
                    {
                       Id = productlist.Id,
                       Name = productlist.Name,
                       Prise = productlist.Prise,
                       Country = productlist.Country,
                       DateTime = productlist.DateTime,
                       Description = productlist.Description,
                      
                    };
                    products.Add(productView);
                }
                return null;
            }
            return null;
        }
    }
}
