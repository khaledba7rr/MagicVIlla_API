using MagicVIlla_VillaAPI.Models;
using System.Linq.Expressions;

namespace MagicVIlla_VillaAPI.Repository.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter = null, bool tracking = true);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}
