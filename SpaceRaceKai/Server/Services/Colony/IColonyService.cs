using SpaceRaceKai.Shared.Models.Colony;

namespace SpaceRaceKai.Server.Services.Colony
{
    public interface IColonyService
    {
        Task<bool> CreateColonyAsync(ColonyCreate model);
        Task<IEnumerable<ColonyListItem>> GetAllColoniesAsync();
        Task<ColonyDetail?> GetColonyByIdAsync(int id);
        Task<bool> UpdateColonyAsync(ColonyEdit model);
        Task<bool> DeleteColonyAsync(int id);
    }
}
