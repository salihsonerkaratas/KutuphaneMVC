using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSistem.Models.Entity;

namespace KutuphaneSistem.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLDUYURUs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDuyuru(TBLDUYURU d)
        {
            db.TBLDUYURUs.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TBLDUYURUs.Find(id);
            db.TBLDUYURUs.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(TBLDUYURU d)
        {
            var duyuru = db.TBLDUYURUs.Find(d.ID);
            return View("DuyuruDetay",duyuru);
        }
        public ActionResult DuyuruGuncelle(TBLDUYURU d)
        {
            var duyuru = db.TBLDUYURUs.Find(d.ID);
            duyuru.KATEGORI = d.KATEGORI;
            duyuru.ICERIK = d.ICERIK;
            duyuru.TARIH = d.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}