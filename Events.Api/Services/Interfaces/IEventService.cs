using Events.Api.Database.Models;

namespace Events.Api.Services.Interfaces
{
    public interface IEventService
    {
        Task<Event> AddEventAsync(Event eventObject);
        
        Task<Event?> GetEventByIdAsync(int id);
    }
}
