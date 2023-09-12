using App.Data.Abstract;
using App.Data.Entities;
using App.Data.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using App.WebAPI.DTOs;

namespace App.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<ProductEntity> _repository;
        private readonly IMapper _mapper;

        public ProductsController(IRepository<ProductEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var products = _repository.Get();

            if(products is null)
            {
                return NotFound();
            }
            return Ok(products);
        } 

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var product = _repository.Get(p => p.Id == id).FirstOrDefault();

            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductCreateDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var product = _mapper.Map<ProductEntity>(request);
                var result = _repository.Create(product);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ProductUpdateDto request)
        {
            if(request.Id != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var product = _mapper.Map<ProductEntity>(request);

                product.LastUpdatedAt = DateTime.UtcNow;
                var result = _repository.Update(id, product);

                return Ok(result);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            
            try
            {
                var product = _repository.Get(p => p.Id == id).FirstOrDefault();

                if (product is null) 
                { 
                    return NotFound();
                }
               
                var result = _repository.Delete(id);

                return Ok(result);
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

