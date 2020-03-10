using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencijaZaNekretnine.Entiteti;
using FluentNHibernate.Mapping;

namespace AgencijaZaNekretnine.Mapiranja
{
    public class AdministratorMapiranja : SubclassMap<Administrator>
    {
        public AdministratorMapiranja()
        {
            //Mapiranje Tabele
            Table("ADMINISTRATOR");

            Abstract();

        }
    }
}
