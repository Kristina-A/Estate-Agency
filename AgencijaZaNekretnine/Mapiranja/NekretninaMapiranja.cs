using FluentNHibernate.Mapping;
using AgencijaZaNekretnine.Entiteti;

namespace AgencijaZaNekretnine.Mapiranja
{
    class NekretninaMapiranja : ClassMap<Nekretnina>
    {
        public NekretninaMapiranja()
        {
            //Mapiranje tabele
            Table("NEKRETNINA");

            //mapiranje podklasa
            DiscriminateSubClassesOnColumn("PRODAJA_ILI_IZNAJMLJIVANJE");

            //mapiranje primarnog kljuca
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava
            Map(x => x.IdUgovora, "ID_UGOVORA");
            Map(x => x.GradLokacija, "GRAD_I_LOKACIJA");
            Map(x => x.Ulica, "ULICA");
            Map(x => x.Broj, "BROJ");
            Map(x => x.BrojParcele, "BROJ_KATASTARSKE_PARCELE");
            Map(x => x.KatastarskaOpstina, "KATASTARSKA_OPSTINA");
            Map(x => x.Kvadratura, "KVADRATURA");
            Map(x => x.DatumIzgradnje, "DATUM_IZGRADNJE");
            Map(x => x.Cena, "CENA");
            Map(x => x.SpratBrSpratova, "SPRAT_BROJ_SPRATOVA");
            Map(x => x.Opis, "OPIS");
            Map(x => x.Tip, "TIP");

            References(x => x.ZaduzenAgent).Column("IDAGENTA").LazyLoad();
            References(x => x.Vlasnik).Column("IDVLASNIKA").LazyLoad();

            HasOne(x => x.Ugovor).PropertyRef(x => x.PripadaNekretnini);

            HasMany(x => x.Fotografije).KeyColumn("IDNEKRETNINE").LazyLoad().Cascade.All().Inverse();
        }
    }

    class NekretninaProdajaMapiranja : SubclassMap<NekretninaProdaja>
    {
        public NekretninaProdajaMapiranja()
        {
            DiscriminatorValue("PRODAJA");
        }
    }

    class NekretninaIznajmljivanjeKraceMapiranja : SubclassMap<NekretninaIznajmljivanjeKrace>
    {
        public NekretninaIznajmljivanjeKraceMapiranja()
        {
            DiscriminatorValue("IZNAJMLJIVANJE KRACE");
            Map(x => x.DatumOd, "DATUM_OD");
            Map(x => x.DatumDo, "DATUM_DO");
            Map(x => x.Godina, "GODINA");
        }
    }

    class NekretninaIznajmljivanjeDuzeMapiranja : SubclassMap<NekretninaIznajmljivanjeDuze>
    {
        public NekretninaIznajmljivanjeDuzeMapiranja()
        {
            DiscriminatorValue("IZNAJMLJIVANJE DUZE");
            Map(x => x.MaxMeseci, "MAX_BR_MESECI");
            Map(x => x.FizickaLicaFirme, "FIZICKIM_LICIMA_ILI_FIRMAMA");
        }
    }

}
