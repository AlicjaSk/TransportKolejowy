using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Dworzec
    {
        static int CNT = 0;
        public int id;
        public string identyfikatorMiasta;
        public string nazwa;
        Miasto miasto;
        public Dworzec(string i, string n, Miasto m)
        {
            this.identyfikatorMiasta = i;
            this.nazwa = n;
            ++CNT;
            this.id = CNT;
            this.miasto = m;
        }
    }
}
