using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.UI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            if (Response.StatusCode == 200)
                Response.StatusCode = 500;

            return View();
        }

        public ActionResult Forbidden()
        {
            if (Response.StatusCode == 200)
                Response.StatusCode = 403;

            return View();
        }

        public ActionResult Crash()
        {
            if (Response.StatusCode == 200)
                Response.StatusCode = 500;

            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}