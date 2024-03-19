﻿using Catalog.Host.Data.Entities;
using Catalog.Host.Data;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<PaginatedItems<CatalogBrand>> GetByPageAsync(int pageIndex, int pageSize);
        Task<int?> Add(string brand);
        Task Update(int id, string brand);
        Task Delete(int id);
    }
}
