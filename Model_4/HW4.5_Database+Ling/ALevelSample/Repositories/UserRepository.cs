using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<string> AddUserAsync(string firstName, string lastName)
    {
        var user = new UserEntity()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = firstName,
            LastName = lastName
        };

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user.Id;
    }

    public async Task<string> UpdateUserAsync(string id, string firstName, string lastName)
    {
        var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
        {
            throw new ArgumentNullException($"Not found user with id:{id}!");
        }

        user.FirstName = firstName;
        user.LastName = lastName;

        await _dbContext.SaveChangesAsync();

        return user.Id;
    }

    public async Task DeleteUserAsync(string id)
    {
        var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
        {
            throw new ArgumentNullException($"Not found user with id:{id}!");
        }

        _dbContext.Users.Remove(user);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<UserEntity?> GetUserAsync(string id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == id);
    }
}