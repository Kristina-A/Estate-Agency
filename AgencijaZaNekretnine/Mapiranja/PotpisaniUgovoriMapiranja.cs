using FluentNHibernate.Mapping;
using AgencijaZaNekretnine.Entiteti;

namespace AgencijaZaNekretnine.Mapiranja
{
    class PotpisaniUgovoriMapiranja:ClassMap<PotpisaniUgovori>
    {
        public PotpisaniUgovoriMapiranja()
        {
            //Mapiranje tabele
            Table("POTPISANI_UGOVORI");

            //mapiranje primarnog kljuca
            Id(x => x.Kod, "KOD").GeneratedBy.Assigned();

            //mapiranje svojstava
            Map(x => x.PotpUgovori, "POTPISANI_UGOVORI");

            References(x => x.Agent).Column("IDAGENTA").LazyLoad();
        }
    }
}
