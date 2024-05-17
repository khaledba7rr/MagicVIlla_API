using MagicVIlla_VillaAPI.Models;
using MagicVIlla_VillaAPI.Repository.IRepositories;

namespace MagicVIlla_VillaAPI.Repositories.IRepositories
{
    public interface IVillaNoRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber villaNo);
    }
}
