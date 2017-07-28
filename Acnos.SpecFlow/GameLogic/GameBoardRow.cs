using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acnos.SpecFlow.GameLogic
{
    class GameBoardRow
    {
        public int Row { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }
        public string F { get; set; }
        public string G { get; set; }
        public string H { get; set; }
        public string this[int idx]
        {
            get
            {
                switch (idx)
                {
                    case 0: return A;
                    case 1: return B;
                    case 2: return C;
                    case 3: return D;
                    case 4: return E;
                    case 5: return F;
                    case 6: return G;
                    case 7: return H;
                    default: throw new ArgumentOutOfRangeException(nameof(idx), idx, "Index must be in range 0-7");
                }
            }
        }
    }
}
