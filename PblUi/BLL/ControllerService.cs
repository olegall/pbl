using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PblDAL.Models;
using PblDAL.Reps;

namespace PblUi.BLL
{
    public class ControllerService
    {
        private readonly ControllerRepository _rep;

        private readonly byte _slaveAddress = 0x70;
        private readonly int _port = 503;

        public ControllerService(ApplicationContext context) => _rep = new ControllerRepository(context);

        public Task CreateAsync()
        {
            Controller c = new Controller
            { 
                SlaveAddress = _slaveAddress,
                Port = _port 
            };
            return _rep.CreateAsync(c);
        }

        public async Task<IEnumerable<Controller>> GetAllAsync()
        {
            return (await _rep.GetAllAsync()).OrderBy(x => x.Id);
        }

        public Task UpdateAsync(Controller m)
        {
            return _rep.UpdateAsync(m);
        }

        public Task DeleteAsync(int id)
        {
            return _rep.DeleteAsync(id);
        }
    }
}