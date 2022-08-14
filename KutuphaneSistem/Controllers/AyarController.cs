using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSistem.Models.Entity;

namespace KutuphaneSistem.Controllers
{
    public class AyarController : Controller
    {
        // GET: Ayar
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var admin = db.TBLADMINs.ToList();
            return View(admin);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(TBLADMIN a)
        {
            db.TBLADMINs.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminSil(int id)
        {
            var admin = db.TBLADMINs.Find(id);
            db.TBLADMINs.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGuncelle(int id)
        {
            var admin = db.TBLADMINs.Find(id);
            return View("AdminGuncelle", admin);
        }
        [HttpPost]
        public ActionResult AdminGuncelle(TBLADMIN a)
        {
            var admin = db.TBLADMINs.Find(a.ID);
            admin.KULLANICI = a.KULLANICI;
            admin.SIFRE = a.SIFRE;
            admin.YETKI = a.YETKI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}