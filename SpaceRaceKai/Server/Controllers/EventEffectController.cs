using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceRaceKai.Server.Services.EventEffect;
using SpaceRaceKai.Shared.Models.EventEffect;

namespace SpaceRaceKai.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventEffectController : ControllerBase
    {
        private readonly IEventEffectService _service;

        public EventEffectController(IEventEffectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<EventEffectListItem>> Index()
        {
            var eventEffects = await _service.GetAllEventEffectsAsync();
            return eventEffects.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> EventEffect(int id)
        {
            var eventEffect = await _service.GetEventEffectByIdAsync(id);
            return (eventEffect is null) ? NotFound() : Ok(eventEffect);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventEffectCreate model)
        {
            if (model is null) return BadRequest();
            else return (await _service.CreateEventEffectAsync(model)) ? Ok() : UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, EventEffectEdit model)
        {
            if (model is null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            return (await _service.UpdateEventEffectAsync(model)) ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eventEffect = await _service.GetEventEffectByIdAsync(id);
            if (eventEffect is null) return NotFound();
            else return (await _service.DeleteEventEffectAsync(id)) ? Ok() : BadRequest();
        }
    }
}
