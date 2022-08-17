using Microsoft.EntityFrameworkCore;
using SpaceRaceKai.Server.Data;
using SpaceRaceKai.Shared.Models.PlanetType;

namespace SpaceRaceKai.Server.Services.PlanetType
{
    public class PlanetTypeService : IPlanetTypeService
    {
        private readonly ApplicationDbContext _context;

        public PlanetTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePlanetTypeAsync(PlanetTypeCreate model)
        {
            var planetType = new Models.PlanetType
            {
                Name = model.Name,
                TemperatureRating = model.TemperatureRating,
                LandCover = model.LandCover
            };
            _context.PlanetTypes.Add(planetType);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<PlanetTypeListItem>> GetAllPlanetTypesAsync()
        {
            var planetTypes = _context.PlanetTypes
                .Select(pt => new PlanetTypeListItem
                {
                    Id = pt.Id,
                    Name = pt.Name
                });
            return await planetTypes.ToListAsync();
        }

        public async Task<PlanetTypeDetail?> GetPlanetTypeByIdAsync(int id)
        {
            var planetType = await _context.PlanetTypes.FindAsync(id);
            if (planetType is null) return null;
            else return new PlanetTypeDetail
            {
                Id = planetType.Id,
                Name = planetType.Name,
                TemperatureRating = planetType.TemperatureRating,
                LandCover = planetType.LandCover
            };
        }

        public async Task<bool> UpdatePlanetTypeAsync(PlanetTypeEdit model)
        {
            if (model is null) return false;
            var entity = await _context.PlanetTypes.FindAsync(model.Id);
            if (entity is null) return false;
            entity.Name = model.Name;
            entity.TemperatureRating = model.TemperatureRating;
            entity.LandCover = model.LandCover;
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeletePlanetTypeAsync(int id)
        {
            var planetType = await _context.PlanetTypes.FindAsync(id);
            if (planetType is null) return false;
            _context.PlanetTypes.Remove(planetType);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
