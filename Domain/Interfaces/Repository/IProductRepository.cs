using Domain.Dto;
using Domain.Models;
using Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductResponse>> GetAsync(string nameFilter, int page, int pageSize);
        Task<Product> CreateAsync(ProductCreateDto dto);
        Task<string> DeleteAsync(string id);
    }
}
