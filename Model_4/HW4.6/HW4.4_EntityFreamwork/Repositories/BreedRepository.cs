using HW4._4_EntityFreamwork.Data;
using HW4._4_EntityFreamwork.Data.Entities;
using HW4._4_EntityFreamwork.DbModels;
using HW4._4_EntityFreamwork.Repositories.Abstractions;
using HW4._4_EntityFreamwork.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Repositories
{
    public class BreedRepository : IBreedRepository
    {
        private readonly AnimalsApplicationContext _dbContext;

        public BreedRepository(IDbContextWrapper<AnimalsApplicationContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddBreedAsync()
        {
            var breed = new BreedEntity()
            {
                Id = 1,
                BreedName = "ChyaHya",
                CategoryId = 1,
            };
            await _dbContext.Breeds.AddAsync(breed);
            await _dbContext.SaveChangesAsync();

            return breed.Id;
        }

        public async Task DeleteBreedAsync(int id)
        {
            var breed = _dbContext.Breeds.FirstOrDefault(x => x.Id == id);

            if (breed == null)
            {
                throw new ArgumentNullException($"Not found user with id:{id}!");
            }

            _dbContext.Breeds.Remove(breed);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<BreedEntity> GetBreedAsync(int id)
        {
            return await _dbContext.Breeds.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<int> UpdateBreedAsync(int id)
        {
            var breed = _dbContext.Breeds.FirstOrDefault(x => x.Id == id);

            if (breed == null)
            {
                throw new ArgumentNullException($"Not found user with id:{id}!");
            }

            breed.BreedName = "ZakZak";

            await _dbContext.SaveChangesAsync();

            return breed.Id;
        }
    }
}
