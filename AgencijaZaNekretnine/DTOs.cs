using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencijaZaNekretnine.Entiteti;

namespace AgencijaZaNekretnine
{
    //klase za pregled informacija
    public class NekretninaPregled
    {
        public int NekretninaId { get; set; }
        public string NekretninaLokacija { get; set; }
        public string NekretninaUlica { get; set; }
        public string NekretninaTip { get; set; }
        public decimal NekretninaKvadratura { get; set; }
        public int NekretninaCena { get; set; }
        public string NekretninaPI { get; set; }//prodaja ili iznajmljivanje
        public string VlasnikIme { get; set; }
        public string VlasnikPrezime { get; set; }

        public NekretninaPregled(int id, string lok, string ul, string tip, decimal kv, int cena, string pi, string ime, string prezime)
        {
            this.NekretninaId = id;
            this.NekretninaLokacija = lok;
            this.NekretninaUlica = ul;
            this.NekretninaTip = tip;
            this.NekretninaKvadratura = kv;
            this.NekretninaCena = cena;
            this.NekretninaPI = pi;
            this.VlasnikIme = ime;
            this.VlasnikPrezime = prezime;
        }
    }

    public class AgentPregled
    {
        public int AgentId { get; set; }
        public string AgentIme { get; set; }
        public string AgentPrezime { get; set; }
        public string AgentTelefon { get; set; }
        public string AgentEmail { get; set; }

        public AgentPregled(int id, string ime, string prezime, string tel, string email)
        {
            this.AgentId = id;
            this.AgentIme = ime;
            this.AgentPrezime = prezime;
            this.AgentTelefon = tel;
            this.AgentEmail = email;
        }
    }

    public class KlijentPregled
    {
        public int KlijentId { get; set; }
        public string KlijentIme { get; set; }
        public string KlijentPrezime { get; set; }
        public string KlijentTelefon { get; set; }
        public string KlijentEmail { get; set; }

        public KlijentPregled(int id, string ime, string prezime, string tel, string email)
        {
            this.KlijentId = id;
            this.KlijentIme = ime;
            this.KlijentPrezime = prezime;
            this.KlijentTelefon = tel;
            this.KlijentEmail = email;
        }
    }

    public class ZastupnikPregled
    {
        public int ZastupnikId { get; set; }
        public string ZastupnikIme { get; set; }
        public string ZastupnikPrezime { get; set; }
        public string ZastupnikAdresa { get; set; }

        public ZastupnikPregled(int id, string ime, string prezime, string adresa)
        {
            this.ZastupnikId = id;
            this.ZastupnikIme = ime;
            this.ZastupnikPrezime = prezime;
            this.ZastupnikAdresa = adresa;
        }
    }

    public class UgovorPregled
    {
        public int UgovorId { get; set; }
        public DateTime UgovorDatum { get; set; }
        public int NekretninaId { get; set; }
        public string VlasnikIme { get; set; }
        public string VlasnikPrezime { get; set; }
        public string KlijentIme { get; set; }
        public string KlijentPrezime { get; set; }

        public UgovorPregled(int id, DateTime dt, int idnekr, string vime, string vprezime, string kime, string kprezime)
        {
            this.UgovorId = id;
            this.UgovorDatum = dt;
            this.NekretninaId = idnekr;
            this.VlasnikIme = vime;
            this.VlasnikPrezime = vprezime;
            this.KlijentIme = kime;
            this.KlijentPrezime = kprezime;
        }
    }

    //klase za izmenu podataka
    public class AgentBasic
    {
        public int AgentId { get; set; }
        public string AgentTelefon { get; set; }
        public string AgentEmail { get; set; }
        public string AgentSifra { get; set; }
        public int AgentStaz { get; set; }

        public AgentBasic(int id, string tel, string email, string sifra, int staz)
        {
            this.AgentId = id;
            this.AgentTelefon = tel;
            this.AgentEmail = email;
            this.AgentSifra = sifra;
            this.AgentStaz = staz;
        }

        public AgentBasic()
        {

        }
    }

    public class ZastupnikBasic
    {
        public int ZastupnikId { get; set; }
        public string NazivKancelarije { get; set; }
        public string AdresaKancelarije { get; set; }

        public ZastupnikBasic()
        {

        }

        public ZastupnikBasic(int id, string naziv, string adresa)
        {
            this.ZastupnikId = id;
            this.NazivKancelarije = naziv;
            this.AdresaKancelarije = adresa;
        }
    }

