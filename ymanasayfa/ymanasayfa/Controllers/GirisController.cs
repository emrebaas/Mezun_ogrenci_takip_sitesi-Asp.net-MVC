using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ymanasayfa.Models;


namespace ymanasayfa.Controllers
{
    public class GirisController : Controller
    {

        Veritabani db = new Veritabani();


        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(Kullanıcı uye, string kuladi, string sifre)
        {

            if (kuladi.ToString() == "admin" && sifre.ToString() == "emre1234qwer")
            {

                return RedirectToAction("Index", "Admin");


            }


            var giris = db.Kullanıcı.Where(u => u.kadi == kuladi).SingleOrDefault();

            if(giris!=null)
            {

                if (giris.kadi == kuladi && giris.ksifre == sifre)
                {
                    Session["kullaniciadi"] = giris.kadi;
                    Session["kullanicidi"] = giris.id;
                    Session["kullanicifoto"] = giris.resim;
                    Session["kullaniciisim"] = giris.isim;
                    return RedirectToAction("DuyuruListele", "Anasayfa");

                }


           


                else
                {
                    return RedirectToAction("Index", "Giris");
                }
            }

            return RedirectToAction("Index", "Giris");

        }



        public ActionResult Kayit()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Kayit(string adivesoyadi,string kuladi,string sifre, HttpPostedFileBase resim)
        {
            Kullanıcı Kayit = new Kullanıcı();


            //if (ModelState.IsValid)
            //{
            Kayit.isim = adivesoyadi;
            Kayit.kadi = kuladi;
            Kayit.ksifre = sifre;


            //    if (resim != null)
            //    {
            //        WebImage img = new WebImage(resim.InputStream);
            //        FileInfo fotoinfo = new FileInfo(resim.FileName);

            //        string foto = Guid.NewGuid().ToString() + fotoinfo.Extension;

            //        img.Save("~/Content/img/" + foto);
            //        Kayit.resim= foto;



            //    }
            //db.Kullanıcı.Add(Kayit);
            //db.SaveChanges();
            //return RedirectToAction("DuyuruListele", "Anasayfa");
            //}

            //return View();



            //eğer dosya gelmişse işlemleri yap
            if (resim != null)
            {
               
                string DosyaAdi = Guid.NewGuid().ToString().Replace("-", "");
              
                string uzanti = System.IO.Path.GetExtension(Request.Files[0].FileName);
                string TamYolYeri = "~/Content/img/" +DosyaAdi + uzanti;
                //Eklediğimiz Resni Server.MapPath methodu ile Dosya Adıyla birlikte kaydettik.
                Request.Files[0].SaveAs(Server.MapPath(TamYolYeri));
                //Ve veritabanına kayıt için dosya adımızı değişkene aktarıyoruz.
                Kayit.resim = DosyaAdi + uzanti;
            }
            db.Kullanıcı.Add(Kayit);
            db.SaveChanges();

            Session["kayitkulid"] = Kayit.id;
            return RedirectToAction("KayHak", "Giris");
        }


        public ActionResult KayHak()
        {
            return View();

        }


        [HttpPost]
        public ActionResult KayHak(string mail, string tel,int yas, string bulyer, string calyer, string bio,int durum, int giristar)
        {
            Hakkinda Kayit = new Hakkinda();
            var uyeid = Session["kayitkulid"];
            int id = Convert.ToInt32(uyeid);

            Kayit.email = mail;
            Kayit.telefon = tel;
            Kayit.yas = yas;
            Kayit.yer = bulyer;
            Kayit.isyer = calyer;
            Kayit.bio = bio;
            Kayit.mezundurumu_id = durum;
            Kayit.mezungiris_id = giristar;
            Kayit.kullanici_id = id;

            db.Hakkindas.Add(Kayit);
            db.SaveChanges();
            return RedirectToAction("Index", "Giris");
        }
        }
}