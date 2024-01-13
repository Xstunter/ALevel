using HW4._4_EntityFreamwork.Data.Entities;
using HW4._4_EntityFreamwork.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Repositories.Abstractions
{
    public interface IPetRepository
    {
        Task<int> AddPetAsync();
        Task<PetEntity> GetPetAsync(int id);
        Task<int> UpdatePetAsync(int id);
        Task DeletePetAsync(int id);
        Task<IList<GroupedPetInfo>> GetGroupedPetsInfoAsync();
    }
}
