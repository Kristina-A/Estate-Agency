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
    public class AgentController : ApiController
    {
        // GET: api/Agent
        public IEnumerable<AgentPregled> Get()
        {
            return DTOManager.GetAgentInfos();
        }

        // GET: api/Agent/5
        public AgentView Get(int id)
        {
            return DTOManager.getAgentView(id);
        }

        // POST: api/Agent
        public void Post([FromBody]Agent value)
        {
            DTOManager.addAgent(value);
        }

        // PUT: api/Agent/5
        public void Put(int id, [FromBody]Agent value)
        {
            DTOManager.updateAgent(id, value);
        }

        // DELETE: api/Agent/5
        public void Delete(int id)
        {
           DTOManager.removeAgent(id);
        }
    }
}
