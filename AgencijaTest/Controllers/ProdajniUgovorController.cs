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
    public class ProdajniUgovorController : ApiController
    {
        // GET: api/ProdajniUgovor
        public IEnumerable<ProdajniUgovorPregled> Get()
        {
            return DTOManager.getProdajniUgovoriView();
        }

        // GET: api/ProdajniUgovor/5
        public ProdajniUgovorPregled Get(int id)
        {
            return DTOManager.GetUgovorProdaja(id);
        }

        // POST: api/ProdajniUgovor
        public void Post([FromBody]ProdajniUgovorAddUpdate value)
        {
            DTOManager.addUgovorProdaja(value);
        }

        // PUT: api/ProdajniUgovor/5
        public void Put(int id, [FromBody]ProdajniUgovorAddUpdate value)
        {
            DTOManager.updateUgovorProdaja(id, value);
        }

        // DELETE: api/ProdajniUgovor/5
        public void Delete(int id)
        {
            DTOManager.removeUgovor(id);
        }
    }
}
