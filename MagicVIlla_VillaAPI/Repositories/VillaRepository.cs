using MagicVIlla_VillaAPI.Data;
using MagicVIlla_VillaAPI.Models;
using MagicVIlla_VillaAPI.Repository;
using MagicVIlla_VillaAPI.Repository.IRepositories;

namespace MagicVIlla_VillaAPI.Repositories
{
    public class VillaRepository(VillaDbContext villaDbContext) : Repository<Villa>(villaDbContext) , IVillaRepository
    {
        private readonly VillaDbContext villaDbContext = villaDbContext;

        public async Task<Villa> UpdateAsync(Villa villa)
        {
            villaDbContext.Update(villa);

            await villaDbContext.SaveChangesAsync();

            return villa;
        }
    }
}
