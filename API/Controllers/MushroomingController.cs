using Application.DTOs.MushroomingDTOs;
using Application.ServicesInterfaces;
using Domain.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MushroomingController : ControllerBase
    {
        private readonly IMushroomingService _mushroomingService;

        public MushroomingController(IMushroomingService mushroomingService)
        {
            _mushroomingService = mushroomingService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] QueryParameters parameters)
        {
            var response = await _mushroomingService.GetMultipleAsync(parameters, m => m.Location, m => m.User, m => m.CollectedMushrooms);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mushroomingService.GetByIdAsync(id, m => m.Location, m => m.User, m => m.CollectedMushrooms);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Create([FromBody] CreateMushroomingDto dto)
        {
            var response = await _mushroomingService.CreateAsync(dto);
            if (!response.Success)
                return BadRequest(response.Message);


            return Ok(response.Data);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMushroomingDto dto)
        {
            var response = await _mushroomingService.UpdateAsync(id, dto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mushroomingService.DeleteAsync(id);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Message);
        }
    }
}
