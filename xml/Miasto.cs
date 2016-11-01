using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class Miasto
    {
        static int CNT = 0;
        public string identyfikatorMiasta;
        public int liczbaLudnosci;
        public string wojewodztwo;
        public double powierzchnia;
        public string nazwa;
        public Miasto(string i, int l, string w, double p, string n)
        {
            this.identyfikatorMiasta = i;
            this.liczbaLudnosci = l;
            this.wojewodztwo = w;
            this.powierzchnia = p;
            this.nazwa = n;
            CNT++;
            this.identyfikatorMiasta = "M" + CNT;
        }

    }
}
