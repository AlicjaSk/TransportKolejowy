using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Trasa
    {
        static int CNT = 0;
        public int id = 0;
        public Trasa()
        {
            ++CNT;
            this.id = CNT;
        }
    }
}
