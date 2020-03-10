using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencijaZaNekretnine.Entiteti;
using FluentNHibernate.Mapping;

namespace AgencijaZaNekretnine.Mapiranja
{
    public class AgentMapiranja : SubclassMap<Agent>
    {
        public AgentMapiranja()
        {
            //Mapiranje Tabele
            Table("AGENT");

            Abstract();

            //Mapiranje Svojstava
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.RadniStaz, "RADNI_STAZ_U_AGENCIJI");
            Map(x => x.Telefon, "TELEFON");
            Map(x => x.Email, "EMAIL");

            //Mapiranje 1:N veze, 1 strana
            HasMany(x => x.Nekretnine).KeyColumn("IDAGENTA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Ugovori).KeyColumn("IDAGENTA").LazyLoad().Cascade.All().Inverse();//visevrednosni atribut, referencira se na idagenta u tabeli potpisani ugovori
        }
    }
}
