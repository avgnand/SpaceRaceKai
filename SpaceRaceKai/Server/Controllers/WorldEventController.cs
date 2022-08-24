using Microsoft.AspNetCore.Mvc;
using SpaceRaceKai.Server.Services.WorldEvent;
using SpaceRaceKai.Shared.Models.WorldEvent;

namespace SpaceRaceKai.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldEventController : ControllerBase
    {
        private readonly IWorldEventService _service;

        public WorldEventController(IWorldEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<WorldEventListItem>> Index()
        {
            var worldEvents = await _service.GetAllWorldEventsAsync();
            return worldEvents.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> WorldEvent(int id)
        {
            var worldEvent = await _service.GetWorldEventByIdAsync(id);
            return (worldEvent is null) ? NotFound() : Ok(worldEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorldEventCreate model)
        {
            if (model is null) return BadRequest();
            else return (await _service.CreateWorldEventAsync(model)) ? Ok() : UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, WorldEventEdit model)
        {
            if (model is null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            return (await _service.UpdateWorldEventAsync(model)) ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var worldEvent = await _service.GetWorldEventByIdAsync(id);
            if (worldEvent is null) return NotFound();
            else return (await _service.DeleteWorldEventAsync(id)) ? Ok() : BadRequest();
        }
    }
}
