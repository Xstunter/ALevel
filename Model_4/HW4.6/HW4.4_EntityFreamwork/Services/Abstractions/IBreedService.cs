using HW4._4_EntityFreamwork.Data.Entities;
using HW4._4_EntityFreamwork.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Services.Abstractions
{
    public interface IBreedService
    {
        Task<int> AddBreed();
        Task<Breed> GetBreed(int id);
        Task<int> UpdateBreed(int id);
        Task DeleteBreed(int id);
    }
}
