using Application.ServicesInterfaces;
using Domain.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStatisticsController : ControllerBase
    {
        private readonly IUserStatisticsService _userStatisticsService;

        public UserStatisticsController(IUserStatisticsService userStatisticsService)
        {
            _userStatisticsService = userStatisticsService;
        }

        [HttpGet("{userId}/mushroom-statistics")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetMushroomStatistics(Guid userId, [FromQuery] QueryParameters parameters)
        {
            var response = await _userStatisticsService.GetMushroomStatisticsAsync(userId, parameters);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpGet("{userId}/mushrooming-statistics")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetMushroomingStatistics(Guid userId, [FromQuery] QueryParameters parameters)
        {
            var response = await _userStatisticsService.GetMushroomingStatisticsAsync(userId, parameters);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }
    }
}
