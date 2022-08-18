using SpaceRaceKai.Shared.Models.WorldEvent;

namespace SpaceRaceKai.Server.Services.WorldEvent
{
    public interface IWorldEventService
    {
        Task<bool> CreateWorldEventAsync(WorldEventCreate model);
        Task<IEnumerable<WorldEventListItem>> GetAllWorldEventsAsync();
        Task<WorldEventDetail?> GetWorldEventByIdAsync(int id);
        Task<bool> UpdateWorldEventAsync(WorldEventEdit model);
        Task<bool> DeleteWorldEventAsync(int id);
    }
}
