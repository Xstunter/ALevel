using HW4._1_Network.Config;
using HW4._1_Network.Services.Abstracts;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using HW4._1_Network.Models;
using HW4._1_Network.Models.Requests;
using HW4._1_Network.Models.Response;
using System;
using static System.Net.WebRequestMethods;

namespace HW4._1_Network.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ApiOption _options;
        private string _userApi;
        public UserService(IInternalHttpClientService httpClientService, IOptions<ApiOption> options)
        {
            _httpClientService = httpClientService;
            _options = options.Value;
        }

        public async Task GetPage()
        {
            _userApi = "api/users?page=2";
            await _httpClientService.SendAsync<ReqresPageResponse>($"{_options.Host}{_userApi}");
        }
       
        public async Task GetUser()
        {
            _userApi = "api/users/2";
            await _httpClientService.SendAsync<ReqresUserResponse>($"{_options.Host}{_userApi}");
        }
    }
}
