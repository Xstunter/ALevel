using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogBrandDto>> GetCatalogBrandsAsync(int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogTypeDto>> GetCatalogTypesAsync(int pageSize, int pageIndex);
    Task<PaginatedItemByIdResponse<CatalogItemDto>> GetCatalogByIdItemAsync(int pageSize, int pageIndex, int id);
    Task<PaginatedItemByBrandResponse<CatalogItemDto>> GetCatalogByBrandItemAsync(int pageSize, int pageIndex, string brand);
    Task<PaginatedItemByTypeResponse<CatalogItemDto>> GetCatalogByTypeItemAsync(int pageSize, int pageIndex, string type);
}