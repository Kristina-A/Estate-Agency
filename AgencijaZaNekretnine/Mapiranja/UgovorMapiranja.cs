using FluentNHibernate.Mapping;
using AgencijaZaNekretnine.Entiteti;

namespace AgencijaZaNekretnine.Mapiranja
{
    class UgovorMapiranja:ClassMap<Ugovor>
    {
        public UgovorMapiranja()
        {
            //Mapiranje tabele
            Table("UGOVOR");

            //mapiranje primarnog kljuca
            Id(x => x.Broj, "BROJ").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.Datum, "DATUM");
            Map(x => x.ImePrezimeNotara, "IME_I_PREZIME_NOTARA");
            Map(x => x.AdresaNotara, "ADRESA_NOTARA");
            Map(x => x.BonusAgent, "BONUS_ZA_AGENTA");
            Map(x => x.NaknadaAgencija, "NAKNADA_ZA_AGENCIJU");

            References(x => x.PripadaNekretnini).Column("IDNEKRETNINE").LazyLoad();
            References(x => x.Vlasnik).Column("IDVLASNIKA").LazyLoad();
            References(x => x.KupacIznajmljivac).Column("IDKUPCA_IZNAJMLJIVACA").LazyLoad();
            References(x => x.ZastupnikVlasnik).Column("IDZASTUPNIKAVLASNIK").LazyLoad();
            References(x => x.ZastupnikKupacIznajmljivac).Column("IDZASTUPNIKAKUPACIZNAJMLJIVAC").LazyLoad();
        }
    }
}
