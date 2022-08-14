using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSistem.Models.Entity;

namespace KutuphaneSistem.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBLKİTAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.AD.Contains(p));
            }
            //var kitaplar = db.TBLKİTAP.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORİ.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKİTAP ktp)
        {
            var ktg = db.TBLKATEGORİ.Where(k => k.ID == ktp.TBLKATEGORİ.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == ktp.TBLYAZAR.ID).FirstOrDefault();
            ktp.TBLKATEGORİ = ktg;
            ktp.TBLYAZAR = yzr;
            db.TBLKİTAP.Add(ktp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKİTAP.Find(id);
            db.TBLKİTAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.TBLKİTAP.Find(id);
            
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORİ.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGuncelle(TBLKİTAP k)
        {
            var ktp = db.TBLKİTAP.Find(k.ID);
            ktp.AD = k.AD;
            ktp.BASIMYIL = k.BASIMYIL;
            ktp.SAYFA = k.SAYFA;
            ktp.YAYINEVİ = k.YAYINEVİ;
            //ktp.DURUM = true;
            var ktg = db.TBLKATEGORİ.Where(kat => kat.ID == k.TBLKATEGORİ.ID).FirstOrDefault();
            var yzr = db.TBLYAZAR.Where(y => y.ID == k.TBLYAZAR.ID).FirstOrDefault();
            ktp.KATEGORİ = ktg.ID;
            ktp.YAZAR = yzr.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}