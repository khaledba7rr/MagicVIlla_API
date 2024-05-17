using MagicVIlla_VillaAPI.Data;
using MagicVIlla_VillaAPI.Models;
using MagicVIlla_VillaAPI.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVIlla_VillaAPI.Repositories
{
    public class Repository<T>(VillaDbContext villaDbContext) : IRepository<T> where T : class
    {
        private readonly VillaDbContext villaDbContext = villaDbContext;

        internal DbSet<T> dbSet = villaDbContext.Set<T>();

        public async Task CreateAsync(T entity)
        {
            await villaDbContext.AddAsync(entity);

            await SaveAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter = null, bool tracking = true)
        {
            IQueryable<T> entity = dbSet;

            if (filter != null)
            {
                entity = entity.Where(filter);
            }

            if (!tracking)
            {
                entity = entity.AsNoTracking();
            }

            return await entity.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> villas = dbSet;

            if (filter != null)
            {
                villas = villas.Where(filter);
            }

            return await villas.ToListAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await villaDbContext.SaveChangesAsync();
        }

    }
}
