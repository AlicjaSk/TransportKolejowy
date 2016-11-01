using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Opoznienia
    {
        static int CNT = 0;
        public int id = 0;
        public int kursID_FK;
        public int stacjaNaTrasieID_FK;
        public int ileOpoznienia;
        public Opoznienia(int k, int s, int i)
        {
            ++CNT;
            this.id = CNT;
            this.kursID_FK = k;
            this.stacjaNaTrasieID_FK = s;
            this.ileOpoznienia = i;
        }
    }
}
