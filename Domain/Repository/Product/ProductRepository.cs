using Domain.Dto;
using Domain.Models;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Common.Configurations;
using Microsoft.Extensions.Options;
using Domain.Models.Responses;

namespace Domain.Repository.Product
{
    public class ProductRepository:  IProductRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public ProductRepository(HttpClient httpClient, IOptions<RestfulApiOptions> options)
        {
            _httpClient = httpClient;
            _baseUrl = options.Value.BaseUrl;
        }

        public async Task<List<ProductResponse>> GetAsync(string nameFilter, int page, int pageSize)
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<ProductResponse>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                products = products
                    .Where(p => p.Name?.Contains(nameFilter, StringComparison.OrdinalIgnoreCase) == true)
                    .ToList();
            }

            return products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public async Task<Models.Product> CreateAsync(ProductCreateDto dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var response = await _httpClient.PostAsync(_baseUrl, new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Models.Product>(responseJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result!;
        }

        public async Task<string> DeleteAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Delete failed: {error}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<DeleteResponse>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result?.Message ?? "Deleted successfully.";
        }

    }
}
