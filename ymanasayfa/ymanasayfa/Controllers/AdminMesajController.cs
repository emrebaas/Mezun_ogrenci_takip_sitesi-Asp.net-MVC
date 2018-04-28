using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ymanasayfa.Models;

namespace ymanasayfa.Controllers
{
    public class AdminMesajController : Controller
    {
        private Veritabani db = new Veritabani();

        // GET: AdminMesaj
        public ActionResult Index()
        {
            var mesajs = db.Mesajs.Include(m => m.Kullanıcı).Include(m => m.Kullanıcı1);
            return View(mesajs.ToList());
        }
        
       
    }
}
