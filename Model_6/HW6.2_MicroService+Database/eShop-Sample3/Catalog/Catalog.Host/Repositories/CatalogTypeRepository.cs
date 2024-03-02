using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private ApplicationDbContext _dbContext;
        public CatalogTypeRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<int?> Add(string type)
        {
            var item = await _dbContext.AddAsync(new CatalogType
            {
                Type = type
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

        public async Task Delete(int id)
        {
            var item = _dbContext.CatalogTypes.FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                throw new ArgumentNullException($"Not found user with id:{id}!");
            }

            _dbContext.CatalogTypes.Remove(item);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<PaginatedItems<CatalogType>> GetByPageAsync(int pageIndex, int pageSize)
        {
            var totalItems = await _dbContext.CatalogTypes
            .LongCountAsync();

            var itemsOnPage = await _dbContext.CatalogTypes
                .OrderBy(c => c.Type)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<CatalogType>() { TotalCount = totalItems, Data = itemsOnPage };
        }

        public async Task Update(int id, string type)
        {
            var item = _dbContext.CatalogTypes.FirstOrDefault(t => t.Id == id);

            if (item == null)
            {
                throw new ArgumentNullException($"Not found user with id:{id}!");
            }

            item.Type = type;

            await _dbContext.SaveChangesAsync();
        }
    }
}
