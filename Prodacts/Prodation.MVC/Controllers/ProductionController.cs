using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prodation.MVC.DataDB;
using Prodation.MVC.Models;

namespace Prodation.MVC.Controllers
{
    
    public class ProductionController : Controller
    {
        private readonly ProductDbcontext _dbcontext;

        public ProductionController(ProductDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var product = _dbcontext.Products.ToList();
            List<Products> products = new List<Products>();
            if (product != null)
            {
                foreach (var productlist in product)
                {
                    var productView = new Products()
                    {
                        Id = productlist.Id,
                        Name = productlist.Name,
                        Price = productlist.Price,
                        Country = productlist.Country,
                        DateTime = productlist.DateTime,
                        Description = productlist.Description,

                    };
                    products.Add(productView);
                }
                return View(products);

            }
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Create(   Products products)
        {
			if (products != null)
			{
				_dbcontext.Add(products);
			    _dbcontext.SaveChangesAsync();
                return View(products);
			}
            return View(products);
		
		}
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var products= _dbcontext.Products.SingleOrDefault(x => x.Id == Id);
            try
            {
                if (products != null)
                {
                    var productData = new Products()
                    {
                        Id = products.Id,
                        Price = products.Price,
                        Name = products.Name,
                        Country = products.Country,
                        DateTime = products.DateTime,
                        Description = products.Description,

                    };


                    return View(productData);

                }
                else
                {
                    TempData["errorMessage"] = $"Product detals not {Id}";
                    return RedirectToAction("index");
                }

            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("index");
            }

        }
        [HttpPost]
        public IActionResult Edit(Products  products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productData = new Products()
                    {
                        Id = products.Id,
                        Price = products.Price,
                        Name = products.Name,
                        Country = products.Country,
                        DateTime = products.DateTime,
                        Description = products.Description,

                    };
                    _dbcontext.Products.Update(productData);
                    _dbcontext.SaveChanges();
                    TempData["successMessage"] = "Product update successfully !";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model Data is invalid ";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var products = _dbcontext.Products.SingleOrDefault(x => x.Id == Id);
            try
            {
                if (products != null)
                {
                    var productsData = new Products()
                    {
                        Id = products.Id,
                        Price = products.Price,
                        Name = products.Name,
                        Country = products.Country,
                        DateTime = products.DateTime,
                        Description = products.Description,

                    };
                    return View(productsData);

                }
                else
                {
                    TempData["errorMessage"] = $"Product detals not {Id}";
                    return RedirectToAction("index");
                }

            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("index");
            }

        }
        [HttpPost]
        public IActionResult Delete(Products products)
        {
            try
            {
                var product = _dbcontext.Products.SingleOrDefault(x => x.Id == products.Id);
                if (product != null)
                {
                    _dbcontext.Products.Remove(product);
                    _dbcontext.SaveChanges();
                    TempData["errorMessage"] = "Employee Deleted Successfully";
                    return RedirectToAction("index");
                }
                else
                {
                    TempData["errorMessage"] = $"Product detals not  {product.Id}";
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (_dbcontext.Products == null)
            {
                return Problem("Entity set 'BookShopDbContext.Authors'  is null.");
            }
            var author = await _dbcontext.Products.FindAsync(id);
            if (author != null)
            {
                _dbcontext.Products.Remove(author);
            }

            await _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details( )
        {

            return View();
        }
        [HttpPost]
        public IActionResult Details (Products productview)
        {
            var product = _dbcontext.Products.ToList();
            List<Products> products = new List<Products>();

            return View(products);
     
        }







    }
}
