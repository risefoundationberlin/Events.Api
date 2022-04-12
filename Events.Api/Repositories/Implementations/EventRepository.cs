using Events.Api.Database.Models;
using Events.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Events.Api.Repositories.Implementations
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(event_managementContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public Task<Event?> GetEventByIdAsync(int id)
        {
            return FindAll().FirstOrDefaultAsync(predicate: x => x.Id == id);
        }
    }
}
