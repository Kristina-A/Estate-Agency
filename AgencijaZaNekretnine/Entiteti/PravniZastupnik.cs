using System.Collections.Generic;

namespace AgencijaZaNekretnine.Entiteti
{
    public class PravniZastupnik
    {
        public virtual int Id { get; protected set; }
        public virtual string MBR { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string NazivKancelarije { get; set; }
        public virtual string AdresaKancelarije { get; set; }

        public virtual IList<Ugovor> AngazovaoKupac { get; set; }
        public virtual IList<Ugovor> AngazovaoProdavac { get; set; }

        public PravniZastupnik()
        {
            AngazovaoKupac = new List<Ugovor>();
            AngazovaoProdavac = new List<Ugovor>();
        }
    }
}
