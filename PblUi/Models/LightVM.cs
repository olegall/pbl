using PblDAL.Models;
using System.Collections.Generic;

namespace PblUi.Models
{
    public class Num
    {
        public int Min { get; }
        public int Max { get; }
        public Num(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }

    public class ModuleNum
    {
        public Num First { get; }
        public Num Last { get; }
        public ModuleNum(int firstMin, int firstHigh, int lastMin, int lastHigh) 
        {
            First = new Num(firstMin, firstHigh);
            Last = new Num(lastMin, lastHigh);
        }
    }

    public class LightVM
    {
        public IEnumerable<Light> Lights { get; set; }
        public IEnumerable<Controller> Controllers { get; set; }
        public IEnumerable<int> Addrs { get; set; }
        
        public IEnumerable<Color> Colors { get; set; }

        /// <summary>
        /// Номера дискретных выходов модуля расширения
        /// </summary>
        public ModuleNum ModuleNums { get; set; }
    }
}