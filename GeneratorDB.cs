using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HD
{
    class GeneratorDB
    {

        public ListInTime<Pracownik> pracownikList;
        public ListInTime<Klient> klientList;
        public ListInTime<Dworzec> dworzecList;
        public ListInTime<Ulga> ulgiList;
        public ListInTime<Pociag> pociagList;
        public ListInTime<Wagon> wagonList;
        public ListInTime<Miasto> miastoList;
        public ListInTime<Trasa> trasaList;
        public ListInTime<StacjaNaTrasie> stacjeNaTrasieList;
        public ListInTime<Zaloga> zalogaList;
        public ListInTime<Kurs> kursList;
        public ListInTime<Opoznienia> opoznieniaList;
        public ListInTime<Bilet> biletList;
        public ListInTime<Ankieta> ankietaList;
 

        public class ListInTime<T> : List<T>
        {
            public int wygenerowanoDoT1;

            public List<T> GetSubListFromT1()
            {
                return GetRange(wygenerowanoDoT1, Count - wygenerowanoDoT1);
            }

            public void UstawIleWygenerowanoWT1()
            {
                wygenerowanoDoT1 = this.Count;
            }
        }

        private static class Wspolczynniki{

            public static int maxKursowNaTrasie = 5;
            public static int iloscMiast = 1;
            public static double szansaNaNowegoKlienta = 0.10;
            public static int maxStacjiNaTrasie = 15;
            public static int minStacjiNaTrasie = 3;
            public static double prawdopodobnienstwoWykonaniaPrzegladu = 0.02; //miesięcznie
            public static DateTime minDataUrodzin = new DateTime(1930, 1, 1);
            public static DateTime maksDataUrodzin = new DateTime(2008, 1, 1);
            public  static class T1
            {
                public static int liczbaPracownikow = 80;
                public static int liczbaKlientow = 5000;
                public static int liczbaPociagow = 20;
                public static int liczbaDworcow = 50;
                public static int liczbaTras = 30;
                public static int liczbaZalog = 15;
                public static DateTime poczatek = new DateTime(2013, 1, 1);
                public static DateTime koniec = new DateTime(2016, 2, 2);
                
            }

            public static class T2
            {
                public static int liczbaPracownikow = 50;
                public static int liczbaKlientow = 4000;
                public static int liczbaPociagow = 15;
                public static int liczbaDworcow = 15;
                public static int liczbaTras = 5;
                public static int liczbaZalog = 10;
                public static DateTime poczatek = new DateTime(2016, 2, 2);
                public static DateTime koniec = new DateTime(2016, 10, 10);
                public static double procentPracownikowZmieniajacychStanowisko = 0.3;
            }
        }


        BankSlow bankSlow;
        public static Random random;
        Wyniki w;
        public GeneratorDB()
        {
            AlokujListy();

            bankSlow = new BankSlow();
            random = new Random();

            generujT1(); // wygenerowanie T1

            w = new Wyniki(pracownikList, klientList, ulgiList, pociagList,
                dworzecList, miastoList, wagonList, trasaList, stacjeNaTrasieList,
                zalogaList, kursList, opoznieniaList, biletList, ankietaList);
            w.tworzPliki("wyniki");

            ustawDanePoT1();

            generujT2();

            String idZaktualizowanePociagi;
            zaktualizujDatyPrzegladu(pociagList, Wspolczynniki.T2.koniec, out idZaktualizowanePociagi);

            Console.Out.Write("Zaktualizowano pociagi: " + idZaktualizowanePociagi);

            
            w = new Wyniki(
                pracownikList.GetSubListFromT1(),
                klientList.GetSubListFromT1(),
                ulgiList.GetSubListFromT1(),
                pociagList.GetSubListFromT1(),
                dworzecList.GetSubListFromT1(),
                miastoList.GetSubListFromT1(),
                wagonList.GetSubListFromT1(),
                trasaList.GetSubListFromT1(),
                stacjeNaTrasieList.GetSubListFromT1(),
                zalogaList.GetSubListFromT1(),
                kursList.GetSubListFromT1(),
                opoznieniaList.GetSubListFromT1(),
                biletList.GetSubListFromT1(),
                ankietaList.GetSubListFromT1());

            // generacja plików bulk z nowymi danymi
            w.tworzPlikiBulk("wyniki2");

            
            w = new Wyniki(pracownikList, klientList, ulgiList, pociagList,
                dworzecList, miastoList, wagonList, trasaList, stacjeNaTrasieList,
                zalogaList, kursList, opoznieniaList, biletList, ankietaList);

            // generacja plików xml zawierających wszystkie dane z xml
            w.tworzPlikiXML("wyniki2");

            List<Pracownik> listaDoAktualizacji = wygenerujLosowaSubliste(pracownikList, Wspolczynniki.T2.procentPracownikowZmieniajacychStanowisko);
            zaktualizujStanowiskaPracownikow(listaDoAktualizacji);

            w.tworzPlikUpdatePracownik(listaDoAktualizacji,"wyniki2");
        }

        private void generujT2()
        {
            generujPracownikow(Wspolczynniki.T2.liczbaPracownikow);
            generujKlientow(Wspolczynniki.T2.liczbaKlientow);
            generujUlgi();
            generujPociagi(Wspolczynniki.T2.liczbaPociagow, Wspolczynniki.T2.poczatek,Wspolczynniki.T2.koniec);
            generujDworce(Wspolczynniki.T2.liczbaDworcow);
            generujTrasy(Wspolczynniki.T2.liczbaTras);
            generujStacjeNaTrasie(trasaList.GetSubListFromT1()); //generuje stacje tylko dla nowo utworzonych tras
            generujZalogi(Wspolczynniki.T2.liczbaZalog);
            generujKursy(Wspolczynniki.T2.poczatek, Wspolczynniki.T2.koniec, trasaList.GetSubListFromT1());
            generujOpoznienia(kursList.GetSubListFromT1());
            generujBilety(kursList.GetSubListFromT1());
            generujAnkiety(biletList.GetSubListFromT1());
        }

        private void ustawDanePoT1()
        {
            pracownikList.UstawIleWygenerowanoWT1();
            klientList.UstawIleWygenerowanoWT1();
            dworzecList.UstawIleWygenerowanoWT1();
            ulgiList.UstawIleWygenerowanoWT1();
            pociagList.UstawIleWygenerowanoWT1();
            wagonList.UstawIleWygenerowanoWT1();
            miastoList.UstawIleWygenerowanoWT1();
            trasaList.UstawIleWygenerowanoWT1();
            stacjeNaTrasieList.UstawIleWygenerowanoWT1();
            zalogaList.UstawIleWygenerowanoWT1();
            kursList.UstawIleWygenerowanoWT1();
            opoznieniaList.UstawIleWygenerowanoWT1();
            biletList.UstawIleWygenerowanoWT1();
            ankietaList.UstawIleWygenerowanoWT1();
        }

        private void generujT1()
        {
            generujPracownikow(Wspolczynniki.T1.liczbaPracownikow);
            generujKlientow(Wspolczynniki.T1.liczbaKlientow);
            generujUlgi();
            generujPociagi(Wspolczynniki.T1.liczbaPociagow,Wspolczynniki.T1.poczatek,Wspolczynniki.T2.koniec);
            generujDworce(Wspolczynniki.T1.liczbaDworcow);
            generujTrasy(Wspolczynniki.T1.liczbaTras);
            generujStacjeNaTrasie(trasaList);
            generujZalogi(Wspolczynniki.T1.liczbaZalog);
            generujKursy(Wspolczynniki.T1.poczatek,Wspolczynniki.T1.koniec,trasaList.GetSubListFromT1());
            generujOpoznienia(kursList);
            generujBilety(kursList);
            generujAnkiety(biletList);
        }

        private void AlokujListy()
        {
            pracownikList = new ListInTime<Pracownik>();
            miastoList = new ListInTime<Miasto>();
            dworzecList = new ListInTime<Dworzec>();
            klientList = new ListInTime<Klient>();
            ulgiList = new ListInTime<Ulga>();
            pociagList = new ListInTime<Pociag>();
            wagonList = new ListInTime<Wagon>();
            trasaList = new ListInTime<Trasa>();
            stacjeNaTrasieList = new ListInTime<StacjaNaTrasie>();
            zalogaList = new ListInTime<Zaloga>();
            kursList = new ListInTime<Kurs>();
            opoznieniaList = new ListInTime<Opoznienia>();
            biletList = new ListInTime<Bilet>();
            ankietaList = new ListInTime<Ankieta>();
        }

        ~GeneratorDB()
        {
        }


        #region TABELE


        public void generujAnkiety(List<Bilet> biletList)
        {
            for(int i = 0; i < biletList.Count; i++)
            {
                ankietaList.Add(stworzRandomowaAnkiete(biletList[i].id));
            }
        }

        private Ankieta stworzRandomowaAnkiete(int biletId)
        {
            int ocena = random.Next(1, 5);
            int opinieOPracownikach = ocena;
            ocena = random.Next(1, 5);
            int opinieOKomforcie = ocena;
            ocena = random.Next(1, 5);
            int opinieOOrganizacji = ocena;
            return new Ankieta(biletId, opinieOPracownikach, opinieOKomforcie, opinieOOrganizacji);
        }

        public void generujBilety(List<Kurs> kursList)
        {
            int ileOsobPojedziePociagiem; 
            for (int i = 0; i < kursList.Count; i++)
            {
                ileOsobPojedziePociagiem = random.Next(0, podajIleMiejscWPociagu(kursList[i].pociagID_FK));
                for(int j = 0; j < ileOsobPojedziePociagiem; j++)
                {
                    biletList.Add(stworzRandomowyBilet(kursList[i]));
                }
            }
        }

        private Bilet stworzRandomowyBilet(Kurs k)
        {
            int cena = 10;
            int index = random.Next(0, ulgiList.Count);
            int ulga = ulgiList[index].id;
            List<int> idStacji = poszukajStacji(k.trasaID_FK);
            int idOdj = idStacji[0];
            int idPrzyj = idStacji[1];
          
            if (Wspolczynniki.szansaNaNowegoKlienta >= random.NextDouble())
                generujKlientow(1);

            index = random.Next(0, klientList.Count);
            int idKlienta = klientList[index].id;

            return new Bilet(cena, ulga, idOdj, idPrzyj, idKlienta, k.id);
        }

        private List <int> poszukajStacji(int trasaID)
        {

            List<StacjaNaTrasie> stacjeNaTrasie = stacjeNaTrasieList.FindAll(o => o.trasaID_FK == trasaID);
            int idOdj = random.Next(0, stacjeNaTrasie.Count);
            int idPrzyj = random.Next(0, stacjeNaTrasie.Count);
            while (stacjeNaTrasie[idOdj].kolejnosc >= stacjeNaTrasie[idPrzyj].kolejnosc)
            {
                idOdj = random.Next(0, stacjeNaTrasie.Count);
                idPrzyj = random.Next(0, stacjeNaTrasie.Count);
            }

            List<int> idStacji = new List<int>();
            idStacji.Add(idOdj);
            idStacji.Add(idPrzyj);
            return idStacji;

        }
        private int podajIleMiejscWPociagu(int idPociagu)
        {
            List<Wagon> wagonyWPociagu = wagonList.FindAll(o => o.id == idPociagu);
            int ileWagonow = wagonyWPociagu.Count;
            int ileMiejsc = 0;
            for(int i = 0; i < wagonyWPociagu.Count; i++)
            {
                ileMiejsc += wagonyWPociagu[i].liczbaPrzedzialow * wagonyWPociagu[i].liczbaMiejscWPrzedziale;
            }
            return ileMiejsc;
        }

        public void generujOpoznienia(List<Kurs> kursList)
        {
            for (int i = 0; i < kursList.Count; i++)
            {
                stworzRandomoweOpoznienie(kursList[i]);
            }
        }

        private void stworzRandomoweOpoznienie(Kurs k)
        {
            List<StacjaNaTrasie> stacjaNaTrasieTmp = szukajStacjiNaTrasach(k.trasaID_FK);
            for(int i = 0; i < stacjaNaTrasieTmp.Count; i++)
            {
                int ileMinut = random.Next(0, 4);
                opoznieniaList.Add(new Opoznienia(k.id, stacjaNaTrasieTmp[i].id, ileMinut));
            }
        }

        private List<StacjaNaTrasie> szukajStacjiNaTrasach(int k)
        {
            List<StacjaNaTrasie> stacjaNaTrasie = stacjeNaTrasieList.FindAll(o => o.trasaID_FK == k);
            return stacjeNaTrasieList;
        }
        public void generujZalogi(int liczbaZalog)
        {
            for (int numerZalogi = 0; numerZalogi < liczbaZalog; numerZalogi++)
            {
                var item = pracownikList.FirstOrDefault(o => o.stanowisko == "maszynista");
                int maszynistaID = item.id;
                item = pracownikList.FirstOrDefault(o => o.stanowisko == "konduktor");
                int konduktorID = item.id;
                item = pracownikList.FirstOrDefault(o => o.stanowisko == "sprzedawca");
                int sprzedawcaID = item.id;
                item = pracownikList.FirstOrDefault(o => o.stanowisko == "osoba_sprzatajaca");
                int osobaSprzatajacaID = item.id;
                zalogaList.Add(new Zaloga(maszynistaID, konduktorID, sprzedawcaID, osobaSprzatajacaID));
            }
            
        }

        public void generujPracownikow(int n)
        {
            for (int i = 0; i < n; i++)
                pracownikList.Add(stworzRandomowegoPracownika());
        }

        private Pracownik stworzRandomowegoPracownika()
        {
            int index = random.Next(0, bankSlow.getRozmiarStanowiskoList()); ;
            string stanowisko = bankSlow.getStanowisko(index);
            index = random.Next(0, bankSlow.getRozmiarImieList());
            string imie = bankSlow.getImie(index);
            index = random.Next(0, bankSlow.getRozmiarNazwiskoList());
            string nazwisko = bankSlow.getNazwisko(index);
            return new Pracownik(imie, nazwisko, stanowisko);
        }

        private Klient stworzRandomowegoKlienta()
        {
            int index = random.Next(0, bankSlow.getRozmiarImieList());
            string imie = bankSlow.getImie(index);
            index = random.Next(0, bankSlow.getRozmiarNazwiskoList());
            string nazwisko = bankSlow.getNazwisko(index);
            index = random.Next(0, bankSlow.getRozmiarRzeczownikList());
            string haslo = bankSlow.getRzeczownik(index);
            index = random.Next(0, bankSlow.getRozmiarRzeczownikList());
            string login = bankSlow.getRzeczownik(index);
            string data_urodzenia = generujDate(Wspolczynniki.minDataUrodzin,Wspolczynniki.maksDataUrodzin);
            return new Klient(imie, nazwisko, data_urodzenia, login, haslo);
        }

        private void generujKursy(DateTime poczatek, DateTime koniec, List<Trasa> trasaList)
        {
            var iloscDni = (koniec - poczatek).TotalDays;
            for(int i = 0; i < iloscDni; i++)
            {
                for(int j = 0; j < trasaList.Count; j++)
                {
                    // jeżeli jest więcej kursów na jednej trasie
                    //int ileKursowNaTrasie = random.Next(1, Wspolczynniki.maxKursowNaTrasie);
                    //for (int numerKursu = 0; numerKursu < ileKursowNaTrasie; numerKursu++)
                    //{
                        DateTime d = poczatek.Add(TimeSpan.FromDays(j));
                        kursList.Add(stworzRandomowyKurs(trasaList[j].id, d.ToShortDateString()));
                    //}
                }
            }
        }

        private Kurs stworzRandomowyKurs(int trasaID, string data)
        {
            int index = random.Next(0, zalogaList.Count);
            int zalogaID = zalogaList[index].id;
            index = random.Next(0, pociagList.Count);
            int pociagID = pociagList[index].id;
            return new Kurs(zalogaID, trasaID, pociagID, data);

        }

        public void generujDworce(int n)
        {
            for (int i = 0; i < n; i++)
            {
                List<Dworzec> tmpDworce = stworzRandomowyDworzec();
                for(int j = 0; j < 3; j++)
                {
                    dworzecList.Add(tmpDworce[j]);
                }
            }
        }

        private List <Dworzec> stworzRandomowyDworzec()
        {
            List<Dworzec> tmpDworce = new List<Dworzec>();
            int index = random.Next(bankSlow.getRozmiarStacjeList());
            String nazwa = bankSlow.getMiasto(index);
            Miasto tmpMiasto = stworzMiasto("M" + Wspolczynniki.iloscMiast, nazwa);
            tmpDworce.Add(new Dworzec("M" + Wspolczynniki.iloscMiast, nazwa + " Cent.", tmpMiasto));
            tmpDworce.Add(new Dworzec("M" + Wspolczynniki.iloscMiast, nazwa + " Wsch.", tmpMiasto));
            tmpDworce.Add(new Dworzec("M" + Wspolczynniki.iloscMiast, nazwa + " Zach.", tmpMiasto));
            Wspolczynniki.iloscMiast++;
            return tmpDworce;
        }

        public void generujKlientow(int n)
        {
            for (int i = 0; i < n; i++)
                klientList.Add(stworzRandomowegoKlienta());
        }

        public void generujUlgi()
        {
            string ulgaTmp = bankSlow.getUlga(0);
           
            ulgiList.Add(new Ulga(ulgaTmp, random.Next(50, 100)));
            ulgaTmp = bankSlow.getUlga(1);
            ulgiList.Add(new Ulga(ulgaTmp, random.Next(50, 100)));
            ulgaTmp = bankSlow.getUlga(2);
            ulgiList.Add(new Ulga(ulgaTmp, random.Next(50, 100)));
        }

        public void generujPociagi(int n,DateTime odKiedy,DateTime doKiedy)
        {
            for (int i = 0; i < n; i++)
            {
                Pociag tmpPociag = stworzLosowyPociag(odKiedy,doKiedy);
                pociagList.Add(tmpPociag);
                int ileWagonow = random.Next(10, 16);
                dodajWagonyDoPociagu(ileWagonow, tmpPociag);
            }
        }

        public Pociag stworzLosowyPociag(DateTime odKiedy,DateTime doKiedy)
        {
            int index = random.Next(0, bankSlow.getRozmiarRzeczownikList());
            string nazwa = bankSlow.getRzeczownik(index);
            index = random.Next(0, bankSlow.getRozmiarRodzajPociaguList());
            string rodzaj = bankSlow.getRodzajPociagu(index);
            string dataOstPrzegladu = generujDate(odKiedy,doKiedy);
            string dataZakupu = generujDate(odKiedy,doKiedy);
            int maxPredkosc = random.Next(30, 100);
            int maxPoborMocy = random.Next(1000, 10000);

            return new Pociag(nazwa, rodzaj, dataOstPrzegladu, dataZakupu, maxPredkosc, maxPoborMocy);
        }

        public void dodajWagonyDoPociagu(int ilosc, Pociag p)
        {
            for(int i = 0; i < ilosc; i++)
                wagonList.Add(stworzLosowyWagon(p));
        }

        public Wagon stworzLosowyWagon(Pociag p)
        {
            int liczbaPrzedzialow = random.Next(6,10);
            int liczbaMiejscWPrzedziale = random.Next(6,8);
            int klasa = random.Next(1,2);
            return new Wagon(liczbaPrzedzialow, liczbaMiejscWPrzedziale, klasa, p);
        }

        public Miasto stworzMiasto(string idMiasta, string nazwa)
        {
            int liczbaLudnosci = random.Next(5, 50);
            int index = random.Next(0, bankSlow.getRozmiarWojewodztwaList());
            string woj = bankSlow.getWojewodztw(index);
            double pow = random.NextDouble() * (400000 - 100000) + 100000;
            Miasto tmp = new Miasto(idMiasta, liczbaLudnosci, woj, pow, nazwa);
            miastoList.Add(tmp);
            return tmp;
        }

        public void generujTrasy(int n)
        {
            for(int i = 0; i < n; i++)
                trasaList.Add(new Trasa());
        }

        public void generujStacjeNaTrasie(List<Trasa> trasaList)
        {
            TimeSpan poprzGodzina = TimeSpan.FromHours(0);
            for (int i = 0; i < trasaList.Count; i++)
            {
                int ileTras = random.Next(Wspolczynniki.minStacjiNaTrasie, Wspolczynniki.maxStacjiNaTrasie);
                
                for(int j = 0; j < ileTras; j++)
                {
                    StacjaNaTrasie stNaTraTmp = stworzRandomowaStacjeNaTrasie(trasaList[i].id, j + 1, poprzGodzina);
                    stacjeNaTrasieList.Add(stNaTraTmp);
                    poprzGodzina = stNaTraTmp.godzOdjazdu;
                }
            }
        }

        private StacjaNaTrasie stworzRandomowaStacjeNaTrasie(int trasaFK, int kol, TimeSpan poprzGodzOdj)
        {
            int index;
            index = random.Next(0, dworzecList.Count);

            // !!TODO: usuwac albo zaznaczac dworce, zeby nie wylosowac ich podwojnie 
            int dworzecFK = dworzecList[index].id;
            DateTime d = generujGodzine();
            TimeSpan godzPrzyj;
            TimeSpan godzOdj;
            if (kol == 1)
                godzPrzyj = generujCzas();
            else
                godzPrzyj = poprzGodzOdj.Add(TimeSpan.FromMinutes(random.Next(50, 90)));
            godzOdj = godzPrzyj.Add(TimeSpan.FromMinutes(3));
            return new StacjaNaTrasie(trasaFK, dworzecFK, godzOdj, godzPrzyj, kol);

        }
        #endregion

        private string generujDate(DateTime odKiedy,DateTime doKiedy)
        {
            return GetRandomDate(odKiedy, doKiedy).ToString("yyyy-MM-dd");
        }

        private DateTime generujGodzine()
        {
            int ileMinut = random.Next(1440);
            DateTime d = DateTime.Today.AddMinutes(ileMinut);
            return d;
        }

        public TimeSpan generujCzas()
        {
            TimeSpan start = TimeSpan.FromHours(0);
            TimeSpan end = TimeSpan.FromHours(7);
            int maxMinutes = (int)((end - start).TotalMinutes);
            int minutes = random.Next(maxMinutes);
            TimeSpan t = start.Add(TimeSpan.FromMinutes(minutes));
            return t;
        }

        public static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;
            var randTimeSpan = new TimeSpan((long)(random.NextDouble() * range.Ticks));
            return from + randTimeSpan;
        }        

        private void zaktualizujDatyPrzegladu(List<Pociag> pociagList,DateTime dataAktualizacji, out String listaZaktualizowanychPociagow)
        {
            double szansaNaPrzeglad;
            int miesiaceOdOstatniegoPrzegladu;
            int dniWMiesiacu = 30;
            DateTime dataOstatniegoPrzegladu;
            String zaktualizowanePociagi = String.Empty;

            foreach(Pociag pociag in pociagList)
            {
                dataOstatniegoPrzegladu = DateTime.Parse(pociag.dataOstatniegoPrzegladu);
                miesiaceOdOstatniegoPrzegladu = (int)(dataAktualizacji.Subtract(dataOstatniegoPrzegladu)).TotalDays/dniWMiesiacu;
                szansaNaPrzeglad = Wspolczynniki.prawdopodobnienstwoWykonaniaPrzegladu * miesiaceOdOstatniegoPrzegladu;
                if(random.NextDouble() < szansaNaPrzeglad)
                {
                    pociag.dataOstatniegoPrzegladu = GetRandomDate(dataOstatniegoPrzegladu, dataAktualizacji).ToString("yyyy-MM-dd");
                    zaktualizowanePociagi += pociag.id.ToString() + ",";
                }
            }

            listaZaktualizowanychPociagow = zaktualizowanePociagi;
        }
        private  List<T> wygenerujLosowaSubliste<T>(List<T> lista,double jakaCzescProcentowo)
        {
            List<T> sublista = new List<T>();
            foreach(T element in lista)
            {
                if (random.NextDouble() < jakaCzescProcentowo) sublista.Add(element);
            }
            return sublista;
        }

        private void zaktualizujStanowiskaPracownikow(List<Pracownik> pracownicyDoZmiany)
        {
            String noweStanowisko;
            int indexNowegoStanowiska;
            Console.WriteLine();
            foreach (Pracownik pracownik in pracownicyDoZmiany)
            {
                do{
                    indexNowegoStanowiska = random.Next(bankSlow.getRozmiarStanowiskoList());
                    noweStanowisko = bankSlow.getStanowisko(indexNowegoStanowiska);
                } while (pracownik.stanowisko.Equals(noweStanowisko));


                pracownik.stanowisko = noweStanowisko;
            }
        }

        
    }

}
