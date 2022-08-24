using Microsoft.AspNetCore.Mvc;
using SpaceRaceKai.Server.Services.DecisionEvent;
using SpaceRaceKai.Shared.Models.DecisionEvent;

namespace SpaceRaceKai.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecisionEventController : ControllerBase
    {
        private readonly IDecisionEventService _service;

        public DecisionEventController(IDecisionEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<DecisionEventListItem>> Index()
        {
            var decisionEvents = await _service.GetAllDecisionEventsAsync();
            return decisionEvents.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DecisionEvent(int id)
        {
            var decisionEvent = await _service.GetDecisionEventByIdAsync(id);
            return (decisionEvent is null) ? NotFound() : Ok(decisionEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DecisionEventCreate model)
        {
            if (model is null) return BadRequest();
            else return (await _service.CreateDecisionEventAsync(model)) ? Ok() : UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, DecisionEventEdit model)
        {
            if (model is null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            return (await _service.UpdateDecisionEventAsync(model)) ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var decisionEvent = await _service.GetDecisionEventByIdAsync(id);
            if (decisionEvent is null) return NotFound();
            else return (await _service.DeleteDecisionEventAsync(id)) ? Ok() : BadRequest();
        }
    }
}
