using ProiectDAW.DTO;
using ProiectDAW.Models;
using ProiectDAW.Repositories.CategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryDTO Create(CategoryDTO category)
        {
            Category _category = new Category
            {
                Id = category.Id,
                Name = category.Name
            };
            _categoryRepository.Create(_category);
            return category;
        }

        public Guid Delete(Guid id)
        {
            _categoryRepository.Delete(id);
            return id;
        }

        public async Task<List<CategoryDTO>> Get()
        {
            var allCategories = await _categoryRepository.GetAll();
            var categoriesDTO = new List<CategoryDTO>();
            foreach (Category category in allCategories)
            {
                CategoryDTO _category = new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name
                };
                categoriesDTO.Add(_category);
            }

            return categoriesDTO;
        }

        public async Task<CategoryDTO> GetById(Guid id)
        {
            var category = await _categoryRepository.FindByIdAsync(id);
            CategoryDTO result = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
            };
            return result;
        }

        public Category Update(CategoryDTO category)
        {
            Category _category = new Category
            {
                Id = category.Id,
                Name = category.Name
            };
            _categoryRepository.Update(_category);
            return _category;
        }
    }
}
