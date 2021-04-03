using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroChess
{
    public class TasDegerleri
    {
        public static int TasDegeriAl(Tas tas)
        {
            if (tas == Tas.Piyon)
            {
                return 1;
            }
            else if (tas == Tas.At)
            {
                return 3;
            }
            else if (tas == Tas.Fil)
            {
                return 3;
            }
            else if (tas == Tas.Kale)
            {
                return 5;
            }
            else if (tas == Tas.Vezir)
            {
                return 9;
            }
            else if (tas == Tas.Sah)
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }
    }
}
