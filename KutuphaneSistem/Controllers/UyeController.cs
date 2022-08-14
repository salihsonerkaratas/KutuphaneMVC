﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSistem.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace KutuphaneSistem.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKutuphaneEntities db = new DBKutuphaneEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.TBLUYELER.ToList();
            var degerler = db.TBLUYELER.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER uye)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLUYELER.Add(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TBLUYELER u)
        {
            var uye = db.TBLUYELER.Find(u.ID);
            uye.AD = u.AD;
            uye.SOYAD = u.SOYAD;
            uye.MAIL = u.MAIL;
            uye.KULLANICIADI = u.KULLANICIADI;
            uye.SIFRE = u.SIFRE;
            uye.FOTOGRAF = u.FOTOGRAF;
            uye.TELEFON = u.TELEFON;
            uye.OKUL = u.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KitapGecmis(int id)
        {
            var ktpgecmis = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uyekit = db.TBLUYELER.Where(x => x.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.u1 = uyekit;
            return View(ktpgecmis);
        }
    }
}