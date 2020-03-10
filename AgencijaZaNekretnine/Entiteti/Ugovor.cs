using System;

namespace AgencijaZaNekretnine.Entiteti
{
    public abstract class Ugovor
    {
        public virtual int Broj { get; protected set; }
        public virtual DateTime Datum { get; set; }
        public virtual string ImePrezimeNotara { get; set; }
        public virtual string AdresaNotara { get; set; }
        public virtual int BonusAgent { get; set; }
        public virtual int NaknadaAgencija { get; set; }
        public virtual Nekretnina PripadaNekretnini { get; set; }
        public virtual Klijent Vlasnik { get; set; }
        public virtual Klijent KupacIznajmljivac { get; set; }
        public virtual PravniZastupnik ZastupnikVlasnik { get; set; }
        public virtual PravniZastupnik ZastupnikKupacIznajmljivac { get; set; }
    }
}
