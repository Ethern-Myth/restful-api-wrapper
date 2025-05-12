using Domain.Dto;
using Domain.Models;
using Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetProductsAsync(string nameFilter, int page, int pageSize);
        Task<Product> CreateProductAsync(ProductCreateDto dto);
        Task<string> DeleteProductAsync(string id);
    }
}
