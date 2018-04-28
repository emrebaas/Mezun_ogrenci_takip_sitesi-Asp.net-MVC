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
    public class AnasayfaController : Controller
    {
        Veritabani db = new Veritabani();

        public bool True { get; private set; }

        public ActionResult Index()
        {
            
            return View();
        }
       

        public ActionResult DuyuruListele()
        {
            var duyuru = db.Duyurus.OrderByDescending(d =>d.duyuru_id ).ToList();
            return View(duyuru);
        }
        

        public ActionResult DuyuruDetay(int id)
        {
            
          var duyuru = db.Duyurus.Where(i => i.duyuru_id == id).SingleOrDefault();

            if (duyuru == null)
            {
                return HttpNotFound();
            }

            Session["duyuruid"] = duyuru.duyuru_id;
            //Session["duyurusahipid"] = duyuru.duyuru_kullanici_id;

            return View(duyuru);
        }

        [HttpPost]
        public ActionResult DuyuruDetay(string yorum,int id)
        {
            var uyeid = Session["kullanicidi"];

            Yorum yeniyorum = new Yorum();
            yeniyorum.yorum_duyuru_id = id;
            
            yeniyorum.yorum_kullanici_id = Convert.ToInt32(uyeid);
            yeniyorum.yorum_aciklama = yorum;

            db.Yorums.Add(yeniyorum);

            db.SaveChanges();

            return RedirectToAction("DuyuruDetay", "Anasayfa");
        }


        public ActionResult Profil(int id)
        {

            var hakkinda = db.Hakkindas.Where(i => i.kullanici_id == id).SingleOrDefault();
           
            if (hakkinda == null)
            {
                return View();
               
            }
            else
            {
            Session["girilenprofilid"] = hakkinda.kullanici_id;
            Session["hakkindaid"] = hakkinda.hakkinda_id;
            Session["hakkindatel"] = hakkinda.telefon;
            Session["hakkindayas"] = hakkinda.yas;
            Session["hakkindayer"] = hakkinda.yer;
            Session["hakkindabiol"] = hakkinda.bio;
            Session["hakkindaemail"] = hakkinda.email;
            Session["hakkindagiristarih"] = hakkinda.GirisTarih.mezuntarih;
            Session["hakkindaisyer"] = hakkinda.isyer;
            Session["hakkindamezundurum"] = hakkinda.mezundurum.durum;
            }
            


            // return View(hakkinda);
            return View(hakkinda);
        }


        public ActionResult pageorn(int id)
        {
            //int ddd = Convert.ToInt32(Session["id"]);
            
            var duyuru = db.Duyurus.OrderByDescending(d => d.duyuru_id).Where(d => d.duyuru_kullanici_id == id).ToList();


            return PartialView(duyuru);
        }


        public ActionResult gelenmesaj(int id)
        {
            

            var gelenmesaj = db.Mesajs.OrderByDescending(d => d.mesaj_id).Where(d => d.mesaj_alan_id == id).ToList();


            return PartialView(gelenmesaj);
        }


        public ActionResult gidenmesaj(int id)
        {
           

            var gidenmesaj = db.Mesajs.OrderByDescending(d => d.mesaj_id).Where(d => d.mesaj_gönderen_id == id).ToList();


            return PartialView(gidenmesaj);
        }


        public ActionResult Mesaj()
        {


            return View();
        }

        [HttpPost]
        public ActionResult Mesaj(string mesajicerik)
        {

            var kulid = Session["kullanicidi"];
            var girkulid = Session["girilenprofilid"];
            int id = Convert.ToInt32(kulid);
            int girid = Convert.ToInt32(girkulid);
            
            Mesaj mesajkaydet = new Mesaj();
            mesajkaydet.mesaj_alan_id = girid;
            mesajkaydet.mesaj_gönderen_id = id;
            mesajkaydet.mesaj_icerik = mesajicerik;

            db.Mesajs.Add(mesajkaydet);
            db.SaveChanges();


            return View();
        }

    
        public ActionResult AyarlarKul(int? id)
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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AyarlarKul(int id, Kullanıcı kullanıcı,HttpPostedFileBase resim)
        {


            try
            {
                var kisi = db.Kullanıcı.Where(v => v.id == id).SingleOrDefault();

                if (resim != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(kisi.resim)))
                    {
                        System.IO.File.Delete(Server.MapPath(kisi.resim));
                    }

                    string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");

                    string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                    string TamYolYeri = "~/Content/img/" + DosyaAdi + uzanti;
                    //Eklediğimiz Resni Server.MapPath methodu ile Dosya Adıyla birlikte kaydettik.
                    Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
                    //Ve veritabanına kayıt için dosya adımızı değişkene aktarıyoruz.
                    

                    kisi.isim = kullanıcı.isim;
                    kisi.kadi = kullanıcı.kadi;
                    kisi.ksifre = kullanıcı.ksifre;
                    kisi.resim = DosyaAdi + uzanti;


                    db.SaveChanges();


                }


                return RedirectToAction("Profil", "Anasayfa", new With { id = id });

            }
            catch
            {
                return View();
            }





            
            
        }


        public ActionResult AyarlarHak(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hakkinda hakkinda = db.Hakkindas.Find(id);
            if (hakkinda == null)
            {
                return HttpNotFound();
            }
            ViewBag.mezungiris_id = new SelectList(db.GirisTarihs, "idmezuntarih", "idmezuntarih", hakkinda.mezungiris_id);
            ViewBag.kullanici_id = new SelectList(db.Kullanıcı, "id", "kadi", hakkinda.kullanici_id);
            ViewBag.mezundurumu_id = new SelectList(db.mezundurums, "id", "durum", hakkinda.mezundurumu_id);
            return View(hakkinda);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AyarlarHak(int id ,Hakkinda hakkinda)
        {
            var kisi = db.Hakkindas.Where(v => v.hakkinda_id == id).SingleOrDefault();

            if (ModelState.IsValid)
            {
                kisi.GirisTarih = hakkinda.GirisTarih;
                kisi.bio = hakkinda.bio;
                kisi.email = hakkinda.email;
                kisi.isyer = hakkinda.isyer;
                kisi.yas = hakkinda.yas;
                kisi.telefon = hakkinda.telefon;
                kisi.mezundurum = hakkinda.mezundurum;
                kisi.kullanici_id = id;
                
                db.SaveChanges();





                var uyeid = Session["kullanicidi"];
                               
                return RedirectToAction("Profil", "Anasayfa", new With { id=id });
            }
            
            return View(hakkinda);
        }



        public ActionResult DuyuruEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult DuyuruEkle(string yazi, HttpPostedFileBase resim)
        {
            Duyuru Kayit = new Duyuru();
            var uyeid = Session["kullanicidi"];
            int id = Convert.ToInt32(uyeid);

            Kayit.duyuruisim = yazi;
            Kayit.duyuru_kullanici_id = id;
           
      
            if (resim != null)
            {
                string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");

                string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                string TamYolYeri = "~/Content/img/duyuru/" + DosyaAdi + uzanti;
                //Eklediğimiz Resni Server.MapPath methodu ile Dosya Adıyla birlikte kaydettik.
                Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
                //Ve veritabanına kayıt için dosya adımızı değişkene aktarıyoruz.
                Kayit.duyururesim  = DosyaAdi + uzanti;
            }
            db.Duyurus.Add(Kayit);
            db.SaveChanges();

         
            return RedirectToAction("DuyuruListele", "Anasayfa");
        }



        public ActionResult Arama(string aranan=null)
        {
            var ara = db.Kullanıcı.Where(m => m.isim.Contains(aranan)).ToList();
            return View(ara.OrderByDescending(m=>m.isim));
        }


        public ActionResult Yorumsil(int id)
        {
            int kulid = Convert.ToInt32(Session["id"]);
            var yorum = db.Yorums.Where(i => i.yorumid == id).SingleOrDefault();
            var duyuru = db.Duyurus.Where(i => i.duyuru_id == yorum.yorum_duyuru_id).SingleOrDefault();

            if(yorum.yorum_kullanici_id== kulid)
            {
                db.Yorums.Remove(yorum);
                db.SaveChanges();

                return RedirectToAction("DuyuruDetay", "Anasayfa", new With { id = duyuru.duyuru_id });
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}