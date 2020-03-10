using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencijaZaNekretnine.Entiteti
{
    public abstract class Zaposleni
    {
        public virtual int Id { get; protected set; }
        public virtual string Sifra { get; set; }
    }
}
