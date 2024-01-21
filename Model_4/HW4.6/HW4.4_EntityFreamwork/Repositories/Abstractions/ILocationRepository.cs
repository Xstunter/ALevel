using HW4._4_EntityFreamwork.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Repositories.Abstractions
{
    public interface ILocationRepository
    {
        Task<int> AddLocationAsync();
        Task<LocationEntity> GetLocationAsync(int id);
        Task<int> UpdateLocationAsync(int id);
        Task DeleteLocationAsync(int id);
    }
}
