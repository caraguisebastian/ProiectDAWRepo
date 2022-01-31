using Microsoft.AspNetCore.Mvc;
using ProiectDAW.DTO;
using ProiectDAW.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var result = await _productService.Get();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(Guid id)
        {
            var result = await _productService.GetById(id);
            return Ok(result);
        }


        [HttpPost]
        public ActionResult<ProductDTO> Post([FromForm] ProductDTO product)
        {

            _productService.Create(product);

            return Ok(product);
        }

        [HttpPut]
        public ActionResult<ProductDTO> Put([FromForm] ProductDTO product)
        {
            _productService.Update(product);
            return Ok(product);
        }


        [HttpDelete("{id}")]
        public ActionResult<ProductDTO> Delete(Guid id)
        {
            _productService.Delete(id);
            return Ok(id);
        }
    }
}
