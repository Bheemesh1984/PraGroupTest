using Microsoft.Practices.Unity;
using PraGroupTest.Service.Contracts;
using PraGroupTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using PraGroupUI.InfraStructure;


namespace PraGroupUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        public static UnityContainer container;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            container = new UnityContainer();
            container.RegisterType<IDataRepository, XMLDataRepository>();
           
            var dingdong = AllClasses.FromLoadedAssemblies().Where(type => typeof(IPriceCalculator).IsAssignableFrom(type)).ToList();
            container.RegisterTypes(AllClasses.FromLoadedAssemblies().Where(type => typeof(IPriceCalculator).IsAssignableFrom(type)), WithMappings.FromAllInterfaces, WithName.TypeName);
            container.RegisterType<IProcessorLocator, ProcessorLocator>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}