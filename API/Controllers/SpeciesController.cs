using Application.DTOs.SpeciesDTOs;
using Application.ServicesInterfaces;
using Domain.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesService _speciesService;

        public SpeciesController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] QueryParameters parameters)
        {
            var response = await _speciesService.GetMultipleAsync(parameters);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await _speciesService.GetByIdAsync(id);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Data);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Create([FromBody] CreateSpeciesDto dto)
        {
            var response = await _speciesService.CreateAsync(dto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSpeciesDto dto)
        {
            var response = await _speciesService.UpdateAsync(id, dto);
            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _speciesService.DeleteAsync(id);
            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Message);
        }
    }

}
