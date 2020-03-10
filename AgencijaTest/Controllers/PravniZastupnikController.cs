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
    public class PravniZastupnikController : ApiController
    {
        // GET: api/PravniZastupnik
        public IEnumerable<ZastupnikPregled> Get()
        {
            IEnumerable<ZastupnikPregled> zastupnici = DTOManager.GetZastupnikInfos();
            return zastupnici;
        }

        // GET: api/PravniZastupnik/5
        public ZastupnikView Get(int id)
        {
            return DTOManager.getZastupnikView(id);
        }

        // POST: api/PravniZastupnik
        public void Post([FromBody]PravniZastupnik value)
        {
            DTOManager.addZastupnik(value);
        }

        // PUT: api/PravniZastupnik/5
        public void Put(int id, [FromBody]PravniZastupnik value)
        {
            DTOManager.updateZastupnik(id, value);
        }

        // DELETE: api/PravniZastupnik/5
        public void Delete(int id)
        {
            DTOManager.removeZastupnik(id);
        }
    }
}
