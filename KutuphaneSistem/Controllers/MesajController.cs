using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSistem.Models.Entity;

namespace KutuphaneSistem.Controllers
{
    public class MesajController : Controller
    {
        // GET: Mesaj
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLARs.Where(x=>x.ALICI == uyemail.ToString()).ToList(); 
            return View(mesajlar);
        }
        public ActionResult GonderilenMesaj()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLARs.Where(x => x.GONDEREN == uyemail.ToString()).ToList();
            return View(mesajlar);
        } 
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR m)
        {
            var uyemail = (string)Session["Mail"].ToString();
            m.GONDEREN = uyemail.ToString();
            m.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLMESAJLARs.Add(m);
            db.SaveChanges();
            return RedirectToAction("GonderilenMesaj","Mesaj");
        }
        public PartialViewResult Partial1()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var gelensayisi = db.TBLMESAJLARs.Where(x => x.ALICI == uyemail).Count();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = db.TBLMESAJLARs.Where(x => x.GONDEREN == uyemail).Count();
            ViewBag.d2 = gidensayisi;
            return PartialView();
        }
    }
}