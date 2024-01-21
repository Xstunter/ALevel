using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface IUserService
{
    Task<string> AddUser(string firstName, string lastName);
    Task<string> UpdateUser(string id, string firstName, string lastName);
    Task DeleteUser(string id);
    Task<User> GetUser(string id);
}