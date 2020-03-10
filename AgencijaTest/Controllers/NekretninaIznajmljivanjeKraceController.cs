using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgencijaZaNekretnine;
using AgencijaZaNekretnine.Entiteti;

namespace AgencijaTest.Controllers
{
    public class NekretninaIznajmljivanjeKraceController : ApiController
    {
        // GET: api/NekretninaIznajmljivanjeKrace
        public IEnumerable<NekrIznKracePregled> Get()
        {
            return DTOManager.getNekretnineKraceView();
        }

        // GET: api/NekretninaIznajmljivanjeKrace/5
        public NekrIznKracePregled Get(int id)
        {
            return DTOManager.GetNekretninaIznKrace(id);
        }

        // POST: api/NekretninaIznajmljivanjeKrace
        public void Post([FromBody]NekrIznKraceAddUpdate value)
        {
            DTOManager.addNekretninaKrace(value);
        }

        // PUT: api/NekretninaIznajmljivanjeKrace/5
        public void Put(int id, [FromBody]NekrIznKraceAddUpdate value)
        {
            DTOManager.updateNekretninaKrace(id, value);
        }

        // DELETE: api/NekretninaIznajmljivanjeKrace/5
        public void Delete(int id)
        {
            DTOManager.removeNekretnina(id);
        }
    }
}
