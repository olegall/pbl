using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PblDAL.Models;

namespace PblDAL.Reps
{
    public class ColorRepository : IGenericRepository<Color>, IServiceRepository
    {
        private ApplicationContext _context;
        public ColorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Color c)
        {
            _context.Colors.Add(c);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Color>> GetAllAsync()
        {
            return await _context.Colors.ToArrayAsync();
        }

        public async Task UpdateAsync(Color updated)
        {
            Color m = await _context.Colors.FindAsync(updated.Id);
            m.ColorName = updated.ColorName;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            Color c = _context.Colors.ToArray().FirstOrDefault(x => x.Id == id);
            _context.Colors.Remove(c);
            await _context.SaveChangesAsync();
        }
    }
}