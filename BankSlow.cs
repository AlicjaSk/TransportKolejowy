using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD
{
    class BankSlow
    {

        Random rand;
        const string encoding = "WINDOWS-1250";
        static List<string> stanowiskoList = new List<string>()
        { "maszynista", "sprzedawca",  "konduktor", "osoba_sprzatajaca"};

        static List<string> rodzajePociagowList = new List<string>()
        { "regionalny", "pośpieszny",  "express"};

        static List<string> ulgiList = new List<string>()
        { "Studenci/Doktoranci", "Dzieci/Mlodzież",  "Seniorzy"};


        List<String> imionaList;
        List<String> nazwiskaList;
        List<String> miastaList;
        List<String> rzeczownikiList;
        List<String> wojewodztwaList;

        public BankSlow()
        {
            rand = new Random();
            imionaList = wczytajPliki("../../slowa/imiona.txt");
            nazwiskaList = wczytajPliki("../../slowa/nazwiska.txt");
            miastaList = wczytajPliki("../../slowa/miasta.txt");
            rzeczownikiList = wczytajPliki("../../slowa/rzeczowniki.txt");
            wojewodztwaList = wczytajPliki("../../slowa/wojewodztwa.txt");
        }


        #region GETTER, SETTER
        public string getUlga(int index)
        {
            return ulgiList[index];
        }

        public int getRozmiarUlgiList()
        {
            return ulgiList.Count;
        }

        public string getRodzajPociagu(int index)
        {
            return rodzajePociagowList[index];
        }

        public int getRozmiarRodzajPociaguList()
        {
            return rodzajePociagowList.Count;
        }

        public String getWojewodztw(int index)
        {
            return wojewodztwaList[index];
        }

        public int getRozmiarWojewodztwaList()
        {
            return wojewodztwaList.Count;
        }

        public string getStanowisko(int i)
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

        public string getNazwisko(int index)
        {
            return nazwiskaList[index];
        }

        public int getRozmiarNazwiskoList()
        {
            return nazwiskaList.Count;
        }

        public string getMiasto(int index)
        {
            String tmp = miastaList[index];
            miastaList.RemoveAt(index);
            return tmp;
        }

        public int getRozmiarStacjeList()
        {
            return miastaList.Count;
        }

        public string getRzeczownik(int index)
        {
            String tmp = rzeczownikiList[rand.Next(rzeczownikiList.Count)];

            return tmp;
        }

        public int getRozmiarRzeczownikList()
        {
            return rzeczownikiList.Count;
        }

        #endregion

        public List<String> wczytajPliki(String sciezka)
        {
            List<String> tmp = new List<string>();
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(sciezka, System.Text.Encoding.UTF8);
            while ((line = file.ReadLine()) != null)
            {
                tmp.Add(line);
            }
            file.Close();
            return tmp; 
        }


    }
}
