using Catalog.Host.Data.Entities;
using Catalog.Host.Data;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<PaginatedItems<CatalogType>> GetByPageAsync(int pageIndex, int pageSize);
        Task<int?> Add(string type);
        Task Update(int id, string type);
        Task Delete(int id);
    }
}
