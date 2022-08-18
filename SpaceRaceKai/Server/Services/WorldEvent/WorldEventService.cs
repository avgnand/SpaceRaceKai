using Microsoft.EntityFrameworkCore;
using SpaceRaceKai.Server.Data;
using SpaceRaceKai.Shared.Models.WorldEvent;

namespace SpaceRaceKai.Server.Services.WorldEvent
{
    public class WorldEventService : IWorldEventService
    {
        private readonly ApplicationDbContext _context;

        public WorldEventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateWorldEventAsync(WorldEventCreate model)
        {
            var worldEvent = new Models.WorldEvent
            {
                Name = model.Name,
                Description = model.Description,
                PlanetTypeId = model.PlanetTypeId,
                EventEffectId = model.EventEffectId
            };
            _context.WorldEvents.Add(worldEvent);
            return await _context.SaveChangesAsync() == 1;
        }
        
        public async Task<IEnumerable<WorldEventListItem>> GetAllWorldEventsAsync()
        {
            var worldEvents = _context.WorldEvents
                .Select(we => new WorldEventListItem
                {
                    Id = we.Id,
                    Name = we.Name,
                    PlanetTypeName = we.PlanetType.Name
                });
            return await worldEvents.ToListAsync();
        }

        public async Task<WorldEventDetail?> GetWorldEventByIdAsync(int id)
        {
            var worldEvent = await _context.WorldEvents.FindAsync(id);
            if (worldEvent is null) return null;
            else return new WorldEventDetail
            {
                Id = worldEvent.Id,
                Name = worldEvent.Name,
                Description = worldEvent.Description,
                PlanetTypeId = worldEvent.PlanetTypeId,
                PlanetTypeName = worldEvent.PlanetType.Name,
                EventEffectId = worldEvent.EventEffectId,
                PopulationChange = worldEvent.EventEffect.PopulationChange,
                ApprovalChange = worldEvent.EventEffect.ApprovalChange,
                TechChange = worldEvent.EventEffect.TechChange,
                IndustryChange = worldEvent.EventEffect.IndustryChange,
                WealthChange = worldEvent.EventEffect.WealthChange
            };
        }

        public async Task<bool> UpdateWorldEventAsync(WorldEventEdit model)
        {
            if (model is null) return false;
            var entity = await _context.WorldEvents.FindAsync(model.Id);
            if (entity is null) return false;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.PlanetTypeId = model.PlanetTypeId;
            entity.EventEffectId = model.EventEffectId;
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteWorldEventAsync(int id)
        {
            var worldEvent = await _context.WorldEvents.FindAsync(id);
            if (worldEvent is null) return false;
            _context.WorldEvents.Remove(worldEvent);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
