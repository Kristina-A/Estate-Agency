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
    public class IznajmljivanjeUgovorController : ApiController
    {
        // GET: api/IznajmljivanjeUgovor
        public IEnumerable<IznajmljivanjeUgovorPregled> Get()
        {
            return DTOManager.getIznajmljivanjeUgovoriView();
        }

        // GET: api/IznajmljivanjeUgovor/5
        public IznajmljivanjeUgovorPregled Get(int id)
        {
            return DTOManager.GetUgovorIznajmljivanje(id);
        }

        // POST: api/IznajmljivanjeUgovor
        public void Post([FromBody]IznajmljivanjeUgovorAddUpdate value)
        {
            DTOManager.addUgovorIznajmljivanje(value);
        }

        // PUT: api/IznajmljivanjeUgovor/5
        public void Put(int id, [FromBody]IznajmljivanjeUgovorAddUpdate value)
        {
            DTOManager.updateUgovorIznajmljivanje(id, value);
        }

        // DELETE: api/IznajmljivanjeUgovor/5
        public void Delete(int id)
        {
            DTOManager.removeUgovor(id);
        }
    }
}
