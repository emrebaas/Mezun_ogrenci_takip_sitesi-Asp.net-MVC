using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;
using ymanasayfa.Models;


namespace ymanasayfa.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        Veritabani db = new Veritabani();

        public ActionResult SonBesYorum()
        {            
            List<Yorum> yorumliste = db.Yorums.OrderByDescending(i => i.yorumid).Take(5).ToList();
            
            return PartialView(yorumliste);
            
        }

        public ActionResult SonBesMesaj()
        {
            List<Mesaj> mesajliste = db.Mesajs.OrderByDescending(i => i.mesaj_id).Take(5).ToList();

            return PartialView(mesajliste);
        }

        public ActionResult SonikiDuyuru()
        {
            List<Duyuru> duyuruliste = db.Duyurus.OrderByDescending(i => i.duyuru_id).Take(2).ToList();

            return PartialView(duyuruliste);
        }
    }
}