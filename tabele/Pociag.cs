using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Pociag
    {
        static int CNT = 0;
        public int id;
        public string numerSeryjny;
        public string nazwa;
        public string rodzaj;
        public string dataOstatniegoPrzegladu;
        public string dataZakupu;
        public int maxPredkosc;
        public int poborMocy;
        
        public Pociag(string n, string r, string dataOstPrzeg, string datZak, int p, int pobMocy)
        {
            ++CNT;
            this.id = CNT;
            this.numerSeryjny = "TLK00" + CNT;
            this.nazwa = n;
            this.rodzaj = r;
            this.dataOstatniegoPrzegladu = dataOstPrzeg;
            this.dataZakupu = datZak;
            this.maxPredkosc = p;
            this.poborMocy = pobMocy;
        }

            
    }
}
