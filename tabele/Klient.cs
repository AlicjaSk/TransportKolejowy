using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Klient
    {
        static int CNT = 0;
        public int id;
        public string imie;
        public string nazwisko;
        public string dataUrodzenia;
        public string login;
        public string haslo;
        public Klient(string i, string n, string du, string l, string h)
        {
            this.imie = i;
            this.nazwisko = n;
            this.dataUrodzenia = du;
            this.login = l;
            this.haslo = h;
            ++CNT;
            this.id = CNT;
        }
    }
}
