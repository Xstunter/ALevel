using HW4._4_EntityFreamwork.Data;
using HW4._4_EntityFreamwork.DbModels;
using HW4._4_EntityFreamwork.Repositories;
using HW4._4_EntityFreamwork.Repositories.Abstractions;
using HW4._4_EntityFreamwork.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> AddCategory()
        {
            return await _categoryRepository.AddCategoryAsync();
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            if (category == null)
            {
                return null!;
            }

            return new Category()
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
            };
        }

        public async Task<int> UpdateCategory(int id)
        {
            return await _categoryRepository.UpdateCategoryAsync(id);
        }
    }
}
