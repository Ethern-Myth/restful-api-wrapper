using Domain.Dto;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Models.Responses.ProductResponse>> GetProductsAsync(string nameFilter, int page, int pageSize)
        {
            var results = await _repository.GetAsync(nameFilter, page, pageSize);
            return results;
        }

        public async Task<Models.Product> CreateProductAsync(ProductCreateDto dto)
        {
            var results = await _repository.CreateAsync(dto);
            return results;
        }

        public async Task<string> DeleteProductAsync(string id)
        {
            var results = await  _repository.DeleteAsync(id);
            return results;
        }
       
    }
}
