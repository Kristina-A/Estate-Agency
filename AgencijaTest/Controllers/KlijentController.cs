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
    public class KlijentController : ApiController
    {
        // GET: api/Klijent
        public IEnumerable<KlijentPregled> Get()
        {
            return DTOManager.GetKlijentInfos();
        }

        // GET: api/Klijent/5
        public KlijentView Get(int id)
        {
            return DTOManager.getKlijentView(id);
        }

        // POST: api/Klijent
        public void Post([FromBody]Klijent value)
        {
            DTOManager.addKlijent(value);
        }

        // PUT: api/Klijent/5
        public void Put(int id, [FromBody]Klijent value)
        {
            DTOManager.updateKlijent(id, value);
        }

        // DELETE: api/Klijent/5
        public void Delete(int id)
        {
            DTOManager.removeKlijent(id);
        }
    }
}
