using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Kurs
    {
        static int CNT = 0;
        public int id = 0;
        public int zalogaID_FK;
        public int trasaID_FK;
        public int pociagID_FK;
        public string data;
        public Kurs(int z, int t, int p, string d)
        {
            ++CNT;
            this.id = CNT;
            this.zalogaID_FK = z;
            this.trasaID_FK = t;
            this.pociagID_FK = p;
            this.data = d;
        }

    }
}
