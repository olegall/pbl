using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PblDAL.Models;

namespace PblDAL.Reps
{
    public class ControllerRepository : IGenericRepository<Controller>, IWebRepository
    {
        private ApplicationContext _context;
        public ControllerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Controller c)
        {
            _context.Controllers.Add(c);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Controller>> GetAllAsync()
        {
            return await _context.Controllers.ToArrayAsync();
        }

        public async Task UpdateAsync(Controller updated)
        {
            Controller m = await _context.Controllers.FindAsync(updated.Id);
            m.Address = updated.Address;
            m.SlaveAddress = updated.SlaveAddress;
            m.Port = updated.Port;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Controller m = _context.Controllers.ToArray().FirstOrDefault(x => x.Id == id);
            _context.Controllers.Remove(m);
            await _context.SaveChangesAsync();
        }
    }
}