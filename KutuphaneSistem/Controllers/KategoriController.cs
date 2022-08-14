using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSistem.Models.Entity;
namespace KutuphaneSistem.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORİ.Where(x => x.DURUM == true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORİ k)
        {
            db.TBLKATEGORİ.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = db.TBLKATEGORİ.Find(id);
            //db.TBLKATEGORİ.Remove(ktg);
            ktg.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AktifKategori(int id)
        {
            var ktg = db.TBLKATEGORİ.Find(id);
            ktg.DURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATEGORİ.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORİ k)
        {
            var ktg = db.TBLKATEGORİ.Find(k.ID);
            ktg.AD = k.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PasifKategori()
        {
            var degerler = db.TBLKATEGORİ.Where(x => x.DURUM == false).ToList();
            return View(degerler);
        }
    }
}