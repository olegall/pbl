using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PblDAL.Models;
using PblDAL.Reps;
using System;

namespace PblUi.BLL
{
    public class ColorService
    {
        private readonly ColorRepository _rep;

        public ColorService(ApplicationContext context)
        {
            _rep = new ColorRepository(context);
        }

        public Task CreateAsync()
        {
            Color c = new Color()
            {
                Id = Guid.NewGuid().ToString()
            };
            return _rep.CreateAsync(c);
        }

        public async Task<IEnumerable<Color>> GetAllAsync()
        {
            return (await _rep.GetAllAsync()).OrderByDescending(x => x.ColorName);
        }

        public Task UpdateAsync(Color c)
        {
            return _rep.UpdateAsync(c);
        }

        public Task DeleteAsync(string id)
        {
            return _rep.DeleteAsync(id);
        }
    }
}