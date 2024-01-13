using HW4._4_EntityFreamwork.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Repositories.Abstractions
{
    public interface ICategoryRepository
    {
        Task<int> AddCategoryAsync();
        Task<CategoryEntity> GetCategoryAsync(int id);
        Task<int> UpdateCategoryAsync(int id);
        Task DeleteCategoryAsync(int id);
    }
}
