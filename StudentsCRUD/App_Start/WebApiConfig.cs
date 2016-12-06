using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Routing;

namespace StudentsCRUD
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
           name: "Api_Put",
           routeTemplate: "api/{controller}/{id}/{action}",
           defaults: new { id = RouteParameter.Optional, action = "Put" },
           constraints: new { httpMethod = new HttpMethodConstraint("PUT") }
        );

            config.Routes.MapHttpRoute(
               name: "WithActionApi",
               routeTemplate: "api/{controller}/{action}/{studentID}"
           );

            config.Routes.MapHttpRoute(
                name: "InsertApi",
                routeTemplate: "api/{controller}/{firstname}"
               
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "Get" }
            );
        }
    }
}
