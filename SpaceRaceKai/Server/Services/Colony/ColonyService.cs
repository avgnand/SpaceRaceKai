using Microsoft.EntityFrameworkCore;
using SpaceRaceKai.Server.Data;
using SpaceRaceKai.Shared.Models.Colony;

namespace SpaceRaceKai.Server.Services.Colony
{
    public class ColonyService : IColonyService
    {
        private readonly ApplicationDbContext _context;

        public ColonyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateColonyAsync(ColonyCreate model)
        {
            var colony = new Models.Colony
            {
                Name = model.Name,
                Population = model.Population,
                ApprovalRating = model.ApprovalRating,
                TechLevel = model.TechLevel,
                IndustryLevel = model.IndustryLevel,
                WealthLevel = model.WealthLevel,
                Playthroughs = 0,
                UserId = model.UserId,
                PlanetTypeId = model.PlanetTypeId
            };
            _context.Colonies.Add(colony);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<ColonyListItem>> GetAllColoniesAsync()
        {
            // TODO: Make specific to user (=> give user list of colony ids?)
            var colonies = _context.Colonies
                .Select(c => new ColonyListItem
                {
                    Id = c.Id,
                    Name = c.Name,
                    UserId = c.UserId,
                    PlanetTypeName = c.PlanetType.Name
                });
            return await colonies.ToListAsync();
        }

        public async Task<ColonyDetail?> GetColonyByIdAsync(int id)
        {
            var colony = await _context.Colonies.FindAsync(id);
            if (colony is null) return null;
            else return new ColonyDetail
            {
                Id = colony.Id,
                Name = colony.Name,
                Population = colony.Population,
                ApprovalRating = colony.ApprovalRating,
                TechLevel = colony.TechLevel,
                IndustryLevel = colony.IndustryLevel,
                WealthLevel = colony.WealthLevel,
                Playthroughs = colony.Playthroughs,
                UserId = colony.UserId,
                UserEmail = colony.User.Email,
                PlanetTypeId = colony.PlanetTypeId,
                PlanetTypeName = colony.PlanetType.Name
            };
        }

        public async Task<bool> UpdateColonyAsync(ColonyEdit model)
        {
            if (model is null) return false;
            var entity = await _context.Colonies.FindAsync(model.Id);
            if (entity is null) return false;
            entity.Name = model.Name;
            entity.Population = model.Population;
            entity.ApprovalRating = model.ApprovalRating;
            entity.TechLevel = model.TechLevel;
            entity.IndustryLevel = model.IndustryLevel;
            entity.WealthLevel = model.WealthLevel;
            entity.PlanetTypeId = model.PlanetTypeId;
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteColonyAsync(int id)
        {
            var colony = await _context.Colonies.FindAsync(id);
            if (colony is null) return false;
            _context.Colonies.Remove(colony);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
