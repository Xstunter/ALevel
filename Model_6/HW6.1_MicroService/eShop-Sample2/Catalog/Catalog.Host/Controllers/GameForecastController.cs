using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameForecastController : ControllerBase
    {
        private static readonly string[] Games = new[]
        {
        "PathOfExile", "CsGo", "CallDuty", "Chess", "BattleField", "Dota",
        "Diablo", "MarvelSnap", "CrusaderKings"
        };

        [HttpGet (Name = "Test")]
        public string[] Get()
        {
            return Games;
        }
    }
}
