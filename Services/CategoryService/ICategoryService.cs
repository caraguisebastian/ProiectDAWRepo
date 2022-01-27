using ProiectDAW.DTO;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services.CategoryService
{
    public interface ICategoryService
    {
        CategoryDTO Create(CategoryDTO user);
        Task<List<CategoryDTO>> Get();
        Task<CategoryDTO> GetById(Guid id);
        Category Update(CategoryDTO user);
        Guid Delete(Guid id);
    }
}
