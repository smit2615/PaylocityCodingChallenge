using Paylocity.Benefits.WebApi.App_Start;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Paylocity.Benefits.WebApi
{
    public static class WebApiConfig
    {

        private static string _apiVersion = ConfigurationManager.AppSettings["ApiVersion"];

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute(ConfigurationManager.AppSettings["RequestOrigin"], "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: _apiVersion + "/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.DependencyResolver = new UnityResolver(UnityConfig.GetConfiguredContainer());
        }
    }
}
