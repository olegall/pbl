using System.Threading.Tasks;

namespace PblDAL.Reps
{
    interface IServiceRepository
    {
       Task DeleteAsync(string id);
    }
}
