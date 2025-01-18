using Application.DTOs.MushroomDTOs;
using Application.ServicesInterfaces;
using Domain.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MushroomController : ControllerBase
    {
        private readonly IMushroomService _mushroomService;

        public MushroomController(IMushroomService mushroomService)
        {
            _mushroomService = mushroomService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] QueryParameters parameters)
        {
            var response = await _mushroomService.GetAllMushroomsAsync(parameters);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _mushroomService.GetMushroomByIdAsync(id);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Create([FromBody] CreateMushroomDto dto)
        {
            var response = await _mushroomService.CreateMushroomAsync(dto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMushroomDto dto)
        {
            var response = await _mushroomService.UpdateMushroomAsync(id, dto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _mushroomService.DeleteMushroomAsync(id);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Message);
        }
    }
}
