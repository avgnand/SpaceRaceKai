using Microsoft.EntityFrameworkCore;
using SpaceRaceKai.Server.Data;
using SpaceRaceKai.Shared.Models.EventEffect;

namespace SpaceRaceKai.Server.Services.EventEffect
{
    public class EventEffectService : IEventEffectService
    {
        private readonly ApplicationDbContext _context;

        public EventEffectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEventEffectAsync(EventEffectCreate model)
        {
            var eventEffect = new Models.EventEffect
            {
                PopulationChange = model.PopulationChange,
                ApprovalChange = model.ApprovalChange,
                TechChange = model.TechChange,
                IndustryChange = model.IndustryChange,
                WealthChange = model.WealthChange
            };
            _context.EventEffects.Add(eventEffect);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<EventEffectListItem>> GetAllEventEffectsAsync()
        {
            var eventEffects = _context.EventEffects
                .Select(ee => new EventEffectListItem
                {
                    Id = ee.Id,
                    PopulationChange = ee.PopulationChange,
                    ApprovalChange = ee.ApprovalChange,
                    TechChange = ee.TechChange,
                    IndustryChange = ee.IndustryChange,
                    WealthChange = ee.WealthChange
                });
            return await eventEffects.ToListAsync();
        }

        public async Task<EventEffectDetail?> GetEventEffectByIdAsync(int id)
        {
            var eventEffect = await _context.EventEffects.FindAsync(id);
            if (eventEffect is null) return null;
            else return new EventEffectDetail
            {
                Id = eventEffect.Id,
                PopulationChange = eventEffect.PopulationChange,
                ApprovalChange = eventEffect.ApprovalChange,
                TechChange = eventEffect.TechChange,
                IndustryChange = eventEffect.IndustryChange,
                WealthChange = eventEffect.WealthChange
            };
        }

        public async Task<bool> UpdateEventEffectAsync(EventEffectEdit model)
        {
            if (model is null) return false;
            var entity = await _context.EventEffects.FindAsync(model.Id);
            if (entity is null) return false;
            entity.PopulationChange = model.PopulationChange;
            entity.ApprovalChange = model.ApprovalChange;
            entity.TechChange = model.TechChange;
            entity.IndustryChange = model.IndustryChange;
            entity.WealthChange = model.WealthChange;
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteEventEffectAsync(int id)
        {
            var eventEffect = await _context.EventEffects.FindAsync(id);
            if (eventEffect is null) return false;
            _context.EventEffects.Remove(eventEffect);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
