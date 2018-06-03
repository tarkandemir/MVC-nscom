using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCProject.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //UserManagement REWRITE
            routes.MapRoute(
                name: "Login",
                url: "giris",
                defaults: new { controller = "UserManagement", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Register",
                url: "kayit-ol",
                defaults: new { controller = "UserManagement", action = "Register", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "LostPassword",
                url: "sifremi-unuttum",
                defaults: new { controller = "UserManagement", action = "LostPassword", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Account",
                url: "hesabim",
                defaults: new { controller = "UserManagement", action = "Account", id = UrlParameter.Optional }
            );

            //ProductManagement REWRITE
            routes.MapRoute(
                 name: "SearchLink1",
                 url: "urunler/arama/sayfa-{cpgn}",
                 defaults: new { controller = "ProductManagement", action = "SearchProduct", s = UrlParameter.Optional, cpgn = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CategoryLink1",
                url: "urunler/{name}-c-{id}/sayfa-{cpgn}",
                defaults: new { controller = "ProductManagement", action = "GetCategoryProductList", id = UrlParameter.Optional, type = "c", cpgn = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CategoryLink2",
                url: "urunler/{name}-g-{id}/sayfa-{cpgn}",
                defaults: new { controller = "ProductManagement", action = "GetCategoryProductList", id = UrlParameter.Optional, type = "g", cpgn = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AllProducts1",
                url: "tum-urunler/sayfa-{cpgn}",
                defaults: new { controller = "ProductManagement", action = "AllProducts", cpgn = UrlParameter.Optional }
            );

            // pagingless
            routes.MapRoute(
                 name: "SearchLink2",
                 url: "urunler/arama",
                 defaults: new { controller = "ProductManagement", action = "SearchProduct", s = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "CategoryLink3",
                url: "urunler/{name}-c-{id}",
                defaults: new { controller = "ProductManagement", action = "GetCategoryProductList", id = UrlParameter.Optional, type = "c" }
            );
            routes.MapRoute(
                name: "CategoryLink4",
                url: "urunler/{name}-g-{id}",
                defaults: new { controller = "ProductManagement", action = "GetCategoryProductList", id = UrlParameter.Optional, type = "g" }
            );

            //PRODUCT DETAIL
            routes.MapRoute(
                name: "ProductDetail",
                url: "urun/{name}-m-{id}",
                defaults: new { controller = "ProductManagement", action = "ProductDetail", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "About",
                url: "hakkimizda",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Contact",
                url: "iletisim",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
