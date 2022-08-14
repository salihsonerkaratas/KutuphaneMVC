using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSistem.Models.Entity;

namespace KutuphaneSistem.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
        public ActionResult Detay(TBLHAREKET h)
        {
            var kiade = db.TBLHAREKET.Find(h.ID);
            DateTime d1 = DateTime.Parse(kiade.IADETARIH.ToString());
            DateTime d2 = DateTime.Parse(kiade.GETIRILENTARIH.ToString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View(kiade);
        }
    }
}