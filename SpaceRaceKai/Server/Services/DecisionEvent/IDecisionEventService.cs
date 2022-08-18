using SpaceRaceKai.Shared.Models.DecisionEvent;

namespace SpaceRaceKai.Server.Services.DecisionEvent
{
    public interface IDecisionEventService
    {
        Task<bool> CreateDecisionEventAsync(DecisionEventCreate model);
        Task<IEnumerable<DecisionEventListItem>> GetAllDecisionEventsAsync();
        Task<DecisionEventDetail?> GetDecisionEventByIdAsync(int id);
        Task<bool> UpdateDecisionEventAsync(DecisionEventEdit model);
        Task<bool> DeleteDecisionEventAsync(int id);
    }
}
