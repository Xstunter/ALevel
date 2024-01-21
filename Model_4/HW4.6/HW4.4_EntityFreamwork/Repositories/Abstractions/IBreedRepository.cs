using HW4._4_EntityFreamwork.Data.Entities;
using HW4._4_EntityFreamwork.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Repositories.Abstractions
{
    public interface IBreedRepository
    {
        Task<int> AddBreedAsync();
        Task<BreedEntity> GetBreedAsync(int id);
        Task<int> UpdateBreedAsync(int id);
        Task DeleteBreedAsync(int id);
    }
}
