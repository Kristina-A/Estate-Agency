using AgencijaZaNekretnine.Entiteti;
using FluentNHibernate.Mapping;

namespace AgencijaZaNekretnine.Mapiranja
{
    public class KlijentMapiranja : ClassMap<Klijent>
    {
        public KlijentMapiranja()
        {
            //Mapiranje Tabele
            Table("KLIJENT");

            //Mapiranje Primarnog Kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //Mapiranje Svojstava
            Map(x => x.Email, "EMAIL");
            Map(x => x.Sifra, "SIFRA");
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Adresa, "ADRESA");
            Map(x => x.Telefon, "TELEFON");
            Map(x => x.Kupac, "KUPAC");
            Map(x => x.Prodavac, "PRODAVAC");

            //Mapiranje 1:N veza, na 1 strani
            HasMany(x => x.NekretnineVlasnik).KeyColumn("IDVLASNIKA").LazyLoad().Cascade.All().Inverse(); //referencira odgovarajucu kolonu u tabeli nekretnina
            HasMany(x => x.PotpisaniProdavac).KeyColumn("IDVLASNIKA").LazyLoad().Cascade.All().Inverse(); //referencira odgovarajucu kolonu u tabeli ugovor
            HasMany(x => x.PotpisaniKupac).KeyColumn("IDKUPCA_IZNAJMLJIVACA").LazyLoad().Cascade.All().Inverse(); //referencira odgovarajucu kolonu u tabeli ugovor

        }
    }
}
