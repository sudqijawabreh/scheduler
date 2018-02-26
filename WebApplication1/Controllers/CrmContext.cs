using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication1.Controllers
{
    public class CrmContext
    {

           static string  connString = ConfigurationManager.ConnectionStrings["CRM"].ConnectionString;

            static CrmServiceClient conn = new CrmServiceClient(connString);
            static IOrganizationService _orgService = (IOrganizationService)conn.OrganizationWebProxyClient != null ? (IOrganizationService)conn.OrganizationWebProxyClient : (IOrganizationService)conn.OrganizationServiceProxy;
                static OrganizationServiceContext context= new OrganizationServiceContext(_orgService);

        public static OrganizationServiceContext getContext()
        {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                return context;
        }
    }
}