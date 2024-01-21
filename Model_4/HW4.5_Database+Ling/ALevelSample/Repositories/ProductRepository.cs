using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int> AddProductAsync(string name, double price)
    {
        var product = new ProductEntity()
        {
            Name = name,
            Price = price
        };

        var result = await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<int> UpdateProductAsync(int id, string name, double price)
    {
        var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            throw new ArgumentNullException($"Product with id:{id} not found");
        }

        product.Name = name;
        product.Price = price;

        await _dbContext.SaveChangesAsync();

        return id;
    }

    public async Task<ProductEntity?> GetProductAsync(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            throw new ArgumentNullException($"Product with id:{id} not found");
        }

        _dbContext.Products.Remove(product);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IList<ProductEntity>> GetPaginatedProductsAsync(int pageIndex, double price, string name)
    {
        return await _dbContext.Products
            .Where(x => x.Price == price || x.Name == name)
            .Skip(pageIndex * 20)
            .Take(20)
            .OrderByDescending(x => x.Name)
            .ToListAsync();
    }
}