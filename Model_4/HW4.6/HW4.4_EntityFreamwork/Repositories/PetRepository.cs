using HW4._4_EntityFreamwork.Data;
using HW4._4_EntityFreamwork.Data.Entities;
using HW4._4_EntityFreamwork.DbModels;
using HW4._4_EntityFreamwork.Models;
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
    public class PetRepository : IPetRepository
    {
        private readonly AnimalsApplicationContext _dbContext;
        public PetRepository(IDbContextWrapper<AnimalsApplicationContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }
        public async Task<int> AddPetAsync()
        {
            var pet = new PetEntity()
            {
                Id = 1,
                Name = "Boby",
                Age = 3,
                CategotyId = 1,
                BreedId = 1,
                LocationId = 1
            };
            await _dbContext.Pets.AddAsync(pet);
            await _dbContext.SaveChangesAsync();

            return pet.Id;
        }

        public async Task DeletePetAsync(int id)
        {
            var pet = _dbContext.Pets.FirstOrDefault(x => x.Id == id);

            if (pet == null)
            {
                throw new ArgumentNullException($"Not found user with id:{id}!");
            }

            _dbContext.Pets.Remove(pet);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<PetEntity> GetPetAsync(int id)
        {
            return await _dbContext.Pets.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<int> UpdatePetAsync(int id)
        {
            var pet = _dbContext.Pets.FirstOrDefault(x => x.Id == id);

            if (pet == null)
            {
                throw new ArgumentNullException($"Not found user with id:{id}!");
            }

            pet.Name = "Boby2";

            await _dbContext.SaveChangesAsync();

            return pet.Id;
        }

        public async Task<IList<GroupedPetInfo>> GetGroupedPetsInfoAsync()
        {
            return await _dbContext.Pets
                .Where(x => x.Age > 3 && x.Location.LocationName == "Ukraine")
                .GroupBy(p => new { CategoryName = p.Category.CategoryName, BreedName = p.Breed.BreedName })
                .Select(groupedPets => new GroupedPetInfo
                    {
                        CategoryName = groupedPets.Key.CategoryName,
                        BreedName = groupedPets.Key.BreedName,
                        Count = groupedPets.Count()
                    })
                .ToListAsync();
        }
    }
}
