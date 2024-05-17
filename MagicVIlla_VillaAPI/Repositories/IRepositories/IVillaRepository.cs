using MagicVIlla_VillaAPI.Models;
using System.Linq.Expressions;

namespace MagicVIlla_VillaAPI.Repository.IRepositories
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa villa);
     }
}
