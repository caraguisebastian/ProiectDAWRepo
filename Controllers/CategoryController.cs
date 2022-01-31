using Microsoft.AspNetCore.Mvc;
using ProiectDAW.DTO;
using ProiectDAW.Services.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var result = await _categoryService.Get();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById(Guid id)
        {
            var result = await _categoryService.GetById(id);
            return Ok(result);
        }


        [HttpPost]
        public ActionResult<CategoryDTO> Post([FromForm] CategoryDTO category)
        {

            _categoryService.Create(category);

            return Ok(category);
        }

        [HttpPut]
        public ActionResult<CategoryDTO> Put([FromForm] CategoryDTO category)
        {
            _categoryService.Update(category);
            return Ok(category);
        }


        [HttpDelete("{id}")]
        public ActionResult<CategoryDTO> Delete(Guid id)
        {
            _categoryService.Delete(id);
            return Ok(id);
        }
    }
}
