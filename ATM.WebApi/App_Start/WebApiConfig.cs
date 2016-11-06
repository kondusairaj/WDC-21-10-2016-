using ATM.Services.Implementation;
using ATM.Services.Interface;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ATM.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ICashDispencerService, CashDispencerService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);


            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{amount}",
                defaults: new { amount = RouteParameter.Optional }
                //defaults: new { controller= "CashDispencing", action = "GetNoOfNotesAndDenomination" }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
