using HW4._4_EntityFreamwork.Data;
using HW4._4_EntityFreamwork.Data.Entities;
using HW4._4_EntityFreamwork.Repositories.Abstractions;
using HW4._4_EntityFreamwork.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AnimalsApplicationContext _dbContext;
        public CategoryRepository(IDbContextWrapper<AnimalsApplicationContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddCategoryAsync()
        {
            var category = new CategoryEntity()
            {
                Id = 1,
                CategoryName = "Wolf"
            };

            await _dbContext.Categoties.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category.Id;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = _dbContext.Categoties.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                throw new ArgumentNullException($"Not found user with id:{id}!");
            }

            _dbContext.Categoties.Remove(category);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<CategoryEntity> GetCategoryAsync(int id)
        {
            return await _dbContext.Categoties.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<int> UpdateCategoryAsync(int id)
        {
            var category = _dbContext.Categoties.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                throw new ArgumentNullException($"Not found user with id:{id}!");
            }

            category.CategoryName = "Dog";

            await _dbContext.SaveChangesAsync();

            return category.Id;
        }
    }
}
