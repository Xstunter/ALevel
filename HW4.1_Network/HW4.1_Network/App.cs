using HW4._1_Network.Services.Abstracts;
using System.Threading.Tasks;

namespace HW4._1_Network
{
    internal sealed class App
    {
        private readonly IUserService _userService;

        public App(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Start()
        {
            var user = await _userService.GetUserById(2);  //GET
            var userInfo = await _userService.CreateUser("Bogdan", "Programist"); //POST
            var updareUserJob = await _userService.UpdateUserJob("Bogdan", "Enginner"); //PATCH
            var updateInfo = await _userService.UpdateUser("Dmytro", "Manager"); //PUT
            var deleteUser = await _userService.DeleteUser("Bogdan"); //DELETE
        }
    }
}
