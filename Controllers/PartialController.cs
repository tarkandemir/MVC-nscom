using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.BLL;

namespace MVCProject.UI.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult CartDropdown()
        {
            return PartialView();
        }

        public ActionResult TopLinks()
        {
            return PartialView();
        }

        public ActionResult CategoryList()
        {
            ModelList model = new ModelList();

            ProductManagementOp productManagement = new ProductManagementOp();
            model.d1 = productManagement.GetCategories();

            return PartialView(model);
        }

        public ActionResult Category6Limit()
        {
            ModelList model = new ModelList();

            ProductManagementOp productManagement = new ProductManagementOp();
            model.d1 = productManagement.GetCategories(6);

            return PartialView(model);
        }
    }
}