using System.Threading.Tasks;

namespace PblDAL.Reps
{
    interface IWebRepository
    {
       Task DeleteAsync(int id);
    }
}
