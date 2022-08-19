using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceRaceKai.Server.Services.Colony;
using SpaceRaceKai.Shared.Models.Colony;

namespace SpaceRaceKai.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColonyController : ControllerBase
    {
        private readonly IColonyService _service;

        public ColonyController(IColonyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<ColonyListItem>> Index()
        {
            var colonies = await _service.GetAllColoniesAsync();
            return colonies.ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Colony(int id)
        {
            var colony = await _service.GetColonyByIdAsync(id);
            return (colony is null) ? NotFound() : Ok(colony);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ColonyCreate model)
        {
            if (model is null) return BadRequest();
            else return (await _service.CreateColonyAsync(model)) ? Ok() : UnprocessableEntity();
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, ColonyEdit model)
        {
            if (model is null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            return (await _service.UpdateColonyAsync(model)) ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var colony = await _service.GetColonyByIdAsync(id);
            if (colony is null) return NotFound();
            else return (await _service.DeleteColonyAsync(id)) ? Ok() : BadRequest();
        }
    }
}
