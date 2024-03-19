using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Identity;
using System.Security.Claims;
using Infrastructure;

namespace Basket.Host.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
    [Route(ComponentDefaults.DefaultRoute)]
    public class BasketBffController : ControllerBase
    {

        private readonly ILogger<BasketBffController> _logger;

        public BasketBffController(ILogger<BasketBffController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Massege", Name = "LogMassege")]
        [AllowAnonymous]
        public IActionResult LogMassege(string massege)
        {

            _logger.LogInformation($"LogMassege: {massege}");

            return Ok();
        }


        [HttpGet("UserId", Name = "GetUserById")]
        public IActionResult GetUserId()
        {
            string userId = User.FindFirstValue("sub");

            _logger.LogInformation($"User Id: {userId}");

            return Ok();
        }
    }
}