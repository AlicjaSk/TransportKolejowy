using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Ulga
    {
        static int CNT = 0;
        public int id;
        public string nazwa;
        public int procent;
        public Ulga(string n, int p)
        {
            this.nazwa = n;
            this.procent = p;
            ++CNT;
            this.id = CNT;
        }
    }
}
