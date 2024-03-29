using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>?> GetCatalogItemsAsync(int pageIndex, int pageSize);
    Task<PaginatedItemsResponse<CatalogBrandDto>?> GetCatalogBrandsAsync(int pageIndex, int pageSize);
    Task<PaginatedItemsResponse<CatalogTypeDto>?> GetCatalogTypesAsync(int pageIndex, int pageSize);
    Task<PaginatedItemByIdResponse<CatalogItemDto>> GetCatalogByIdItemAsync(int pageIndex, int pageSize, int id);
    Task<PaginatedItemByBrandResponse<CatalogItemDto>> GetCatalogByBrandItemAsync(int pageIndex, int pageSize, string brand);
    Task<PaginatedItemByTypeResponse<CatalogItemDto>> GetCatalogByTypeItemAsync(int pageIndex, int pageSize, string type);
}