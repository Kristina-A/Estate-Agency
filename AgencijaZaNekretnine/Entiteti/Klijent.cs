using System.Collections.Generic;

namespace AgencijaZaNekretnine.Entiteti
{
    public class Klijent
    {
        public virtual string Email { get; set; }
        public virtual string Sifra { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Adresa { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Kupac { get; set; }
        public virtual string Prodavac { get; set; }
        public virtual int Id { get; protected set; }

        public virtual IList<Nekretnina> NekretnineVlasnik { get; set; }
        public virtual IList<Ugovor> PotpisaniProdavac { get; set; }
        public virtual IList<Ugovor> PotpisaniKupac { get; set; }

        public Klijent()
        {
            NekretnineVlasnik = new List<Nekretnina>();
            PotpisaniProdavac = new List<Ugovor>();
            PotpisaniKupac = new List<Ugovor>();
        }

    }
}
