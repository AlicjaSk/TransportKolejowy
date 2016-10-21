using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class BankSlow
    {
        static List<string> stanowiskoList = new List<string>()
        { "maszynista", "sprzedawca",  "konduktor", "osoba_sprzatajaca"};
        List<String> imionaList;
        List<String> nazwiskaList;
        public BankSlow()
        {
            imionaList = wczytajPliki("../../slowa/imiona.txt");
            nazwiskaList = wczytajPliki("../../slowa/nazwiska.txt");
        }

        public string getStanowiskoList(int i)
        {
            return stanowiskoList[i];
        }

        public int getRozmiarStanowiskoList()
        {
            return stanowiskoList.Count;
        }

        public string getImie(int i)
        {
            return imionaList[i];
        }

        public int getRozmiarImieList()
        {
            return imionaList.Count;
        }

        public string getNazwiskoList(int index)
        {
            return nazwiskaList[index];
        }

        public int getRozmiarNazwiskoList()
        {
            return nazwiskaList.Count;
        }


        public List<String> wczytajPliki(String sciezka)
        {
            List<String> tmp = new List<string>();
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(sciezka);
            while ((line = file.ReadLine()) != null)
            {
                tmp.Add(line);
            }

            file.Close();
            return tmp; 
        }


    }
}
