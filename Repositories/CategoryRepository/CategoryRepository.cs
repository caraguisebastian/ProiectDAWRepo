using ProiectDAW.Data;
using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories.CategoryRepository
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProiectDAWContext context) : base(context)
        {

        }
    }
}
