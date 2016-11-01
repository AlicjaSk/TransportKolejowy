using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Zaloga
    {

        static int CNT = 0;
        public int id = 0;
        public int maszynistaID_FK;
        public int konduktorID_FK;
        public int sprzedawcaID_FK;
        public int osobaSprzatajacaID_FK;
        public Zaloga(int m, int k, int s, int o)
        {
            ++CNT;
            this.id = CNT;
            this.maszynistaID_FK = m;
            this.konduktorID_FK = k;
            this.sprzedawcaID_FK = s;
            this.osobaSprzatajacaID_FK = o;
        }



    }
}
