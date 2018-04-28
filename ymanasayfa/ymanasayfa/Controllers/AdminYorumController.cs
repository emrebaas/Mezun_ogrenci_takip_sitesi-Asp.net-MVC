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
    public class AdminYorumController : Controller
    {
        private Veritabani db = new Veritabani();

        // GET: AdminYorum
        public ActionResult Index()
        {
            var yorums = db.Yorums.Include(y => y.Duyuru).Include(y => y.Kullanıcı);
            return View(yorums.ToList());
        }
        
    }
}
