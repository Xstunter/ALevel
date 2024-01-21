using HW4._4_EntityFreamwork.Data.Entities;
using HW4._4_EntityFreamwork.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<int> AddCategory();
        Task<Category> GetCategory(int id);
        Task<int> UpdateCategory(int id);
        Task DeleteCategory(int id);
    }
}
