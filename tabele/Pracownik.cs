using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Pracownik
    {
        static int CNT = 0;
        public int id;
        public string imie;
        public string nazwisko;
        public string stanowisko;

        public Pracownik(string i, string n, string s)
        {
            this.imie = i;
            this.nazwisko = n;
            this.stanowisko = s;
            ++CNT;
            this.id = CNT;
        }
    }
}