    public class KlijentBasic
    {
        public int KlijentId { get; set; }
        public string KlijentEmail { get; set; }
        public string KlijentSifra { get; set; }
        public string KlijentAdresa { get; set; }
        public string KlijentTelefon { get; set; }
        public string Kupac { get; set; }
        public string Prodavac { get; set; }

        public KlijentBasic()
        {

        }

        public KlijentBasic(int id, string email, string sifra,string adresa, string tel, string k, string p )
        {
            this.KlijentId = id;
            this.KlijentEmail = email;
            this.KlijentSifra = sifra;
            this.KlijentAdresa = adresa;
            this.KlijentTelefon = tel;
            this.Kupac = k;
            this.Prodavac = p;
        }
    }

    public class UgovorBasic
    {
        public int UgovorId { get; set; }
        public string AdresaNotara { get; set; }
        public int Naknada { get; set; }
        public int Bonus { get; set; }
        public int Period { get; set; }

        public UgovorBasic()
        {

        }

        public UgovorBasic(int id, string adr, int naknada, int bonus)
        {
            this.UgovorId = id;
            this.AdresaNotara = adr;
            this.Naknada = naknada;
            this.Bonus = bonus;
            this.Period = 0;
        }

        public UgovorBasic(int id, string adr, int naknada, int bonus, int period)
        {
            this.UgovorId = id;
            this.AdresaNotara = adr;
            this.Naknada = naknada;
            this.Bonus = bonus;
            this.Period = period;
        }
    }

    public class NekretninaBasic
    {
        public int NekretninaId { get; set; }
        public string Ulica { get; set; }
        public int Cena { get; set; }
        public string SpratBrojSpratova { get; set; }
        public string Opis { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public int Meseci { get; set; }

        public NekretninaBasic()
        {

        }

        public NekretninaBasic (int id, string ul, int cena, string sprat, string opis)
        {
            this.NekretninaId = id;
            this.Ulica = ul;
            this.Cena = cena;
            this.SpratBrojSpratova = sprat;
            this.Opis = opis;
            this.Meseci = 0;
            this.DatumOd = DateTime.MinValue;
            this.DatumDo = DateTime.MinValue;
        }

        public NekretninaBasic(int id, string ul, int cena, string sprat, string opis, DateTime od, DateTime Do)
        {
            this.NekretninaId = id;
            this.Ulica = ul;
            this.Cena = cena;
            this.SpratBrojSpratova = sprat;
            this.Opis = opis;
            this.DatumDo = Do;
            this.DatumOd = od;
            this.Meseci = 0;
        }

        public NekretninaBasic(int id, string ul, int cena, string sprat, string opis, int meseci)
        {
            this.NekretninaId = id;
            this.Ulica = ul;
            this.Cena = cena;
            this.SpratBrojSpratova = sprat;
            this.Opis = opis;
            this.Meseci = meseci;
            this.DatumOd = DateTime.MinValue;
            this.DatumDo = DateTime.MinValue;
        }
    }

    //klase za IV fazu, koriste se i klase za pregled iz prethodne faze
    #region IV faza klase
    public class AgentView
    {
        public int AgentId { get; set; }
        public string AgentIme { get; set; }
        public string AgentPrezime { get; set; }
        public string AgentTelefon { get; set; }
        public string AgentEmail { get; set; }
        public int RadniStaz { get; set; }

        public AgentView()
        {

        }

        public AgentView(Agent a)
        {
            this.AgentId = a.Id;
            this.AgentIme = a.Ime;
            this.AgentPrezime = a.Prezime;
            this.AgentTelefon = a.Telefon;
            this.AgentEmail = a.Email;
            this.RadniStaz = a.RadniStaz;
        }
    }

    public class ZastupnikView
    {
        public int ZastupnikId { get; set; }
        public string ZastupnikIme { get; set; }
        public string ZastupnikPrezime { get; set; }
        public string ZastupnikAdresa { get; set; }
        public string NazivKancelarije { get; set; }

        public ZastupnikView()
        {

        }

        public ZastupnikView(PravniZastupnik pz)
        {
            this.ZastupnikId = pz.Id;
            this.ZastupnikIme = pz.Ime;
            this.ZastupnikPrezime = pz.Prezime;
            this.ZastupnikAdresa = pz.AdresaKancelarije;
            this.NazivKancelarije = pz.NazivKancelarije;
        }
    }

