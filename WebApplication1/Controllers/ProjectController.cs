using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProjectController : ApiController
    {
        int counter = 3;
        static List<ProjectModel> projects =new List<ProjectModel>()
        {
            new ProjectModel {Id=1,Title="title1", User="sudqi",Project=1,
                StartTime =DateTime.Today,EndTime=DateTime.Today.AddHours(2),Topic="topic1",Description="d1"},
            new ProjectModel {Id=2,Title="title2", User="randa",Project= 1,
                StartTime =DateTime.Today.AddDays(1),EndTime=DateTime.Today.AddDays(1).AddHours(2),Topic="topic2",Description="d2"},
        };
        // GET: api/Project
        public IEnumerable<ProjectModel> Get()
        {
            return projects;
        }

        // POST: api/Project
        public HttpResponseMessage Put([FromBody]ProjectModel value)
        {
            int index= projects.FindIndex(c=>c.Id==value.Id);

            if (index == -1)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "object not found");
            else
            {
                projects[index] = value;

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        // PUT: api/Project/5
        public HttpResponseMessage Post([FromBody]ProjectModel value)
        {
            value.Id = counter;
            counter++;
            projects.Add(value);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Project/5
        public HttpResponseMessage Delete([FromBody]ProjectModel value)
        {
            int index=projects.FindIndex(c => c.Id == value.Id);
            if (index == -1)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "object not found");
            else
            {
                projects.RemoveAt(index);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}
