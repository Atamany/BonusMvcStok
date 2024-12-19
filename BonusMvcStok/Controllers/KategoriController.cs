using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;

namespace BonusMvcStok.Controllers
{
    public class KategoriController : Controller
    {
        DbMvcStokEntities db = new DbMvcStokEntities();
        public ActionResult Index()
        {
            var kategoriler = db.TblKategori.ToList();
            return View(kategoriler);
        }
    }
}