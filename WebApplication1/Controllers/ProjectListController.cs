﻿using Microsoft.Xrm.Sdk;
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
    public class ProjectListController : ApiController
    {
                   static ProjectModel[] l1 =
        {
            new ProjectModel (){text="CRM",value=new       Guid("{01f3b166-9016-e811-a834-000d3a13a9c6}" )},
            new ProjectModel (){text="resturant",value=new Guid("{BD5DC65A-9016-E811-A834-000D3A13A9C6}" )},
        };
        // GET: api/ProjectList
        public IEnumerable<ProjectModel> Get()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var connString = ConfigurationManager.ConnectionStrings["CRM"].ConnectionString;

            CrmServiceClient conn = new CrmServiceClient(connString);
            IOrganizationService _orgService = (IOrganizationService)conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
            OrganizationServiceContext context;
            try
            {
                context = new OrganizationServiceContext(_orgService);
                var tasks = context.CreateQuery("schedule_project");
            var t = tasks.Select(x => ViewModelFactory.createProjectModel(x)).ToList();
                return t;
            }
            catch(Exception ex)
            {


            }


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
