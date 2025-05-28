using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ecinema_site.Domain;
using Ecinema_site.BusinessLogic.Interfaces;
using Ecinema_site.BusinessLogic.Repositories;
using Ecinema_site.BusinessLogic.Services;
using Unity;
using Unity.Mvc5;
using System.Web.Optimization;
using Ecinema_site.Web.App_Start;

namespace Ecinema_site.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Configure Unity Container
            var container = new UnityContainer();
            
            // Register DbContext
            container.RegisterType<EcinemaDbContext>();
            
            // Register Repositories
            container.RegisterType<IMovieRepository, MovieRepository>();
            
            // Register Services
            container.RegisterType<IMovieService, MovieService>();
            
            // Set the dependency resolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // Register bundles
            BundleConfig.RegisterBundle(BundleTable.Bundles);
            // Enable bundling/minification in debug mode for testing
            BundleTable.EnableOptimizations = true;
        }
    }
}