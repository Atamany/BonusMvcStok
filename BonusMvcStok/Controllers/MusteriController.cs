using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BonusMvcStok.Models.Entity;

namespace BonusMvcStok.Controllers
{
    public class MusteriController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            var musteriliste = db.TblMusteri.Where(x=>x.durum==true).ToList().ToPagedList(sayfa,10);
            return View(musteriliste);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TblMusteri p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            p1.durum = true;
            db.TblMusteri.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(TblMusteri p)
        {
            var musteribul = db.TblMusteri.Find(p.id);
            musteribul.durum=false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TblMusteri.Find(id);
            return View("MusteriGetir", musteri);
        }
        public ActionResult MusteriGuncelle(TblMusteri p)
        {
            var musteri = db.TblMusteri.Find(p.id);
            musteri.ad = p.ad;
            musteri.soyad = p.soyad;
            musteri.sehir = p.sehir;
            musteri.bakiye = p.bakiye;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}