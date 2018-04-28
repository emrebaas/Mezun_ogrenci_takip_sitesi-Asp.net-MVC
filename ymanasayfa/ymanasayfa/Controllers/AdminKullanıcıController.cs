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
    public class AdminKullanıcıController : Controller
    {
        private Veritabani db = new Veritabani();

        // GET: AdminKullanıcı
        public ActionResult Index()
        {
            return View(db.Kullanıcı.ToList());
        }
        


        // GET: AdminKullanıcı/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcı kullanıcı = db.Kullanıcı.Find(id);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı);
        }

        // POST: AdminKullanıcı/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanıcı kullanıcı = db.Kullanıcı.Find(id);
            db.Kullanıcı.Remove(kullanıcı);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
