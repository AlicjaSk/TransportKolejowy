using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class StacjaNaTrasie
    {        
        static int CNT = 0;
        public int id = 0;

        public int trasaID_FK;
        public int dworzecID_FK;
        public TimeSpan godzOdjazdu;
        public TimeSpan godzPrzyjazdu;
        public int kolejnosc;
        public StacjaNaTrasie(int t, int d, TimeSpan odj, TimeSpan przy, int kol)
        {
            ++CNT;
            this.id = CNT;
            this.trasaID_FK = t;
            this.dworzecID_FK = d;
            this.godzOdjazdu = odj;
            this.godzPrzyjazdu = przy;
            this.kolejnosc = kol;
        }
    }

}
