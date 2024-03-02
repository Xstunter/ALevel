using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
    {
        private readonly ICatalogBrandRepository _catalogTypeRepository;

        public CatalogTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogItemRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogTypeRepository = catalogItemRepository;
        }

        public Task<int?> Add(string type)
        {
            return ExecuteSafeAsync(() => _catalogTypeRepository.Add(type));
        }

        public Task Delete(int id)
        {
            return ExecuteSafeAsync(() => _catalogTypeRepository.Delete(id));
        }

        public Task Update(int id, string type)
        {
            return ExecuteSafeAsync(() => _catalogTypeRepository.Update(id, type));
        }
    }
}
