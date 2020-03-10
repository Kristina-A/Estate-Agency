using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencijaZaNekretnine.Entiteti;
using FluentNHibernate.Mapping;

namespace AgencijaZaNekretnine.Mapiranja
{
    class ZaposleniMapiranja:ClassMap<Zaposleni>
    {
        public ZaposleniMapiranja()
        {
            UseUnionSubclassForInheritanceMapping();

            Id(x => x.Id,"ID").GeneratedBy.TriggerIdentity();
            Map(x => x.Sifra, "SIFRA");
        }
    }
}
