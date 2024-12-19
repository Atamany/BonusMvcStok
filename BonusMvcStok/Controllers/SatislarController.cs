using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;

namespace BonusMvcStok.Controllers
{
    public class SatislarController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var satislar = db.TblSatislar.ToList();
            return View(satislar);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urun = db.TblUrunler
        .Where(x => x.durum == true)
        .Select(x => new SelectListItem
        {
            Text = x.marka + " " + x.ad,
            Value = x.id.ToString()
        }).ToList();
            ViewBag.urun = urun;

            List<SelectListItem> personel = db.TblPersonel
        .Where(x => x.durum == true)
        .Select(x => new SelectListItem
        {
            Text = x.id + " - " + x.ad + " " + x.soyad,
            Value = x.id.ToString()
        }).ToList();
            ViewBag.personel = personel;

            List<SelectListItem> musteri = db.TblMusteri
        .Where(x => x.durum == true)
        .Select(x => new SelectListItem
        {
            Text = x.id + " - " + x.ad + " " + x.soyad,
            Value = x.id.ToString()
        }).ToList();
    ViewBag.musteri = musteri;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TblSatislar s)
        {
            s.durum = true;
            var urn = db.TblUrunler.Where(x => x.id == s.urun).FirstOrDefault();
            s.urun = urn.id;
            var prsnl = db.TblPersonel.Where(y => y.id == s.personel).FirstOrDefault();
            s.personel = prsnl.id;
            var mus = db.TblMusteri.Where(z => z.id == s.musteri).FirstOrDefault();
            s.musteri = mus.id;
            s.fiyat = urn.satisfiyat;
            s.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblSatislar.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisSil(TblSatislar p)
        {
            var satis = db.TblSatislar.Find(p.id);
            satis.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            var sts = db.TblSatislar.Find(id);

            List<SelectListItem> urun = (from x in db.TblUrunler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.marka + " " + x.ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.urun = urun;

            List<SelectListItem> personel = (from x in db.TblPersonel.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.id + " - " + x.ad + " " + x.soyad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.personel = personel;

            List<SelectListItem> musteri = (from x in db.TblMusteri.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.id + " - " + x.ad + " " + x.soyad,
                                                 Value = x.id.ToString()
                                             }).ToList();
            ViewBag.musteri = musteri;

            return View("SatisGetir",sts);
        }
        public ActionResult SatisGuncelle(TblSatislar k)
        {
            var satis = db.TblSatislar.Find(k.id);
            var urn = db.TblUrunler.Where(x => x.id == k.TblUrunler.id).FirstOrDefault();
            satis.urun = urn.id;
            var prsnl = db.TblPersonel.Where(y => y.id == k.TblPersonel.id).FirstOrDefault();
            satis.personel = prsnl.id;
            var mus = db.TblMusteri.Where(z => z.id == k.TblMusteri.id).FirstOrDefault();
            satis.musteri = mus.id;
            satis.fiyat = k.fiyat;
            satis.tarih = k.tarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}