using System.Collections.Generic;
using System.Threading.Tasks;

namespace PblDAL.Reps
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity item);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity item);
    }
}
