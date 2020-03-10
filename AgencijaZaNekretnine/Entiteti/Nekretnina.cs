using System;
using System.Collections.Generic;

namespace AgencijaZaNekretnine.Entiteti
{
    public abstract class Nekretnina
    {
        public virtual int Id { get; protected set; }
        public virtual string IdUgovora { get; set; }
        public virtual string GradLokacija { get; set; }
        public virtual string Ulica { get; set; }
        public virtual int Broj { get; set; }
        public virtual string BrojParcele { get; set; }
        public virtual string KatastarskaOpstina { get; set; }
        public virtual string Tip { get; set; }
        public virtual decimal Kvadratura { get; set; }
        public virtual DateTime DatumIzgradnje { get; set; }
        public virtual int Cena { get; set; }
        public virtual string SpratBrSpratova { get; set; }
        public virtual string Opis { get; set; }
        public virtual string ProdajaIznajmljivanje { get; set; }
        public virtual Agent ZaduzenAgent { get; set; }
        public virtual Klijent Vlasnik { get; set; }
        public virtual Ugovor Ugovor { get; set; }

        public virtual IList<Fotografija> Fotografije { get; set; }

        public Nekretnina()
        {
            Fotografije = new List<Fotografija>();
        }
    }

    public class NekretninaProdaja : Nekretnina
    {

    }

    public class NekretninaIznajmljivanjeKrace : Nekretnina
    {
        public virtual DateTime DatumOd { get; set; }
        public virtual DateTime DatumDo { get; set; }
        public virtual int Godina { get; set; }
    }

    public class NekretninaIznajmljivanjeDuze : Nekretnina
    {
        public virtual int MaxMeseci { get; set; }
        public virtual string FizickaLicaFirme { get; set; }
    }
}
