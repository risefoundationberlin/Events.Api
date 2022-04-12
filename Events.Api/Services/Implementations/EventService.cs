using Events.Api.Database.Models;
using Events.Api.Repositories.Interfaces;
using Events.Api.Services.Interfaces;

namespace Events.Api.Services.Implementations
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<Event> AddEventAsync(Event eventObject)
        {
            return await _eventRepository.AddAsync(eventObject);
        }

        public async Task<Event?> GetEventByIdAsync(int id)
        {
            return await _eventRepository.GetEventByIdAsync(id);
        }
    }
}
