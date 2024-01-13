using HW4._4_EntityFreamwork.Data;
using HW4._4_EntityFreamwork.Data.Entities;
using HW4._4_EntityFreamwork.DbModels;
using HW4._4_EntityFreamwork.Models;
using HW4._4_EntityFreamwork.Repositories.Abstractions;
using HW4._4_EntityFreamwork.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;

        public PetService(
            IPetRepository petRepository) 
        {
            _petRepository = petRepository;
        }
        public async Task<int> AddPet()
        {
            return await _petRepository.AddPetAsync();
        }

        public async Task DeletePet(int id)
        {
            await _petRepository.DeletePetAsync(id);
        }
        public async Task<Pet> GetPet(int id)
        {
            var pet = await _petRepository.GetPetAsync(id);

            if (pet == null)
            {
                return null!;
            }

            return new Pet()
            {
                Id = pet.Id,
                Name = pet.Name,
                Age = pet.Age,
                BreedId = pet.BreedId,
                LocationId = pet.LocationId,
                CategotyId = pet.CategotyId
            };
        }

        public async Task<int> UpdatePet(int id)
        {
            return await _petRepository.UpdatePetAsync(id);
        }
        public async Task<IList<GroupedPetInfo>> GetGroupedPetsInfo()
        {
            return await _petRepository.GetGroupedPetsInfoAsync();
        }
    }
}
