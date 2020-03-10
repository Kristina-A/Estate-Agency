using FluentNHibernate.Mapping;
using AgencijaZaNekretnine.Entiteti;

namespace AgencijaZaNekretnine.Mapiranja
{
    class PravniZastupnikMapiranja : ClassMap<PravniZastupnik>
    {
        public PravniZastupnikMapiranja()
        {
            //Mapiranje tabele
            Table("PRAVNI_ZASTUPNIK");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.MBR, "MBR");
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.NazivKancelarije, "NAZIV_ADV_KANCELARIJE");
            Map(x => x.AdresaKancelarije, "ADRESA_ADV_KANCELARIJE");

            HasMany(x => x.AngazovaoKupac).KeyColumn("IDZASTUPNIKAKUPACIZNAJMLJIVAC").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.AngazovaoProdavac).KeyColumn("IDZASTUPNIKAVLASNIK").LazyLoad().Cascade.All().Inverse();
        }
    }
}
