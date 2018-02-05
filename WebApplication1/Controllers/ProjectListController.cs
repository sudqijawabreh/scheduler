using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProjectListController : ApiController
    {
                   static ProjectListModel[] l1 =
        {
            new ProjectListModel (){text="hello",value=1 },
            new ProjectListModel (){text="there",value=2 },
            new ProjectListModel (){text="it works",value=3 },
        };
        // GET: api/ProjectList
        public IEnumerable<ProjectListModel> Get()
        {

            return l1;
        }

        // GET: api/ProjectList/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProjectList
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProjectList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProjectList/5
        public void Delete(int id)
        {
        }
    }
}
