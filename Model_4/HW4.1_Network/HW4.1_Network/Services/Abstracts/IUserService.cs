using HW4._1_Network.Models;
using HW4._1_Network.Models.Requests;
using HW4._1_Network.Models.Response;
using System.Threading.Tasks;

namespace HW4._1_Network.Services.Abstracts
{
    public interface IUserService
    {
        public Task GetPage();
        public Task GetUser();
    }
}
