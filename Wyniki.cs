using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace HD
{
    class Wyniki
    {

        const string encoding = "WINDOWS-1250";
        List<Pracownik> pracownikList;
        List<Klient> klienciList;
        List<Ulga> ulgiList;
        List <Pociag> pociagiList;
        List<Dworzec> dworceList;
        List<Miasto> miastoList;
        List<Wagon> wagonList;
        List<Trasa> trasaList;
        List<StacjaNaTrasie> stacjaNaTrasieList;
        List<Zaloga> zalogaList;
        List<Kurs> kursList;
        List<Opoznienia> opoznieniaList;
        List<Bilet> biletyList;
        List<Ankieta> ankietyList;

        public Wyniki(List<Pracownik> p, List<Klient> k, List<Ulga> u, List<Pociag> poc,
            List<Dworzec> d, List<Miasto> m, List<Wagon> w,
            List<Trasa> t, List<StacjaNaTrasie> stNaTra,
            List<Zaloga> z, List<Kurs> kurs,
            List<Opoznienia> o, List<Bilet> b, List<Ankieta> a)
        {
            this.pracownikList = p;
            this.klienciList = k;
            this.ulgiList = u;
            this.pociagiList = poc;
            this.dworceList = d;
            this.miastoList = m;
            this.wagonList = w;
            this.trasaList = t;
            this.stacjaNaTrasieList = stNaTra;
            this.zalogaList = z;
            this.kursList = kurs;
            this.opoznieniaList = o;
            this.biletyList = b;
            this.ankietyList = a;
        }

        public void tworzPliki(string nazwaFolderu)
        {
            tworzPlikiBulk(nazwaFolderu);
            tworzPlikiXML(nazwaFolderu);
        }

        public void tworzPlikiBulk(string nazwaFolderu)
        {
            tworzPlikPracownikow(nazwaFolderu);
            tworzPlikKlientow(nazwaFolderu);
            tworzPlikUlg(nazwaFolderu);
            tworzPlikPociagow(nazwaFolderu);
            tworzPlikDworcow(nazwaFolderu);
            tworzPlikiWagonow(nazwaFolderu);
            tworzPlikTras(nazwaFolderu);
            tworzPlikStacjeNaTrasie(nazwaFolderu);
            tworzPlikZalog(nazwaFolderu);
            tworzPlikKursow(nazwaFolderu);
            tworzPlikOpoznien(nazwaFolderu);
            tworzPlikBiletow(nazwaFolderu);
            tworzPlikAnkiet(nazwaFolderu);
        }

        public void tworzPlikiXML(string nazwaFolderu)
        {
            tworzPlikXMLPociagi(nazwaFolderu);
            tworzPlikXMLMiasta(nazwaFolderu);
            tworzPlikiXMLWagonow(nazwaFolderu);
        }

        private void tworzPlikAnkiet(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\"+nazwaFolderu+"\\ankieta.bulk", false, System.Text.Encoding.UTF8);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ankietyList.Count; i++)
            {
                file.WriteLine(sb.Append(ankietyList[i].id).Append("|")
                    .Append(ankietyList[i].biletID_FK).Append("|")
                    .Append(ankietyList[i].opinieOPracownikach).Append("|")
                    .Append(ankietyList[i].opinieOKomforcie).Append("|")
                    .Append(ankietyList[i].opinieOOrganizacji));
                sb.Clear();
            }
            file.Close();
        }

        private void tworzPlikBiletow(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\bilet.bulk", false, System.Text.Encoding.UTF8);
            for (int i = 0; i < biletyList.Count; i++)
            {
                file.WriteLine(biletyList[i].id + "|" +
                    biletyList[i].cena + "|" +
                    biletyList[i].ulgaID_FK + "|" +
                    biletyList[i].stacjaWyjazduID_FK + "|" +
                    biletyList[i].stacjaPrzyjazduID_FK + "|" +
                    biletyList[i].kursID_FK + "|" +
                    biletyList[i].klientID_FK);
            }
            file.Close();
        }

        private void tworzPlikKursow(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\kurs.bulk", false, System.Text.Encoding.UTF8);
            for (int i = 0; i < kursList.Count; i++)
            {
                file.WriteLine(kursList[i].id + "|" +
                    kursList[i].zalogaID_FK + "|" +
                    kursList[i].trasaID_FK +"|" +
                    kursList[i].pociagID_FK + "|" +
                    kursList[i].data);
            }
            file.Close();
        }

        private void tworzPlikOpoznien(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\opoznienia.bulk", false, System.Text.Encoding.UTF8);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < opoznieniaList.Count; i++)
            {
                file.WriteLine(sb.Append(opoznieniaList[i].id).Append("|")
                    .Append(opoznieniaList[i].kursID_FK).Append("|")
                    .Append(opoznieniaList[i].stacjaNaTrasieID_FK).Append("|")
                    .Append(opoznieniaList[i].ileOpoznienia));
                sb.Clear();
            }
            file.Close();
        }

        private void tworzPlikPracownikow(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\pracownik.bulk", false, System.Text.Encoding.UTF8);
            for (int i = 0; i < pracownikList.Count; i++)
            {
                file.WriteLine(pracownikList[i].id + "|" +
                    pracownikList[i].imie + "|" +
                    pracownikList[i].nazwisko + "|" +
                    pracownikList[i].stanowisko);
            }
            file.Close();
        }

        private void tworzPlikKlientow(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\klient.bulk", false, System.Text.Encoding.UTF8);

            for (int i = 0; i < klienciList.Count; i++)
            {
                file.WriteLine(klienciList[i].id + "|" +
                    klienciList[i].imie + "|" +
                    klienciList[i].nazwisko + "|" +
                    klienciList[i].dataUrodzenia + "|" + 
                    klienciList[i].login + "|" + 
                    klienciList[i].haslo);
            }
            file.Close();
        }

        private void tworzPlikUlg(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\ulga.bulk", false, System.Text.Encoding.UTF8);
            for (int i = 0; i < ulgiList.Count; i++)
            {

                file.WriteLine(ulgiList[i].id + "|" +
                    ulgiList[i].nazwa + "|" +
                    ulgiList[i].procent);
            }
            file.Close();
        }

        private void tworzPlikPociagow(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\pociag.bulk", false, System.Text.Encoding.UTF8);
            for (int i = 0; i < pociagiList.Count; i++)
            {

                file.WriteLine(pociagiList[i].id + "|" + pociagiList[i].numerSeryjny);
            }
            file.Close();
        }

        private void tworzPlikDworcow(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\dworzec.bulk", false, System.Text.Encoding.UTF8);
            for (int i = 0; i < dworceList.Count; i++)
            {
                file.WriteLine(dworceList[i].id + "|" + 
                    dworceList[i].identyfikatorMiasta + "|"+ dworceList[i].nazwa);
            }
            file.Close();
        }

        private void tworzPlikXMLMiasta(string nazwaFolderu)
        {
            XmlTextWriter writer = new XmlTextWriter("..\\..\\" + nazwaFolderu + "\\miasto.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Miasta");
            for(int i = 0; i < miastoList.Count; i++)
            {
                writer.WriteStartElement("Miasto");
                stworzWezel(writer, "IdentyfikatorMiasta", miastoList[i].identyfikatorMiasta);
                stworzWezel(writer, "liczbaLudnosci", miastoList[i].liczbaLudnosci.ToString());
                stworzWezel(writer, "wojewodztwo", miastoList[i].wojewodztwo);
                stworzWezel(writer, "powierzchnia", miastoList[i].powierzchnia.ToString());
                stworzWezel(writer, "nazwa", miastoList[i].nazwa);
                writer.WriteEndElement();
            }
            writer.WriteEndDocument();
            writer.Close();
        }

        private void stworzWezel(XmlTextWriter writer, string atr, string nazwa)
        {
            writer.WriteStartElement(atr);
            writer.WriteString(nazwa);
            writer.WriteEndElement();
        }

        private void tworzPlikiWagonow(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\wagon.bulk", false, System.Text.Encoding.UTF8);
            for (int i = 0; i < wagonList.Count; i++)
            {
                file.WriteLine(wagonList[i].id + "|" +
                    wagonList[i].numerSeryjny + "|" + 
                    wagonList[i].pociag.id);
            }
            file.Close();
        }

        private void tworzPlikTras(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\trasa.bulk", false, System.Text.Encoding.UTF8);
            for (int i = 0; i < trasaList.Count; i++)
            {
                file.WriteLine(trasaList[i].id);
            }
            file.Close();
        }

        private void tworzPlikStacjeNaTrasie(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\stacjaNaTrasie.bulk", false, System.Text.Encoding.UTF8);
            for (int i = 0; i < stacjaNaTrasieList.Count; i++)
            {
                file.WriteLine(stacjaNaTrasieList[i].id + "|" +
                    stacjaNaTrasieList[i].trasaID_FK + "|" +
                    stacjaNaTrasieList[i].dworzecID_FK + "|" +
                    stacjaNaTrasieList[i].kolejnosc + "|" +
                    stacjaNaTrasieList[i].godzOdjazdu + "|" +
                    stacjaNaTrasieList[i].godzPrzyjazdu);
            }
            file.Close();
        }

        private void tworzPlikZalog(string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\zaloga.bulk", false, System.Text.Encoding.UTF8);
            for (int i = 0; i < zalogaList.Count; i++)
            {
                file.WriteLine(zalogaList[i].id + "|"+
                    zalogaList[i].maszynistaID_FK + "|" +
                    zalogaList[i].konduktorID_FK + "|" +
                    zalogaList[i].sprzedawcaID_FK + "|" +
                    zalogaList[i].osobaSprzatajacaID_FK);
            }
            file.Close();
        }

        private void tworzPlikXMLPociagi(string nazwaFolderu)
        {
            XmlTextWriter writer = new XmlTextWriter("..\\..\\" + nazwaFolderu + "\\pociag.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Pociagi");
            for (int i = 0; i < pociagiList.Count; i++)
            {
                writer.WriteStartElement("Pociag");
                stworzWezel(writer, "numerSeryjny", pociagiList[i].numerSeryjny);
                stworzWezel(writer, "nazwa", pociagiList[i].nazwa);
                stworzWezel(writer, "rodzaj", pociagiList[i].rodzaj);
                stworzWezel(writer, "dataOstatniegoPrzegladu", pociagiList[i].dataOstatniegoPrzegladu);
                stworzWezel(writer, "dataZakupu", pociagiList[i].dataZakupu);
                stworzWezel(writer, "maxPredkosc", pociagiList[i].maxPredkosc.ToString());
                stworzWezel(writer, "poborMocy", pociagiList[i].poborMocy.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndDocument();
            writer.Close();
        }

        private void tworzPlikiXMLWagonow(string nazwaFolderu)
        {
            XmlTextWriter writer = new XmlTextWriter("..\\..\\" + nazwaFolderu + "\\wagony.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("wagony");
            for (int i = 0; i < wagonList.Count; i++)
            {
                writer.WriteStartElement("wagon");
                stworzWezel(writer, "numerSeryjny", wagonList[i].numerSeryjny);
                stworzWezel(writer, "liczbaPrzedzialow", wagonList[i].liczbaPrzedzialow.ToString());
                stworzWezel(writer, "liczbaMiejscWPrzedziale", wagonList[i].liczbaPrzedzialow.ToString());
                stworzWezel(writer, "klasa", wagonList[i].klasa.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndDocument();
            writer.Close();
        }


        public void tworzPlikUpdatePracownik(List<Pracownik> zaktualizowaniPracownicy,string nazwaFolderu)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("..\\..\\" + nazwaFolderu + "\\updatePracownicy.sql", false, System.Text.Encoding.UTF8);
            foreach(Pracownik pracownik in zaktualizowaniPracownicy)
            {
                file.WriteLine("UPDATE Pracownik SET Stanowisko='" + pracownik.stanowisko + "' WHERE IDPracownika=" + pracownik.id + ";");
            }
            file.Close();

        }
    }
}
