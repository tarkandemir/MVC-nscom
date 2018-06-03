using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.DAL;
using MVCProject.BLL;
using System.Web.Security;
using System.IO;

namespace MVCProject.UI.Controllers
{
    public class UserManagementController : Controller
    {
        UserManagementOp UserManagement = new UserManagementOp();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult LostPassword()
        {
            return View();
        }

        public ActionResult Account()
        {
            URM00 loginUser = (URM00)Session["loginUser"];

            if (loginUser == null)
                return Redirect("/giris");
            else
            {
                URM00 user = UserManagement.GetUser(loginUser.URM00_CODE);
                return View(user);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult _Login(LoginParams loginParams)
        {
            JsonReturn jsonReturn = UserManagement._doLogin(loginParams.EMAIL, loginParams.URM00_PASSWD);

            URM00 loginUser = (URM00)jsonReturn.Data;

            if (loginUser != null)
            {
                Session["loginUser"] = loginUser;

                if (loginParams.REMEMBER)
                {
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                      1,
                      loginUser.URM00_CODE.ToString(),
                      DateTime.Now,
                      DateTime.Now.AddMinutes(20),
                      true,
                      "",
                      "/"
                    );

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                    Response.Cookies.Add(cookie);
                }
            }

            return Json(jsonReturn, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult _Register(URM00 user)
        {
            return Json(UserManagement._doRegister(user), JsonRequestBehavior.AllowGet);
        }

        public JsonResult _Logout()
        {
            Session.RemoveAll();
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult _UpdateInformation(FormCollection formData)
        {
            byte[] byteImg = null;

            URM00 user = new URM00()
            {
                URM00_CODE = Int32.Parse(formData["URM00_CODE"]),
                FIRSTNAME = formData["FIRSTNAME"],
                SURNAME = formData["SURNAME"],
                URM00_PASSWD = formData["URM00_PASSWD"],
                PHONE_1 = formData["PHONE_1"]
            };

            HttpPostedFileBase file = null;
            try
            {
                file = Request.Files[0];
            }
            catch { }

            if (file != null && file.ContentLength > 0)
            {
                string path = Server.MapPath(string.Format("~/assets/images/uploads/{0}{1}", Guid.NewGuid(), file.FileName));
                file.SaveAs(path);

                byteImg = System.IO.File.ReadAllBytes(path);

                System.IO.File.Delete(path);

                user.URM00_IMG = byteImg;
            }



            return Json(UserManagement._updateInfo(user), JsonRequestBehavior.AllowGet);
        }

        public JsonResult _UpdateNewsletter(string email)
        {
            return Json(UserManagement._newsletterControl(email), JsonRequestBehavior.AllowGet);
        }

        public JsonResult _LostPassword(string email)
        {
            return Json(UserManagement._lostPassword(email), JsonRequestBehavior.AllowGet);
        }
    }
}