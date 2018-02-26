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
    public class UserListController : ApiController
    {
        static UserModel[] users =
        {
            new UserModel()
            {
                text="sudqi",
                value =new Guid("f63b87c5-213c-4e48-ac6f-8b7724c99953"),
            },
            new UserModel()
            {
                text="randa",value=new Guid("f63b87c5-213c-4e48-ac6f-8b7724c99954"),
            }

        };
        // GET: api/UserList
        public IEnumerable<UserModel> Get()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var connString = ConfigurationManager.ConnectionStrings["CRM"].ConnectionString;

            CrmServiceClient conn = new CrmServiceClient(connString);
            IOrganizationService _orgService = (IOrganizationService)conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
            OrganizationServiceContext context;
            //Guid userid = ((WhoAmIResponse)_orgService.Execute(new WhoAmIRequest())).UserId;
            try
            {
                context = new OrganizationServiceContext(_orgService);
                var users = context.CreateQuery("systemuser").
                    Where(c => (c.GetAttributeValue<bool>("isdisabled") == false))
                    .Select(c=>ViewModelFactory.createUserModel(c));
                return users;
            }
            catch(Exception ex)
            {


            }


            return users;
        }

        // GET: api/UserList/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UserList
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UserList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UserList/5
        public void Delete(int id)
        {
        }
    }
}
