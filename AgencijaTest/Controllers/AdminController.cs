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
    public class AdminController : ApiController
    {
        // GET: api/Admin
        public IEnumerable<Administrator> Get()
        {
            IEnumerable<Administrator> admini = DTOManager.GetAdmini();
            return admini;
        }

        // GET: api/Admin/5
        public Administrator Get(int id)
        {
            return DTOManager.GetAdmin(id);
        }

        // POST: api/Admin
        public void Post([FromBody]Administrator a)
        {
            DTOManager.addAdmin(a);
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]Administrator a)
        {
            DTOManager.updateAdmin(id, a);
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
            DTOManager.removeAdmin(id);
        }
    }
}
