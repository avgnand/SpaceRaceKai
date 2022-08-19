using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceRaceKai.Server.Services.PlanetType;
using SpaceRaceKai.Shared.Models.PlanetType;

namespace SpaceRaceKai.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetTypeController : ControllerBase
    {
        private readonly IPlanetTypeService _service;

        public PlanetTypeController(IPlanetTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<PlanetTypeListItem>> Index()
        {
            var planetTypes = await _service.GetAllPlanetTypesAsync();
            return planetTypes.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PlanetType(int id)
        {
            var planetType = await _service.GetPlanetTypeByIdAsync(id);
            return (planetType is null) ? NotFound() : Ok(planetType);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlanetTypeCreate model)
        {
            if (model is null) return BadRequest();
            else return (await _service.CreatePlanetTypeAsync(model)) ? Ok() : UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, PlanetTypeEdit model)
        {
            if (model is null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            return (await _service.UpdatePlanetTypeAsync(model)) ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var planetType = await _service.GetPlanetTypeByIdAsync(id);
            if (planetType is null) return NotFound();
            else return (await _service.DeletePlanetTypeAsync(id)) ? Ok() : BadRequest();
        }
    }
}
