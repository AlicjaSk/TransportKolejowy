using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Pracownik
    {
        private string imie;
        private string nazwisko;
        private string stanowisko;

        Pracownik(string i, string n, string s)
        {
            this.imie = i;
            this.nazwisko = n;
            this.stanowisko = s; 
        }
    }
}
