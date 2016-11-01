using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Bilet
    {
        static int CNT = 0;
        public int id = 0;
        public int cena;
        public int ulgaID_FK;
        public int stacjaWyjazduID_FK;
        public int stacjaPrzyjazduID_FK;
        public int kursID_FK;
        public int klientID_FK; 
        public Bilet(int c, int u, int sW, int sP, int kl, int ku)
        {
            ++CNT;
            this.id = CNT;
            this.cena = c;
            this.ulgaID_FK = u;
            this.stacjaWyjazduID_FK = sW;
            this.stacjaPrzyjazduID_FK = sP;
            this.kursID_FK = kl;
            this.klientID_FK = ku;
        }

    }
}
