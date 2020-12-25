using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PblDAL.Models;


namespace PblDAL.Reps
{
    public class LightRepository : IGenericRepository<Light>, IServiceRepository
    {
        private ApplicationContext _context;
        public LightRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Light l)
        {
            _context.Lights.Add(l);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Light>> GetAllAsync()
        {
            return await _context.Lights.ToArrayAsync();
        }

        public async Task UpdateAsync(Light updated)
        {
            Light l = await Get(updated.Id);
            l.ColorId = updated.ColorId;
            l.ControllerId = updated.ControllerId;
            l.Address = updated.Address;
            l.Num = updated.Num;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateManyAsync(string id, int address, int number, string colorId, bool isAddressPartChanged)
        {
            Light l = await Get(id);

            if (address != 0)
            {
                l.Address = address;
                if (isAddressPartChanged)
                    l.Num = number;
            }
            
            if (colorId != null)
                l.ColorId = colorId;
            
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            Light l = await Get(id);
            _context.Lights.Remove(l);
            await _context.SaveChangesAsync();
        }

        public async Task<Light> Get(string id)
        {
            return await _context.Lights.FindAsync(id);
        }
    }
}