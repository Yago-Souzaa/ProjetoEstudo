using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Anuncio2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "MeusAnuncios",
                 url: "meus-anuncios",
                 defaults: new { controller = "Anuncios", action = "MeusAnuncios" }
            );
            routes.MapRoute(
                name: "MeusDados",
                url: "meu-cadastro",
                defaults: new { controller = "Pessoas", action = "Details" }
            );
            routes.MapRoute(
                 name: "Login",
                 url: "entrar",
                 defaults: new { controller = "Pessoas", action = "Login" }
            );
            routes.MapRoute(
                name: "CadastroPessoas",
                url: "cadastro",
                defaults: new { controller = "Pessoas", action = "Create" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Anuncios", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
