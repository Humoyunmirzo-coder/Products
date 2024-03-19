using Microsoft.AspNetCore.Mvc;
using Prodation.MVC.DataDB;
using Prodation.MVC.Models;
using Prodation.MVC.Models.DbModel;

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
            var product = _dbcontext.ProductDB.ToList();
            List<Products> products = new List<Products>();
            if (product != null)
            {
                foreach (var productlist in product)
                {
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
                return View(products);

            }
            return View(products);
        }
        [HttpGet]
        public IActionResult Create(Products  products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = new ProductDB()
                    {
                        Id = products.Id,
                        Prise= products.Prise,
                        Name = products.Name,
                        Country = products.Country,
                        DateTime= products.DateTime,
                        Description = products.Description,
                      

                    };
                    _dbcontext.ProductDB.Add(employee);

                    _dbcontext.SaveChanges();
                    TempData["successMessage"] = "Product created successfully !";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model date is not valid!";
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
        public IActionResult Edit(int Id)
        {
            var products= _dbcontext.ProductDB.SingleOrDefault(x => x.Id == Id);
            try
            {
                if (products != null)
                {
                    var productData = new Products()
                    {
                        Id = products.Id,
                        Prise = products.Prise,
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
                    var productData = new ProductDB()
                    {
                        Id = products.Id,
                        Prise = products.Prise,
                        Name = products.Name,
                        Country = products.Country,
                        DateTime = products.DateTime,
                        Description = products.Description,

                    };
                    _dbcontext.ProductDB.Update(productData);
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
            var products = _dbcontext.ProductDB.SingleOrDefault(x => x.Id == Id);
            try
            {
                if (products != null)
                {
                    var productsData = new Products()
                    {
                        Id = products.Id,
                        Prise = products.Prise,
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
                var product = _dbcontext.ProductDB.SingleOrDefault(x => x.Id == products.Id);
                if (product != null)
                {
                    _dbcontext.ProductDB.Remove(product);
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


    }
}
