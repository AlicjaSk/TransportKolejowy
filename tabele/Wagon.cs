using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Wagon
    {
        static int CNT = 0;
        public int id = 0;
        public string numerSeryjny;
        public int liczbaPrzedzialow;
        public int liczbaMiejscWPrzedziale;
        public int klasa;
        public Pociag pociag;

        public Wagon(int liczPrzedz, int liczMiejscWPrzedz, int k, Pociag p)
        {
            ++CNT;
            this.id = CNT;
            this.numerSeryjny = "WAG" + this.id;
            this.liczbaPrzedzialow = liczPrzedz;
            this.liczbaMiejscWPrzedziale = liczMiejscWPrzedz;
            this.klasa = k;
            this.pociag = p;
        }
    }
}
