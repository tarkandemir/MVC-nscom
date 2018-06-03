using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.DAL;
using MVCProject.BLL;

namespace MVCProject.UI.Controllers
{
    public class ProductManagementController : Controller
    {
        ProductManagementOp productManagement = new ProductManagementOp();
        const int rpp = 20;

        // GET: ProductManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllProducts()
        {
            return View();
        }

        public ActionResult ProductDetail(int id)
        {
            ModelList model = new ModelList();

            model.d1 = productManagement.GetProduct(id);

            return View(model);
        }

        public ActionResult SearchProduct(string s, int cpgn = 1)
        {
            ModelList model = new ModelList();
            List<MMM00> productList = null;

            productList = productManagement.GetProducts(0, 0, s);

            int cnt = productList == null ? 0 : productList.Count;

            model.d1 = productList.Skip((cpgn - 1) * rpp).Take(rpp).ToList();
            ViewBag.MaxPage = Math.Ceiling((decimal)cnt / rpp);
            ViewBag.CurrentPage = cpgn;

            return View("AllProducts", model);
        }

        public ActionResult GetCategoryProductList(int id, string type = "g", int cpgn = 1)
        {
            ModelList model = new ModelList();
            List<MMM00> productList = null;

            if (type == "g")
            {
                ViewBag.MMG00_CODE = id;
                productList = productManagement.GetProducts(id);
            }
            else if (type == "c")
            {
                ViewBag.MMH00_CODE = id;
                productList = productManagement.GetProducts(0, id);
            }


            int cnt = productList == null ? 0 : productList.Count;

            model.d1 = productList.Skip((cpgn - 1) * rpp).Take(rpp).ToList();
            ViewBag.MaxPage = Math.Ceiling((decimal)cnt / rpp);
            ViewBag.CurrentPage = cpgn;

            return View("AllProducts", model);
        }

    }
}