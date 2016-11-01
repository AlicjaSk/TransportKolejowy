using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Ankieta
    {
        static int CNT = 0;
        public int id = 0;
        public int biletID_FK;
        public int opinieOPracownikach;
        public int opinieOKomforcie;
        public int opinieOOrganizacji;
        public Ankieta(int b, int oP, int oK, int oO)
        {
            ++CNT;
            this.id = CNT;
            this.opinieOPracownikach = oP;
            this.opinieOKomforcie = oK;
            this.opinieOOrganizacji = oO;
            this.biletID_FK = b;
        }
    }
}
