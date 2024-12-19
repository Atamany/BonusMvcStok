using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BonusMvcStok.Models.Entity;

namespace BonusMvcStok.Controllers
{
    public class AdminController : Controller
    {

        DbMvcStokEntities Db = new DbMvcStokEntities();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TblAdmin p)
        {
            Db.TblAdmin.Add(p);
            Db.SaveChanges();
            return RedirectToAction("Index");
            
        }

    }
}