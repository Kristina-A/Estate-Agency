using FluentNHibernate.Mapping;
using AgencijaZaNekretnine.Entiteti;

namespace AgencijaZaNekretnine.Mapiranja
{
    class IznajmljivanjeUgovorMapiranja:SubclassMap<IznajmljivanjeUgovor>
    {
        public IznajmljivanjeUgovorMapiranja()
        {
            Table("IZNAJMLJIVANJE_UGOVOR");

            KeyColumn("BROJ");

            Map(x => x.PeriodIznajmljivanja, "PERIOD_IZNAJMLJIVANJA");
            Map(x => x.Renta, "MESECNA_RENTA");
        }
    }
}
