using MVCProject.BLL;
using MVCProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.UI.Controllers
{
    public class HomeController : Controller
    {

        UserManagementOp UserManagement = new UserManagementOp();
        ProductManagementOp productManagement = new ProductManagementOp();


        public ActionResult Index()
        {
            ModelList model = new ModelList();
            List<MMM00> productList = productManagement.GetProducts().OrderBy(u => u.MMM00_ID).Take(5).ToList();
            model.d1 = productList;

            List<MMM00> productList2 = productManagement.GetProducts().OrderByDescending(u => u.MMM00_ID).Take(5).ToList();
            model.d2 = productList2;

            return View(model);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult _Contact(FormCollection formData)
        {
            GeneralOp generalOp = new GeneralOp();

            SendMail sm = new SendMail()
            {
                email = formData["email"],
                text = formData["text"],
                title = formData["title"]
            };


            JsonReturn jsonReturn = UserManagement._sendContact(sm);

            return Json(jsonReturn, JsonRequestBehavior.AllowGet);
        }
    }
}