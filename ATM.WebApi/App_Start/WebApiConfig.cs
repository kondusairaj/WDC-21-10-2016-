using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Web.Http;
using ATM.WebApi.BLL.Implementation;
using ATM.WebApi.BLL.Interface;
using ATM.WebApi.Services.Implementation;
using ATM.WebApi.Services.Interface;

namespace ATM.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ICashDispencerService, CashDispencerService>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccount, InOperativeAccount>("InOperativeAccount");
            container.RegisterType<IAccount, ActiveAccount>("ActiveAccount");
            container.RegisterType<IAccount, ClosedAccount>("ClosedAccount");
            container.RegisterType<IEnumerable<IAccount>, IAccount[]>();
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

            config.Routes.MapHttpRoute(
                name: "GetAccountAndTransactionStatus",
                routeTemplate: "api/{controller}/{action}/{operation}/{accountType}",
                //defaults: new { action = RouteParameter.Optional }
                defaults: new { controller= "ATM", action = "GetAccountAndTransactionStatus" }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
