using Microsoft.EntityFrameworkCore;
using SpaceRaceKai.Server.Data;
using SpaceRaceKai.Shared.Models.DecisionEvent;

namespace SpaceRaceKai.Server.Services.DecisionEvent
{
    public class DecisionEventService : IDecisionEventService
    {
        private readonly ApplicationDbContext _context;

        public DecisionEventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateDecisionEventAsync(DecisionEventCreate model)
        {
            var decisionEvent = new Models.DecisionEvent
            {
                Name = model.Name,
                Description = model.Description,
                EventEffectIdA = model.EventEffectIdA,
                EventEffectIdB = model.EventEffectIdB
            };
            _context.DecisionEvents.Add(decisionEvent);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<DecisionEventListItem>> GetAllDecisionEventsAsync()
        {
            var decisionEvents = _context.DecisionEvents
                .Select(de => new DecisionEventListItem
                {
                    Id = de.Id,
                    Name = de.Name
                });
            return await decisionEvents.ToListAsync();
        }

        public async Task<DecisionEventDetail?> GetDecisionEventByIdAsync(int id)
        {
            var decisionEvent = await _context.DecisionEvents
                .Include(de => de.EventEffectA)
                .Include(de => de.EventEffectB)
                .FirstOrDefaultAsync(de => de.Id == id);
            if (decisionEvent is null) return null;
            else return new DecisionEventDetail
            {
                Id = decisionEvent.Id,
                Name = decisionEvent.Name,
                Description = decisionEvent.Description,
                EventEffectIdA = decisionEvent.EventEffectIdA,
                PopulationChangeA = decisionEvent.EventEffectA.PopulationChange,
                ApprovalChangeA = decisionEvent.EventEffectA.ApprovalChange,
                TechChangeA = decisionEvent.EventEffectA.TechChange,
                IndustryChangeA = decisionEvent.EventEffectA.IndustryChange,
                WealthChangeA = decisionEvent.EventEffectA.WealthChange,
                EventEffectIdB = decisionEvent.EventEffectIdB,
                PopulationChangeB = decisionEvent.EventEffectB.PopulationChange,
                ApprovalChangeB = decisionEvent.EventEffectB.ApprovalChange,
                TechChangeB = decisionEvent.EventEffectB.TechChange,
                IndustryChangeB = decisionEvent.EventEffectB.IndustryChange,
                WealthChangeB = decisionEvent.EventEffectB.WealthChange
            };
        }

        public async Task<bool> UpdateDecisionEventAsync(DecisionEventEdit model)
        {
            if (model is null) return false;
            var entity = await _context.DecisionEvents.FindAsync(model.Id);
            if (entity is null) return false;
            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.EventEffectIdA = model.EventEffectIdA;
            entity.EventEffectIdB = model.EventEffectIdB;
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteDecisionEventAsync(int id)
        {
            var decisionEvent = await _context.DecisionEvents.FindAsync(id);
            if (decisionEvent is null) return false;
            _context.DecisionEvents.Remove(decisionEvent);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
