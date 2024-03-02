using Catalog.Host.Data;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;

        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogItemRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogBrandRepository = catalogItemRepository;
        }

        public Task<int?> Add(string brand)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Add(brand));
        }

        public Task Delete(int id)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Delete(id));
        }

        public Task Update(int id, string brand)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Update(id, brand));
        }
    }
}
