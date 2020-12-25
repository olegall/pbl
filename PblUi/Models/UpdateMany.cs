using PblDAL.Models;
using System.Collections.Generic;

namespace PblUi.Models
{
    public class UpdateMany
    {
        #region ShowUpdate
        public IEnumerable<string> Id { get; set; }
        public IEnumerable<int> ControllerId { get; set; }
        public ushort AddrLow { get; set; }
        public ushort AddrHigh { get; set; }
        public ushort OldAddress { get; set; }
        public IEnumerable<Color> Colors { get; set; }
        #endregion

        #region Update
        public string ColorId { get; set; }
        public int Address { get; set; }
        public int DefaultNumber { get; set; }
        #endregion
    }
}
