using Aplication.Repository;
using Aplication.Service;
using Domain.Entity;
using Domain.Model;
using Domain.Model.ProdactDTO;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json.Serialization;

namespace Prodacts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
         private readonly IProductService _repository;
        private readonly ProductDbContext _context;


        public ProductController(IProductService repository, ProductDbContext context)
        {
            _repository = repository;
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAysnce()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }


        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int Id)
        {
            Products products = await _repository.GetByIdAsync(Id);

            if (products == null)
            {
                return NotFound();
            }

            var productdto = new ProductBaseDto
            {
                Id = products.Id,
                Prise = products.Prise,
                Name = products.Name,
                Country = products.Country,
                DateTime = products.DateTime,
                Description = products.Description
            };

            return Ok(new ResponseModel<ProductBaseDto>(productdto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Products productBaseDto)
        {
            if (productBaseDto == null)
            {
                return BadRequest();
            };

            if (productBaseDto.DateTime.Kind != DateTimeKind.Utc)
            {
                productBaseDto.DateTime = DateTime.SpecifyKind(productBaseDto.DateTime, DateTimeKind.Utc);
            }

            Products productDto = new Products
            {
                Prise = productBaseDto.Prise,
                Name = productBaseDto.Name,
                Country = productBaseDto.Country,
                DateTime = productBaseDto.DateTime,
                Description = productBaseDto.Description
            };

            Products productEntity = await _repository.CreateAsync(productDto);

            var entityDto = new ProductBaseDto()
            {
                Prise = productEntity.Prise,
                Name = productEntity.Name,
                Country = productEntity.Country,
                DateTime = productEntity.DateTime,
                Description = productEntity.Description
            };

            return Ok(new ResponseModel<ProductBaseDto>(entityDto));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete (int Id)
        {
              await _repository.DeleteAsync(Id);
            return Ok();
        }






    }

}
