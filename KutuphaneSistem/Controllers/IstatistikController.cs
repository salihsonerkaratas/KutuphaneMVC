using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSistem.Models.Entity;

namespace KutuphaneSistem.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var deger1 = db.TBLUYELER.Count();
            var deger2 = db.TBLKİTAP.Count();
            var deger3 = db.TBLKİTAP.Where(x => x.DURUM == false).Count();
            var deger4 = db.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult LinqKart()
        {
            var deger1 = db.TBLKİTAP.Count();
            var deger2 = db.TBLUYELER.Count();
            var deger3 = db.TBLCEZALAR.Sum(x => x.PARA);
            var deger4 = db.TBLKİTAP.Where(x=>x.DURUM==false).Count();
            var deger5 = db.TBLKATEGORİ.Count();
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            var deger9 = db.TBLKİTAP.GroupBy(x => x.YAYINEVİ).OrderByDescending(z => z.Count()).
                Select(y => new { y.Key }).FirstOrDefault();
            var deger11 = db.TBLİLETİSİM.Count();
            ViewBag.Dgr1 = deger1;
            ViewBag.Dgr2 = deger2;
            ViewBag.Dgr3 = deger3;
            ViewBag.Dgr4 = deger4;
            ViewBag.Dgr5 = deger5;
            ViewBag.Dgr8 = deger8;
            ViewBag.Dgr9 = deger9;
            ViewBag.Dgr11 = deger11;
            return View();
        }

    }
}