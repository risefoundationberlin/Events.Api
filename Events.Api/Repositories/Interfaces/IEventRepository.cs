using Events.Api.Database.Models;

namespace Events.Api.Repositories.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event?> GetEventByIdAsync(int id);
    }
}
