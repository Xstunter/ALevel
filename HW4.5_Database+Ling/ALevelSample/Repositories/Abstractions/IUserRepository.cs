using System.Threading.Tasks;
using ALevelSample.Data.Entities;

namespace ALevelSample.Repositories.Abstractions;

public interface IUserRepository
{
    Task<string> AddUserAsync(string firstName, string lastName);
    Task<string> UpdateUserAsync(string id, string firstName, string lastName);
    Task DeleteUserAsync(string id);
    Task<UserEntity?> GetUserAsync(string id);
}