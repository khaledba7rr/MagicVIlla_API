using MagicVIlla_VillaAPI.Data;
using MagicVIlla_VillaAPI.Models;
using MagicVIlla_VillaAPI.Repositories.IRepositories;

namespace MagicVIlla_VillaAPI.Repositories
{
    public class VillaNoRepostiory(VillaDbContext villaDbContext) : Repository<VillaNumber>(villaDbContext), IVillaNoRepository
    {
        private readonly VillaDbContext villaDbContext = villaDbContext;
        public async Task<VillaNumber> UpdateAsync(VillaNumber villaNo)
        {
           villaDbContext.Update(villaNo);

            await villaDbContext.SaveChangesAsync();

            return villaNo;
        }
    }
}
