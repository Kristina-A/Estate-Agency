using FluentNHibernate.Mapping;
using AgencijaZaNekretnine.Entiteti;

namespace AgencijaZaNekretnine.Mapiranja
{
    class FotografijaMapiranja : ClassMap<Fotografija>
    {
        public FotografijaMapiranja()
        {
            //Mapiranje tabele
            Table("FOTOGRAFIJA");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.Sadrzaj, "SADRZAJ");

            //mapiranje veze 1:N
            References(x => x.PripadaNekretnini).Column("IDNEKRETNINE").LazyLoad();
        }
    }
}
