using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;

namespace BonusMvcStok.Controllers
{
    public class UrunController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var urunler = db.TblUrunler.Where(x=>x.durum==true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List <SelectListItem> ktg =(from x in db.TblKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop = ktg;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TblUrunler p)
        {
            p.durum = true;
            var ktgr = db.TblKategori.Where(x => x.id == p.TblKategori.id).FirstOrDefault();
            p.TblKategori = ktgr;
            db.TblUrunler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(TblUrunler p)
        {
            var urunbul =db.TblUrunler.Find(p.id);
            urunbul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.TblUrunler.Find(id);
            List<SelectListItem> ktg = (from x in db.TblKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.urunKategori = ktg;
            return View("UrunGetir", urun);
        }
        public ActionResult UrunGuncelle(TblUrunler k)
        {
            var urun = db.TblUrunler.Find(k.id);
            urun.ad = k.ad;
            urun.marka = k.marka;
            urun.stok = k.stok;
            urun.alisfiyat = k.alisfiyat;
            urun.satisfiyat = k.satisfiyat;
            var ktgr = db.TblKategori.Where(x => x.id == k.TblKategori.id).FirstOrDefault();
            urun.kategori = ktgr.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}