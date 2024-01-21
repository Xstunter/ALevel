using HW4._1_Network.Services.Abstracts;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Text.Json;

namespace HW4._1_Network.Services
{
    public class InternalHttpClientService : IInternalHttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;
        public InternalHttpClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task SendAsync<TPage>(string url)
        {
            using var clients = new HttpClient();
            clients.BaseAddress = new Uri(url);

            HttpResponseMessage result = await clients.GetAsync(url);

            if (result.IsSuccessStatusCode)
            {
                var resultContent = await result.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<TPage>(resultContent);
            }

        }
    }
}
