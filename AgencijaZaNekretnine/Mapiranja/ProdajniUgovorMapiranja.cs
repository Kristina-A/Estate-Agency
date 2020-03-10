using FluentNHibernate.Mapping;
using AgencijaZaNekretnine.Entiteti;

namespace AgencijaZaNekretnine.Mapiranja
{
    class ProdajniUgovorMapiranja:SubclassMap<ProdajniUgovor>
    {
        public ProdajniUgovorMapiranja()
        {
            Table("PRODAJNI_UGOVOR");

            KeyColumn("BROJ");

            Map(x => x.Cena, "CENA");
            Map(x => x.NaknadaNotar, "NAKNADA_ZA_NOTARA");
        }
    }
}
