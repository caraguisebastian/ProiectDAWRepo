using ProiectDAW.Models;
using ProiectDAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Repositories.ProductRepository
{
    public interface IProductRepository: IGenericRepository<Product>
    {
    }
}
