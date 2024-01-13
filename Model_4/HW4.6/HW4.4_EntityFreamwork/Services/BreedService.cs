using HW4._4_EntityFreamwork.Data.Entities;
using HW4._4_EntityFreamwork.DbModels;
using HW4._4_EntityFreamwork.Repositories;
using HW4._4_EntityFreamwork.Repositories.Abstractions;
using HW4._4_EntityFreamwork.Services.Abstractions;
using System;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Services
{
    public class BreedService : IBreedService
    {
        private readonly IBreedRepository _breedRepository;
        public BreedService(IBreedRepository breedRepository)
        {
            _breedRepository = breedRepository;
        }

        public async Task<int> AddBreed()
        {
            return await _breedRepository.AddBreedAsync();
        }

        public async Task DeleteBreed(int id)
        {
            await _breedRepository.DeleteBreedAsync(id);
        }

        public async Task<Breed> GetBreed(int id)
        {
            var breed = await _breedRepository.GetBreedAsync(id);

            if (breed == null)
            {
                return null!;
            }

            return new Breed()
            {
                Id = breed.Id,
                BreedName = breed.BreedName
            };
        }

        public async Task<int> UpdateBreed(int id)
        {
            return await _breedRepository.UpdateBreedAsync(id);
        }
    }
}
