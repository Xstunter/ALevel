using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogItems
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Id)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new CatalogItem
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price,
            AvailableStock = availableStock
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var item = _dbContext.CatalogItems.FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                throw new ArgumentNullException($"Not found item with id:{id}!");
            }

            _dbContext.CatalogItems.Remove(item);

            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return false;
        }
    }

    public async Task<bool> Update(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        try
        {
            var item = _dbContext.CatalogItems.FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                throw new ArgumentNullException($"Not found item with id:{id}!");
            }

            item.Name = name;
            item.Description = description;
            item.Price = price;
            item.AvailableStock = availableStock;
            item.CatalogBrandId = catalogBrandId;
            item.CatalogTypeId = catalogTypeId;
            item.PictureFileName = pictureFileName;

            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message);
            return false;
        }
    }

    public async Task<PaginatedItems<CatalogItem>> GetByIdAsync(int pageIndex, int pageSize, int id)
    {
        var totalItems = await _dbContext.CatalogItems
            .Where(i => i.Id == id)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Where(i => i.Id == id)
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Id)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogItem>> GetByBrandAsync(int pageIndex, int pageSize, string brand)
    {
        var totalItems = await _dbContext.CatalogItems
            .Where(i => i.CatalogBrand.Brand == brand)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Where(i => i.CatalogBrand.Brand == brand)
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Id)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogItem>> GetByTypeAsync(int pageIndex, int pageSize, string type)
    {
        var totalItems = await _dbContext.CatalogItems
            .Where(i => i.CatalogType.Type == type)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Where(i => i.CatalogType.Type == type)
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Id)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }
}