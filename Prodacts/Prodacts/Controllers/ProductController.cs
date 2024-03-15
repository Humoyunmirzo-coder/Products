using Aplication.Repository;
using Domain.Entity;
using Domain.Model;
using Domain.Model.ProdactDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json.Serialization;

namespace Prodacts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
         private readonly IRepository _repository;
        private readonly IDistributedCache _redis;

        public ProductController(IRepository repository, IDistributedCache redis)
        {
            _repository = repository;
            _redis = redis;
        }

        [HttpGet]
        public async Task<ResponseModel< IEnumerable< ProductBaseDto>>> GetAllAysnce()
        {

            IEnumerable<ProductBaseDto> products;
            products = ( await  _repository.GetAllAsync() )
                .Select( x => new ProductBaseDto {

                    Id = x.Id,
                    Prise = x.Prise,
                    Name = x.Name,
                    Country = x.Country,
                    DateTime = x.DateTime,
                    Description = x.Description

                });
            
            return new ResponseModel<IEnumerable<ProductBaseDto>>( products );
        }
        [HttpGet]
        public async Task < ResponseModel<ProductBaseDto>> GetById( int Id)
        {
            Products products = await _repository.GetByIdAsync(Id);

            var productdto = new ProductBaseDto
            {
                Id = Id,
                Prise = products.Prise,
                Name = products.Name,
                Country = products.Country,
                DateTime = products.DateTime,
                Description = products.Description

            };
            return new (productdto);
        }

        [HttpPost]
        public async Task< ResponseModel<ProductBaseDto> > CreateAsync( Products productBaseDto)
        {
            Products productDto = new()
            {
                Id= productBaseDto.Id,
               Prise= productBaseDto.Prise,
               Name = productBaseDto.Name,
               Country = productBaseDto.Country,
               DateTime = productBaseDto.DateTime,
               Description = productBaseDto.Description

            };
            Products productEntity= await _repository.CreateAsync(productDto);
            var entityDto = new ProductBaseDto()
            {
                Id = productEntity.Id,
                Prise = productEntity.Prise,
                Name = productEntity.Name,
                Country = productEntity.Country,
                DateTime = productEntity.DateTime,
                Description = productEntity.Description

            };

            return new (entityDto);

        }



    }

}
