using ProiectDAW.DTO;
using ProiectDAW.Models;
using ProiectDAW.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectDAW.Services.ProductService
{
    public class ProductService : IProductService
    {
        public IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ProductDTO Create(ProductDTO product)
        {
            Product _product = new Product
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price,
                Description = product.Description

            };
            _productRepository.Create(_product);
            return product;
        }

        public Guid Delete(Guid id)
        {
            _productRepository.Delete(id);
            return id;
        }

        public async Task<List<ProductDTO>> Get()
        {
            var allProducts = await _productRepository.GetAll();
            var productsDTO = new List<ProductDTO>();
            foreach (Product product in allProducts)
            {
                ProductDTO _product = new ProductDTO
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    Name = product.Name,
                    Stock = product.Stock,
                    Price = product.Price,
                    Description = product.Description
                };
                productsDTO.Add(_product);
            }

            return productsDTO;
        }

        public async Task<ProductDTO> GetById(Guid id)
        {
            var product = await _productRepository.FindByIdAsync(id);
            ProductDTO result = new ProductDTO
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price,
                Description = product.Description
            };
            return result;
        }

        public Product Update(ProductDTO product)
        {
            Product _product = new Product
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price,
                Description = product.Description
            };
            _productRepository.Update(_product);
            return _product;
        }
    }
}
