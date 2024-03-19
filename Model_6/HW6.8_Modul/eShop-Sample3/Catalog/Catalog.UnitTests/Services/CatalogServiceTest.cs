using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Catalog.Host.Models.Response;

namespace Catalog.UnitTests.Services
{
    public class CatalogServiceTest
    {
        private readonly ICatalogService _catalogService;

        private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
        private readonly Mock<ICatalogBrandRepository> _catalogBrandRepository;
        private readonly Mock<ICatalogTypeRepository> _catalogTypeRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CatalogService>> _logger;
        private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;

        public CatalogServiceTest()
        {
            _catalogItemRepository = new Mock<ICatalogItemRepository>();
            _catalogBrandRepository = new Mock<ICatalogBrandRepository>();
            _catalogTypeRepository = new Mock<ICatalogTypeRepository>();
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<CatalogService>>();
            _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();

            var dbContextTransaction = new Mock<IDbContextTransaction>();
            _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

            _catalogService = new CatalogService(_dbContextWrapper.Object, _logger.Object, _catalogItemRepository.Object, _catalogBrandRepository.Object, _catalogTypeRepository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetCatalogItemAsync_Success()
        {
            var testPageSize = 0;
            var testPageIndex = 4;
            var testTotalCount = 12;

            var pagingPaginatedItemSuccess = new PaginatedItems<CatalogItem>()
            {
                Data = new List<CatalogItem>()
                {
                    new CatalogItem
                    {
                        Name = "TestName",
                    },
                },
                TotalCount = testTotalCount,
            };

            var catalogItemSuccess = new CatalogItem()
            {
                Name = "TestName"
            };

            var catalogItemDtoSuccess = new CatalogItemDto()
            {
                Name = "TestName"
            };

            _catalogItemRepository.Setup(s => s.GetByPageAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize))).ReturnsAsync(pagingPaginatedItemSuccess);

            _mapper.Setup(s => s.Map<CatalogItemDto>(
                It.Is<CatalogItem>(i => i.Equals(catalogItemSuccess)))).Returns(catalogItemDtoSuccess);

            var result = await _catalogService.GetCatalogItemsAsync(testPageSize, testPageIndex);

            result.Should().NotBeNull();
            result?.Data.Should().NotBeNull();
            result?.Count.Should().Be(testTotalCount);
            result?.PageSize.Should().Be(testPageSize);
            result?.PageIndex.Should().Be(testPageIndex);
        }

        [Fact]

        public async Task GetCatalogItemAsync_Failed()
        {
            var testPageSize = 10000;
            var testPageIndex = 1000;

            _catalogItemRepository.Setup(s => s.GetByPageAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize))).Returns((Func<PaginatedItemsResponse<CatalogItemDto>>)null!);

            var result = await _catalogService.GetCatalogItemsAsync(testPageSize, testPageIndex);

            result.Should().BeNull();
        }

        [Fact]

        public async Task GetCatalogBrandsAsync_Success()
        {
            var testPageSize = 0;
            var testPageIndex = 4;
            var testTotalCount = 5;

            var pagingPaginatedBrandSuccess = new PaginatedItems<CatalogBrand>()
            {
                Data = new List<CatalogBrand>()
                {
                    new CatalogBrand
                    {
                        Brand = "TestBrand",
                    },
                },
                TotalCount = testTotalCount,
            };

            var catalogBrandSuccess = new CatalogBrand()
            {
                Brand = "TestBrand"
            };

            var catalogBrandDtoSuccess = new CatalogBrandDto()
            {
                Brand = "TestBrand"
            };

            _catalogBrandRepository.Setup(s => s.GetByPageAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize))).ReturnsAsync(pagingPaginatedBrandSuccess);

            _mapper.Setup(s => s.Map<CatalogBrandDto>(
                It.Is<CatalogBrand>(i => i.Equals(catalogBrandSuccess)))).Returns(catalogBrandDtoSuccess);

            var result = await _catalogService.GetCatalogBrandsAsync(testPageSize, testPageIndex);

            result.Should().NotBeNull();
            result?.Data.Should().NotBeNull();
            result?.Count.Should().Be(testTotalCount);
            result?.PageSize.Should().Be(testPageSize);
            result?.PageIndex.Should().Be(testPageIndex);
        }

        [Fact]

        public async Task GetCatalogBrandAsync_Failed()
        {
            var testPageSize = 10000;
            var testPageIndex = 1000;

            _catalogBrandRepository.Setup(s => s.GetByPageAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize))).Returns((Func<PaginatedItemsResponse<CatalogBrandDto>>)null!);

            var result = await _catalogService.GetCatalogBrandsAsync(testPageSize, testPageIndex);

            result.Should().BeNull();
        }

        [Fact]

        public async Task GetCatalogTypeAsync_Success()
        {
            var testPageSize = 0;
            var testPageIndex = 3;
            var testTotalCount = 4;

            var pagingPaginatedTypeSuccess = new PaginatedItems<CatalogType>()
            {
                Data = new List<CatalogType>()
                {
                    new CatalogType
                    {
                        Type = "TestType",
                    },
                },
                TotalCount = testTotalCount,
            };

            var catalogTypeSuccess = new CatalogType()
            {
                Type = "TestType"
            };

            var catalogTypeDtoSuccess = new CatalogTypeDto()
            {
                Type = "TestType"
            };

            _catalogTypeRepository.Setup(s => s.GetByPageAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize))).ReturnsAsync(pagingPaginatedTypeSuccess);

            _mapper.Setup(s => s.Map<CatalogTypeDto>(
                It.Is<CatalogType>(i => i.Equals(catalogTypeSuccess)))).Returns(catalogTypeDtoSuccess);

            var result = await _catalogService.GetCatalogTypesAsync(testPageSize, testPageIndex);

            result.Should().NotBeNull();
            result?.Data.Should().NotBeNull();
            result?.Count.Should().Be(testTotalCount);
            result?.PageSize.Should().Be(testPageSize);
            result?.PageIndex.Should().Be(testPageIndex);
        }

        [Fact]

        public async Task GetCatalogTypeAsync_Failed()
        {
            var testPageSize = 10000;
            var testPageIndex = 1000;

            _catalogTypeRepository.Setup(s => s.GetByPageAsync(
                It.Is<int>(i => i == testPageIndex),
                It.Is<int>(i => i == testPageSize))).Returns((Func<PaginatedItemsResponse<CatalogTypeDto>>)null!);

            var result = await _catalogService.GetCatalogTypesAsync(testPageSize, testPageIndex);

            result.Should().BeNull();
        }
    }
}