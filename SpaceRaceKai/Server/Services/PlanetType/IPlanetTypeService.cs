using SpaceRaceKai.Shared.Models.PlanetType;

namespace SpaceRaceKai.Server.Services.PlanetType
{
    public interface IPlanetTypeService
    {
        Task<IEnumerable<PlanetTypeListItem>> GetAllPlanetTypesAsync();
        Task<bool> CreatePlanetTypeAsync(PlanetTypeCreate model);
        Task<PlanetTypeDetail?> GetPlanetTypeByIdAsync(int id);
        Task<bool> UpdatePlanetTypeAsync(PlanetTypeEdit model);
        Task<bool> DeletePlanetTypeAsync(int id);
    }
}
