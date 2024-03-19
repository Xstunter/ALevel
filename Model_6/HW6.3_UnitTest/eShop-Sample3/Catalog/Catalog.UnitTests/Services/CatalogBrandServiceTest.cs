using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Services;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Host.Repositories;
using FluentAssertions;
using NUnit.Framework.Internal;

namespace Catalog.UnitTests.Services
{
    public class CatalogBrandServiceTest
    {
        private readonly ICatalogBrandService _catalogBrandService;

        private readonly Mock<ICatalogBrandRepository> _catalogBrandRepository;
        private readonly Mock<ILogger<CatalogService>> _logger;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;

        private readonly CatalogBrand _testBrand = new CatalogBrand()
        {
            Brand = "TestBrand"
        };

        public CatalogBrandServiceTest()
        {
            _catalogBrandRepository = new Mock<ICatalogBrandRepository>();
            _logger = new Mock<ILogger<CatalogService>>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);
            _catalogBrandService = new CatalogBrandService(_dbContextWrapper.Object, _logger.Object, _catalogBrandRepository.Object);
        }

        [Fact]

        public async Task AddBrandAsync_Success()
        {
            var testResult = 1;

            _catalogBrandRepository.Setup(s => s.Add(
                It.IsAny<string>())).ReturnsAsync(testResult);

            var result = await _catalogBrandService.Add(_testBrand.Brand);

            result.Should().Be(testResult);
        }

        [Fact]

        public async Task AddBrandAsync_Failed()
        {
            int? testResult = null;

            _catalogBrandRepository.Setup(s => s.Add(
                It.IsAny<string>())).ReturnsAsync(testResult);

            var result = await _catalogBrandService.Add(_testBrand.Brand);

            result.Should().Be(testResult);
        }

        [Fact]

        public async Task DeleteBrandAsync_Success()
        {
            int testId = 1;

            _catalogBrandRepository.Setup(s => s.Delete(
                It.IsAny<int>())).Returns(Task.CompletedTask);

            Func<Task> deleteMethod = async () =>
                await _catalogBrandService.Delete(testId);

            await deleteMethod.Should().NotThrowAsync();

        }

        [Fact]

        public async Task DeleteBrandAsync_Failed()
        {
            int testId = 1000;

            _catalogBrandRepository.Setup(s => s.Delete(
                It.IsAny<int>())).ThrowsAsync(new Exception("Delete failed"));

            Func<Task> deleteMethod = async () =>
                await _catalogBrandService.Delete(testId);

            await deleteMethod.Should().ThrowAsync<Exception>().WithMessage("Delete failed");
        }

        [Fact]
        public async Task UpdateBrandAsync_Success()
        {
            int testId = 1;

            var _newTestBrand = new CatalogBrand()
            {
                Brand = "NewBrand"
            };

            _catalogBrandRepository.Setup(s => s.Update(
                It.IsAny<int>(),
                It.IsAny<string>())).Returns(Task.CompletedTask);

            Func<Task> updateMethod = async () =>
                await _catalogBrandService.Update(testId, _newTestBrand.Brand);

            await updateMethod.Should().NotThrowAsync();

        }

        [Fact]

        public async Task UpdateBrandAsync_Failed()
        {
            int testId = 1000;

            var _newTestBrand = new CatalogBrand()
            {
                Brand = "NewBrand"
            };

            _catalogBrandRepository.Setup(s => s.Update(
                It.IsAny<int>(),
                It.IsAny<string>())).ThrowsAsync(new Exception("Update failed"));

            Func<Task> updateMethod = async () =>
                await _catalogBrandService.Update(testId, _newTestBrand.Brand);

            await updateMethod.Should().ThrowAsync<Exception>().WithMessage("Update failed");
        }
    }
}
