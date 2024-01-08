using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HW4._1_Network.Services.Abstracts
{
    public interface IInternalHttpClientService
    {
        public Task SendAsync<TPage>(string url);
    }
}
