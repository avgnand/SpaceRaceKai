using SpaceRaceKai.Shared.Models.EventEffect;

namespace SpaceRaceKai.Server.Services.EventEffect
{
    public interface IEventEffectService
    {
        Task<bool> CreateEventEffectAsync(EventEffectCreate model);
        Task<IEnumerable<EventEffectListItem>> GetAllEventEffectsAsync();
        Task<EventEffectDetail?> GetEventEffectByIdAsync(int id);
        Task<bool> UpdateEventEffectAsync(EventEffectEdit model);
        Task<bool> DeleteEventEffectAsync(int id);
    }
}
