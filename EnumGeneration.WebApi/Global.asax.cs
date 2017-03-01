using EnumGeneration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EnumGeneration
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IEnumerable<Type> enumsToUse = new List<Type>()
            {
                typeof(Jedi),
                typeof(LightSaber),
            };

            var generator = new JavascriptEnumFileGeneration();
            var contents = generator.GenerateFileContents(enumsToUse, "Enums");

            var filePath = Server.MapPath("Scripts") + "\\Enums.js";
            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    //System.IO.File.WriteAllText(filePath, contents);
                }
                catch (UnauthorizedAccessException)
                {
                    // Swallow because we are not able to do anything about it now.
                }
            }
        }
    }
}
