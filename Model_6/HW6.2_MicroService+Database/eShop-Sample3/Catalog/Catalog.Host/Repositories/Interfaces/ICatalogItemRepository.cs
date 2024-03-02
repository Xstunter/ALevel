using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize);
    Task<PaginatedItems<CatalogItem>> GetByIdAsync(int pageSize, int pageIndex, int id);
    Task<PaginatedItems<CatalogItem>> GetByBrandAsync(int pageSize, int pageIndex, string brand);
    Task<PaginatedItems<CatalogItem>> GetByTypeAsync(int pageSize, int pageIndex, string type);

    Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task Update(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task Delete(int id);
}