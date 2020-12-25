using System.Collections.Generic;

namespace PblService.Models
{
    public class Register
    {
        public ushort Address { get; set; }
        public int Value { get; set; }
    }

    public class ControllerCache
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public bool Online { get; set; }
        public IList<Register> Registers { get; set; }
    }
}