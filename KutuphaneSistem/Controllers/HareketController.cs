using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSistem.Models.Entity;

namespace KutuphaneSistem.Controllers
{
    public class HareketController : Controller
    {
        // GET: Odunc
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        [Authorize(Roles ="A")]
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KitapVer()
        {
            List<SelectListItem> deger1 = (from x in db.TBLUYELER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD + " " + x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in db.TBLKİTAP.Where(x=>x.DURUM==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in db.TBLPERSONEL.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PERSONEL,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult KitapVer(TBLHAREKET h)
        {
            var d1 = db.TBLUYELER.Where(x => x.ID == h.TBLUYELER.ID).FirstOrDefault();
            var d2 = db.TBLKİTAP.Where(x => x.ID == h.TBLKİTAP.ID).FirstOrDefault();
            var d3 = db.TBLPERSONEL.Where(x => x.ID == h.TBLPERSONEL.ID).FirstOrDefault();
            h.TBLUYELER = d1;
            h.TBLKİTAP = d2;
            h.TBLPERSONEL = d3;
            db.TBLHAREKET.Add(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitapİade(TBLHAREKET h)
        {
            var kiade = db.TBLHAREKET.Find(h.ID);
            DateTime d1 = DateTime.Parse(kiade.IADETARIH.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Kitapİade", kiade);
        }
        public ActionResult İadeGuncelle(TBLHAREKET h)
        {
            var hrk = db.TBLHAREKET.Find(h.ID);
            hrk.GETIRILENTARIH = h.GETIRILENTARIH;
            hrk.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}