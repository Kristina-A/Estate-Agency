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
    public class NekretninaProdajaController : ApiController
    {
        // GET: api/NekretninaProdaja
        public IEnumerable<NekretninaProdajaPregled> Get()
        {
            return DTOManager.getNekretnineProdajaView();
        }

        // GET: api/NekretninaProdaja/5
        public NekretninaProdajaPregled Get(int id)
        {
            return DTOManager.GetNekretninaProdaja(id);
        }

        // POST: api/NekretninaProdaja
        public void Post([FromBody]NekretninaProdajaAddUpdate value)
        {
            DTOManager.addNekretninaProdaja(value);
        }

        // PUT: api/NekretninaProdaja/5
        public void Put(int id, [FromBody]NekretninaProdajaAddUpdate value)
        {
            DTOManager.updateNekretninaProdaja(id, value);
        }

        // DELETE: api/NekretninaProdaja/5
        public void Delete(int id)
        {
            DTOManager.removeNekretnina(id);
        }
    }
}
