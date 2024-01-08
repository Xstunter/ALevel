using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Data.Entities;

namespace ALevelSample.Repositories.Abstractions;

public interface IProductRepository
{
    Task<int> AddProductAsync(string name, double price);
    Task DeleteProductAsync(int id);
    Task<int> UpdateProductAsync(int id, string name, double price);
    Task<ProductEntity?> GetProductAsync(int id);
    Task<IList<ProductEntity>> GetPaginatedProductsAsync(int pageIndex, double price, string name);
}