using AutoMapper;
using Catalog.Host.Configurations;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly ICatalogTypeRepository _catalogTypeRepository;
    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        ICatalogBrandRepository catalogBrandRepository,
        ICatalogTypeRepository catalogTypeRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _catalogBrandRepository = catalogBrandRepository;
        _catalogTypeRepository = catalogTypeRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedItemByBrandResponse<CatalogItemDto>> GetCatalogByBrandItemAsync(int pageSize, int pageIndex, string brand)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByBrandAsync(pageIndex, pageSize, brand);
            return new PaginatedItemByBrandResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                Brand = brand,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemByIdResponse<CatalogItemDto>> GetCatalogByIdItemAsync(int pageSize, int pageIndex, int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByIdAsync(pageIndex, pageSize, id);
            return new PaginatedItemByIdResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                Id = id,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemByTypeResponse<CatalogItemDto>> GetCatalogByTypeItemAsync(int pageSize, int pageIndex, string type)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByTypeAsync(pageIndex, pageSize, type);
            return new PaginatedItemByTypeResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                Type = type,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogBrandDto>> GetCatalogBrandsAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogBrandRepository.GetByPageAsync(pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogBrandDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogBrandDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByPageAsync(pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogTypeDto>> GetCatalogTypesAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogTypeRepository.GetByPageAsync(pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogTypeDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogTypeDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }
}