using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencijaZaNekretnine.Entiteti
{
    public class Agent:Zaposleni
    {
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual int RadniStaz { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Email { get; set; }

        public virtual IList<Nekretnina> Nekretnine { get; set; }
        public virtual IList<PotpisaniUgovori> Ugovori { get; set; }

        public Agent()
        {
            Nekretnine = new List<Nekretnina>();
            Ugovori = new List<PotpisaniUgovori>();
        }
    }
}
