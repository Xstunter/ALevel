using HW4._4_EntityFreamwork.Data.Entities;
using HW4._4_EntityFreamwork.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Services.Abstractions
{
    public interface ILocationService
    {
        Task<int> AddLocation();
        Task<Location> GetLocation(int id);
        Task<int> UpdateLocation(int id);
        Task DeleteLocation(int id);
    }
}
