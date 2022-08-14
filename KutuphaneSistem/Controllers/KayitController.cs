using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSistem.Models.Entity;

namespace KutuphaneSistem.Controllers
{
    [AllowAnonymous]
    public class KayitController : Controller
    {
        // GET: Kayit
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(TBLUYELER u)
        {
            if (!ModelState.IsValid)
            {
                return View("KayitOl");
            }
            db.TBLUYELER.Add(u);
            db.SaveChanges();
            return View();
        }
    }
}