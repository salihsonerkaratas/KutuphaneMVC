using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSistem.Models.Entity;
using System.Web.Security;

namespace KutuphaneSistem.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYELER u)
        {
            var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == u.MAIL && x.SIFRE == u.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                
                return RedirectToAction("Index", "Panel");
            }
            else
            {
                return View();
            }
        }
    }
}