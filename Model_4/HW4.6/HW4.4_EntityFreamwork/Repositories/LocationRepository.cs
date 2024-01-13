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
    public class LocationRepository : ILocationRepository
    {
        private readonly AnimalsApplicationContext _dbContext;
        public LocationRepository(
            IDbContextWrapper<AnimalsApplicationContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddLocationAsync()
        {
            var location = new LocationEntity()
            {
                Id = 1,
                LocationName = "Kiev"
            };
            await _dbContext.Locations.AddAsync(location);
            await _dbContext.SaveChangesAsync();

            return location.Id;
        }

        public async Task DeleteLocationAsync(int id)
        {
            var location = _dbContext.Locations.FirstOrDefault(x => x.Id == id);

            if (location == null)
            {
                throw new ArgumentNullException($"Not found user with id:{id}!");
            }

            _dbContext.Locations.Remove(location);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<LocationEntity> GetLocationAsync(int id)
        {
            return await _dbContext.Locations.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<int> UpdateLocationAsync(int id)
        {
            var location = _dbContext.Locations.FirstOrDefault(x => x.Id == id);

            if (location == null)
            {
                throw new ArgumentNullException($"Not found user with id:{id}!");
            }

            location.LocationName = "Charkiv";

            await _dbContext.SaveChangesAsync();

            return location.Id;
        }
    }
}
