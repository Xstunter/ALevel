using HW4._4_EntityFreamwork.Data.Entities;
using HW4._4_EntityFreamwork.DbModels;
using HW4._4_EntityFreamwork.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Services.Abstractions
{
    public interface IPetService
    {
        Task<int> AddPet();
        Task<Pet> GetPet(int id);
        Task<int> UpdatePet(int id);
        Task DeletePet(int id);
        Task<IList<GroupedPetInfo>> GetGroupedPetsInfo();
    }
}
