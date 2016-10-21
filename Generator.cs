using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HD
{
    class Generator
    {
        public List<Pracownik> pracownikList;
        BankSlow bankSlow;
        public static Random random;
        public Generator()
        {
            pracownikList = new List<Pracownik>();
            bankSlow = new BankSlow();
            random = new Random();
            generujPracownikow(10);

        }

        

        ~Generator()
        {
        }
 
        public void generujPracownikow(int n)
        {
            for (int i = 0; i < n; i++)
            {
                int index = random.Next(0, bankSlow.getRozmiarStanowiskoList()); ;
                String stanowisko = bankSlow.getStanowiskoList(index);
                index = random.Next(0, bankSlow.getRozmiarImieList());
                String imie = bankSlow.getImie(index);
                index = random.Next(0, bankSlow.getRozmiarNazwiskoList());
                String nazwisko = bankSlow.getNazwiskoList(index);
                Console.WriteLine(imie + " "+nazwisko+" pracuje jako: "+stanowisko);
                
            }
            

        }


        
        

        

    }

}
