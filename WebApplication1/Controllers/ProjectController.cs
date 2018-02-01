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
       static ProjectListModel[] l1 =
        {
            new ProjectListModel (){text="project1",value=1 },
            new ProjectListModel (){text="project2",value=2 },
            new ProjectListModel (){text="project3",value=3 },
        };
        static List<ProjectModel> projects =new List<ProjectModel>()
        {
            new ProjectModel {Id=1,Title="title1", User="sudqi",Projects=l1,selected=1,
                StartTime =DateTime.Today,EndTime=DateTime.Today.AddHours(2),Topic="topic1",Description="d1"},
            new ProjectModel {Id=2,Title="title2", User="randa",Projects= l1,selected=3,
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
            projects[index] = value;

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/Project/5
        public void Post(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Project/5
        public void Delete(int id)
        {
        }
    }
}
