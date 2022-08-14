using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using KutuphaneSistem.Models.Entity;

namespace KutuphaneSistem.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        // GET: AdminLogin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLADMIN a)
        {
            var bilgiler = db.TBLADMINs.FirstOrDefault(x => x.KULLANICI == a.KULLANICI && x.SIFRE == a.SIFRE);
            if(bilgiler!= null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI, false);
                Session["KULLANICI"] = bilgiler.KULLANICI.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "AdminLogin");
        }
    }
}