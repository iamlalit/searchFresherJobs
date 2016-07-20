using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SearchFresherJobsAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API conf iguration and services

            //This takes allowed origins/urls from web.config and sets origin property of cors
            var origins = ConfigurationManager.AppSettings["AllowedUrls"];
            var cors = new EnableCorsAttribute(origins: origins, headers: "*", methods: "*");
            config.EnableCors(cors);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