    public class KlijentView
    {
        public int KlijentId { get; set; }
        public string KlijentIme { get; set; }
        public string KlijentPrezime { get; set; }
        public string KlijentTelefon { get; set; }
        public string KlijentEmail { get; set; }
        public string KlijentAdresa { get; set; }
        public string Kupac { get; set; }
        public string Prodavac { get; set; }

        public KlijentView()
        {

        }

        public KlijentView(Klijent k)
        {
            this.KlijentId = k.Id;
            this.KlijentIme = k.Ime;
            this.KlijentPrezime = k.Prezime;
            this.KlijentTelefon = k.Telefon;
            this.KlijentEmail = k.Email;
            this.KlijentAdresa = k.Adresa;
            this.Kupac = k.Kupac;
            this.Prodavac = k.Prodavac;
        }
    }

    public class NekretninaProdajaPregled
    {
        public int NekretninaId { get; set; }
        public string NekretninaLokacija { get; set; }
        public string NekretninaUlica { get; set; }
        public string NekretninaTip { get; set; }
        public decimal NekretninaKvadratura { get; set; }
        public int NekretninaCena { get; set; }
        public string VlasnikIme { get; set; }
        public string VlasnikPrezime { get; set; }

        public NekretninaProdajaPregled()
        {

        }

        public NekretninaProdajaPregled(NekretninaProdaja n)
        {
            this.NekretninaId = n.Id;
            this.NekretninaLokacija = n.GradLokacija;
            this.NekretninaUlica = n.Ulica;
            this.NekretninaTip = n.Tip;
            this.NekretninaKvadratura = n.Kvadratura;
            this.NekretninaCena = n.Cena;
            this.VlasnikIme = n.Vlasnik.Ime;
            this.VlasnikPrezime = n.Vlasnik.Prezime;
        }
    }

    public class NekrIznKracePregled:NekretninaProdajaPregled
    {
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public int Godina { get; set; }

        public NekrIznKracePregled()
        {

        }

        public NekrIznKracePregled(NekretninaIznajmljivanjeKrace n)
        {
            this.NekretninaId = n.Id;
            this.NekretninaLokacija = n.GradLokacija;
            this.NekretninaUlica = n.Ulica;
            this.NekretninaTip = n.Tip;
            this.NekretninaKvadratura = n.Kvadratura;
            this.NekretninaCena = n.Cena;
            this.VlasnikIme = n.Vlasnik.Ime;
            this.VlasnikPrezime = n.Vlasnik.Prezime;
            this.DatumOd = n.DatumOd;
            this.DatumDo = n.DatumDo;
            this.Godina = n.Godina;
        }
    }

    public class NekrIznDuzePregled:NekretninaProdajaPregled
    {
        public int MaxMeseci { get; set; }
        public string FizickaLicaFirme { get; set; }

        public NekrIznDuzePregled()
        {

        }

        public NekrIznDuzePregled(NekretninaIznajmljivanjeDuze n)
        {
            this.NekretninaId = n.Id;
            this.NekretninaLokacija = n.GradLokacija;
            this.NekretninaUlica = n.Ulica;
            this.NekretninaTip = n.Tip;
            this.NekretninaKvadratura = n.Kvadratura;
            this.NekretninaCena = n.Cena;
            this.VlasnikIme = n.Vlasnik.Ime;
            this.VlasnikPrezime = n.Vlasnik.Prezime;
            this.MaxMeseci = n.MaxMeseci;
            this.FizickaLicaFirme = n.FizickaLicaFirme;
        }
    }

    public class NekretninaProdajaAddUpdate
    {
        public string IdUgovora { get; set; }
        public string GradLokacija { get; set; }
        public string Ulica { get; set; }
        public int Broj { get; set; }
        public string BrojParcele { get; set; }
        public string KatastarskaOpstina { get; set; }
        public string Tip { get; set; }
        public decimal Kvadratura { get; set; }
        public DateTime DatumIzgradnje { get; set; }
        public int Cena { get; set; }
        public string SpratBrSpratova { get; set; }
        public string Opis { get; set; }
        public string ProdajaIznajmljivanje { get; set; }
        public int ZaduzenAgent { get; set; }
        public int Vlasnik { get; set; }

        public NekretninaProdajaAddUpdate()
        {

        }
    }

    public class NekrIznDuzeAddUpdate:NekretninaProdajaAddUpdate
    {
        public int MaxMeseci { get; set; }
        public string FizickaLicaFirme { get; set; }

