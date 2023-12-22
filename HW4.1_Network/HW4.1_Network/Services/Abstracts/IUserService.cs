using HW4._1_Network.Models;
using HW4._1_Network.Models.Requests;
using HW4._1_Network.Models.Response;
using System.Threading.Tasks;

namespace HW4._1_Network.Services.Abstracts
{
    public interface IUserService
    {
        public Task<ReqresUserResponse> GetUserById(int id);
        public Task<UserResponse> CreateUser(string name, string job);
        public Task<UserResponse> UpdateUser(string name, string job);
        public Task<UserResponse> UpdateUserJob(string name, string job);
        public Task<UserResponse> DeleteUser(string name);
    }
}
