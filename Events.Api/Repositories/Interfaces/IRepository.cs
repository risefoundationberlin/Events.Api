using System.Linq.Expressions;

namespace Events.Api.Repositories.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveAsync(T entity);
    }
}
