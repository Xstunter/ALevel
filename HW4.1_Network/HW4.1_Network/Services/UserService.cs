using HW4._1_Network.Config;
using HW4._1_Network.Services.Abstracts;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using HW4._1_Network.Models;
using HW4._1_Network.Models.Requests;
using HW4._1_Network.Models.Response;

namespace HW4._1_Network.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ApiOption _options;
        private readonly string _userApi = "api/users/";
        public UserService(IInternalHttpClientService httpClientService, IOptions<ApiOption> options)
        {
            _httpClientService = httpClientService;
            _options = options.Value;
        }

        public async Task<UserResponse> CreateUser(string name, string job)
        {
           var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
           $"{_options.Host}{_userApi}",
           HttpMethod.Post,
           new UserRequest()
           {
               Job = job,
               Name = name
           });

           return result;
        }

        public async Task<UserResponse> DeleteUser(string name)
        {
            var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
                $"{_options.Host}{_userApi}{name}",
                HttpMethod.Delete);

            return result;
        }

        public async Task<ReqresUserResponse> GetUserById(int id)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<ReqresUserResponse>, object>($"{_options.Host}{_userApi}{id}", HttpMethod.Get);

            return result?.Data;
        }
        public async Task<UserResponse> UpdateUser(string name, string job)
        {
            var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
                $"{_options.Host}{_userApi}",
                HttpMethod.Put,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });

            return result;
        }

        public async Task<UserResponse> UpdateUserJob(string name, string job)
        {

            var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
            $"{_options.Host}{_userApi}{name}",
            new HttpMethod("PATCH"),
            new UserRequest()
            {
                Job = job,
            });

            return result;
        }
    }
}