        public NekrIznDuzeAddUpdate()
        {

        }
    }

    public class NekrIznKraceAddUpdate:NekretninaProdajaAddUpdate
    {
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public int Godina { get; set; }

        public NekrIznKraceAddUpdate()
        {

        }
    }

    public class ProdajniUgovorPregled
    {
        public int UgovorId { get; set; }
        public DateTime UgovorDatum { get; set; }
        public int NekretninaId { get; set; }
        public string VlasnikIme { get; set; }
        public string VlasnikPrezime { get; set; }
        public string KlijentIme { get; set; }
        public string KlijentPrezime { get; set; }
        public string ImePrezimeNotar { get; set; }
        public int NaknadaAgencija { get; set; }
        public int BonusAgent { get; set; }
        public int Cena { get; set; }
        public int NaknadaNotar { get; set; }

        public ProdajniUgovorPregled()
        {

        }

        public ProdajniUgovorPregled(ProdajniUgovor pu)
        {
            this.UgovorId = pu.Broj;
            this.UgovorDatum = pu.Datum;
            this.NekretninaId = pu.PripadaNekretnini.Id;
            this.VlasnikIme = pu.Vlasnik.Ime;
            this.VlasnikPrezime = pu.Vlasnik.Prezime;
            this.KlijentIme = pu.KupacIznajmljivac.Ime;
            this.KlijentPrezime = pu.KupacIznajmljivac.Prezime;
            this.ImePrezimeNotar = pu.ImePrezimeNotara;
            this.NaknadaAgencija = pu.NaknadaAgencija;
            this.BonusAgent = pu.BonusAgent;
            this.Cena = pu.Cena;
            this.NaknadaNotar = pu.NaknadaNotar;
        }
    }

    public class IznajmljivanjeUgovorPregled
    {
        public int UgovorId { get; set; }
        public DateTime UgovorDatum { get; set; }
        public int NekretninaId { get; set; }
        public string VlasnikIme { get; set; }
        public string VlasnikPrezime { get; set; }
        public string KlijentIme { get; set; }
        public string KlijentPrezime { get; set; }
        public string ImePrezimeNotar { get; set; }
        public int NaknadaAgencija { get; set; }
        public int BonusAgent { get; set; }
        public int Period { get; set; }
        public int Renta { get; set; }

        public IznajmljivanjeUgovorPregled()
        {

        }

        public IznajmljivanjeUgovorPregled(IznajmljivanjeUgovor iu)
        {
            this.UgovorId = iu.Broj;
            this.UgovorDatum = iu.Datum;
            this.NekretninaId = iu.PripadaNekretnini.Id;
            this.VlasnikIme = iu.Vlasnik.Ime;
            this.VlasnikPrezime = iu.Vlasnik.Prezime;
            this.KlijentIme = iu.KupacIznajmljivac.Ime;
            this.KlijentPrezime = iu.KupacIznajmljivac.Prezime;
            this.ImePrezimeNotar = iu.ImePrezimeNotara;
            this.NaknadaAgencija = iu.NaknadaAgencija;
            this.BonusAgent = iu.BonusAgent;
            this.Period = iu.PeriodIznajmljivanja;
            this.Renta = iu.Renta;
        }
    }

    public class ProdajniUgovorAddUpdate
    {
        public DateTime Datum { get; set; }
        public string ImePrezimeNotara { get; set; }
        public string AdresaNotara { get; set; }
        public int BonusAgent { get; set; }
        public int NaknadaAgencija { get; set; }
        public int PripadaNekretnini { get; set; }
        public int Vlasnik { get; set; }
        public int KupacIznajmljivac { get; set; }
        public int Cena { get; set; }
        public int NaknadaNotar { get; set; }

        public ProdajniUgovorAddUpdate()
        {

        }
    }

    public class IznajmljivanjeUgovorAddUpdate
    {
        public DateTime Datum { get; set; }
        public string ImePrezimeNotara { get; set; }
        public string AdresaNotara { get; set; }
        public int BonusAgent { get; set; }
        public int NaknadaAgencija { get; set; }
        public int PripadaNekretnini { get; set; }
        public int Vlasnik { get; set; }
        public int KupacIznajmljivac { get; set; }
        public int Renta { get; set; }
        public int PeriodIznajmljivanja { get; set; }

        public IznajmljivanjeUgovorAddUpdate()
        {

        }
    }
    #endregion
}
