using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TaskController : ApiController
    {
        //static List<TaskModel> projects =new List<TaskModel>()
        //{
        //    new TaskModel {
        //        Id =new Guid("f63b87c5-213c-4e48-ac6f-8b7724c99963"),
        //        UserId =new Guid("f63b87c5-213c-4e48-ac6f-8b7724c99953"),
        //        ProjectId =new Guid("01f3b166-9016-e811-a834-000d3a13a9c"),
        //        StartTime =DateTime.Today,EndTime=DateTime.Today.AddHours(2),Topic="topic1",Description="d1"},

        //    new TaskModel {Id=new Guid("f63b87c5-213c-4e48-ac6f-8b7724c99973"), UserId=new Guid("f63b87c5-213c-4e48-ac6f-8b7724c99954"),
        //        ProjectId=new Guid("BD5DC65A-9016-E811-A834-000D3A13A9C6"),
        //        StartTime =DateTime.Today.AddDays(1),EndTime=DateTime.Today.AddDays(1).AddHours(2),Topic="topic2",Description="d2"},
        //};
        // GET: api/Project
        public IEnumerable<TaskModel> Get()
        {

            var context = CrmContext.getContext();

            var tasks = context.CreateQuery("task");
            var t = tasks.Select(x => ViewModelFactory.createTaskModel(x)).ToList();
            context.SaveChanges();
            return t;
        }

        public HttpResponseMessage Put([FromBody]TaskModel value)
        {

            var context = CrmContext.getContext();
            Entity task = ViewModelFactory.ParseTask(value);
            context.Attach(task);
            context.UpdateObject(task);
            context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);

        }


        public HttpResponseMessage Post([FromBody]TaskModel value)
        {
            var context = CrmContext.getContext();
            Entity task = ViewModelFactory.ParseTask(value);
            context.AddObject(task);
            var y = context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Project/5
        public HttpResponseMessage Delete([FromBody]TaskModel value)
        {
            var context = CrmContext.getContext();
            Entity task = ViewModelFactory.ParseTask(value);
            context.Attach(task);
            context.DeleteObject(task);
            context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}
