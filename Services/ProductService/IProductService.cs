using ProiectDAW.DTO;
using ProiectDAW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services.ProductService
{
    public interface IProductService
    {
        ProductDTO Create(ProductDTO product);
        Task<List<ProductDTO>> Get();
        Task<ProductDTO> GetById(Guid id);
        Product Update(ProductDTO product);
        Guid Delete(Guid id);
    }
}
