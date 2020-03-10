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
    public class NekretninaIznajmljivanjeDuzeController : ApiController
    {
        // GET: api/NekretninaIznajmljivanjeDuze
        public IEnumerable<NekrIznDuzePregled> Get()
        {
            return DTOManager.getNekretnineDuzeView();
        }

        // GET: api/NekretninaIznajmljivanjeDuze/5
        public NekrIznDuzePregled Get(int id)
        {
            return DTOManager.GetNekretninaIznDuze(id);
        }

        // POST: api/NekretninaIznajmljivanjeDuze
        public void Post([FromBody]NekrIznDuzeAddUpdate value)
        {
            DTOManager.addNekretninaDuze(value);
        }

        // PUT: api/NekretninaIznajmljivanjeDuze/5
        public void Put(int id, [FromBody]NekrIznDuzeAddUpdate value)
        {
            DTOManager.updateNekretninaDuze(id, value);
        }

        // DELETE: api/NekretninaIznajmljivanjeDuze/5
        public void Delete(int id)
        {
            DTOManager.removeNekretnina(id);
        }
    }
}
