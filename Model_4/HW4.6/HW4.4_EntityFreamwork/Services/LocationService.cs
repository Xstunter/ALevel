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
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task<int> AddLocation()
        {
            return await _locationRepository.AddLocationAsync();
        }

        public async Task DeleteLocation(int id)
        {
            await _locationRepository.DeleteLocationAsync(id);
        }

        public async Task<Location> GetLocation(int id)
        {
            var location = await _locationRepository.GetLocationAsync(id);

            if (location == null)
            {
                return null!;
            }

            return new Location()
            {
                Id = location.Id,
                LocationName = location.LocationName
            };
        }

        public async Task<int> UpdateLocation(int id)
        {
            return await _locationRepository.UpdateLocationAsync(id);
        }
    }
}
