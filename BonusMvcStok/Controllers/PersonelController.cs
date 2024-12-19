using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace BonusMvcStok.Controllers
{
    public class PersonelController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index(string p)
        {
            var personel = db.TblPersonel.Where(x => x.durum == true);
            if (!string.IsNullOrEmpty(p))
            {
                personel = personel.Where(x => (x.ad.Contains(p) || x.soyad.Contains(p)) && x.durum == true);
            }
            return View(personel.ToList());
        }
        [HttpGet]
        public ActionResult YeniPersonel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniPersonel(TblPersonel p)
        { 
            p.durum = true;
            db.TblPersonel.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(TblPersonel p)
        {
            var personelbul = db.TblPersonel.Find(p.id);
            personelbul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var personel = db.TblPersonel.Find(id);
            return View("PersonelGetir", personel);
        }
        public ActionResult PersonelGuncelle(TblPersonel p)
        {
            var personel = db.TblPersonel.Find(p.id);
            personel.ad = p.ad;
            personel.soyad = p.soyad;
            personel.departman = p.departman;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}