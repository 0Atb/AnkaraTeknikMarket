using Core.CrossCuttingConcern.Crypto;
using Core.CrossCuttingConcern.MailOp;
using Microsoft.AspNetCore.Mvc;
using TeknikMarket.Business.Abstract;
using TeknikMarket.CoreMVCUI.Areas.Admin.Filter;
using TeknikMarket.CoreMVCUI.Extensions;
using TeknikMarket.Model.Entity;
using TeknikMarket.Model.Static;
using TeknikMarket.Model.ViewModel.Area.Admin.User;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IKullaniciBS kullanicibs;
        private readonly ISessionManager sessionManager;

        public UserController(IKullaniciBS kullanicibs, ISessionManager sessionManager)
        {
            this.kullanicibs = kullanicibs;
            this.sessionManager = sessionManager;
        }

        public IActionResult LogIn()
        {
            LogInViewModel model = new LogInViewModel();


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(LogInViewModel model)
        {
            if (!ModelState.IsValid) //ModelState.IsValid prop'u,Validasyonlardan verinin geçip geçmediğini bilgisini bize verir. Bu sayede sunucu tarfında gereksiz kod çalıştırmayız.
            {
                ViewBag.Mesaj = "İşlemler Hatalı";
                return View(model);
            }

            Kullanici kullanici = kullanicibs.Get(x=>x.Email == model.Email && x.Sifre==model.Sifre && x.Aktif ==true);
            if (kullanici!=null)
            {
                return RedirectToAction("Index", "Home");

                //return Redirect("/Admin/Home/Index");
            }
            ViewBag.Mesaj = "Giriş Başarısız";

            return View(model);
        }

        public IActionResult LogIn2()
        {
            LogInViewModel model = new LogInViewModel();


            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult LogIn2(LogInViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return Json(new { result = false, Mesaj = "Validasyon Hatasi Oldu." });
            }

            string sifre = CryptoManager.MD5Encrypt(CryptoManager.SHA1Encrypt(model.Sifre));

            Kullanici kullanici = kullanicibs.Get(x=>x.Email == model.Email && x.Sifre== sifre && x.Aktif == true, "KullaniciRols", "KullaniciRols.Rol");

            if (kullanici != null)
            {

                //HttpContext.Session["admin"] = 123233;
                //HttpContext.Session.SetObject("AktifKullanici", kullanici);


                sessionManager.AktifKullanici = kullanici;

                return Json(new { result = true, Mesaj = "Giriş Başarılı" });
            }
            else
            {
                return Json(new { result = false, Mesaj = "Kullanıcı Bulunamadı" });
            }


        }

        public IActionResult ForgotPassword()
        {
            ForgotPasswordViewModel model = new ForgotPasswordViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Mesaj = "işlemler Hatalı";
                return Json(new { result = false, Mesaj = "Validasyon Hatasi Oluştu" });
            }

            Kullanici kullanici = kullanicibs.Get(x => x.Email ==model.Email && x.Adi.ToLower() == model.Adi.ToLower() && x.Soyadi.ToUpper() == model.Soyadi.ToUpper());

            if (kullanici!= null)
            {
                MailManager.Send(kullanici.Email, "Şifre Değiştirme", "Merhaba Sayın : " + kullanici.Adi + " " + kullanici.Soyadi + "</br>Şifrenizi Değiştirmek için Lütfen <a href = '"+Keys.SITEADDRESS + "Admin/User/UpdatePassword?UniqueID="+ kullanici.UniqeuId + "'>Tıklayınız</a>");


                return Json(new { result = true, Mesaj = "Şifre Değiştirme Linki Mail Adresinize Gönderildi.Lütfen Mailinizi Kontrol Ediniz." });
            }
            else
            {
                return Json(new { result = false, Mesaj = "Bilgileriniz Hatalı. Lütfen Yeniden Deneyiniz." });
            }
        }


        public IActionResult UpdatePassword(string UniqueID)
        {
            UpdatePasswordViewModel model = new UpdatePasswordViewModel();
            
            model.UniqueID = UniqueID;

            Kullanici kullanici = kullanicibs.Get(x => x.UniqeuId.ToString() == model.UniqueID);

            if (kullanici== null)
            {
                return RedirectToAction("TehlikeliIslem", "Home");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePassword(UpdatePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Mesaj = "işlemler Hatalı";
                return Json(new { result = false, Mesaj = "Validasyon Hatasi Oluştu" });
            }

            Kullanici kullanici = kullanicibs.Get(x => x.UniqeuId.ToString() == model.UniqueID);
            if (kullanici != null && model.Sifre == model.SifreTekrar)
            {
                kullanici.UniqeuId = Guid.NewGuid();
                kullanici.Sifre = CryptoManager.MD5Encrypt(CryptoManager.SHA1Encrypt(model.Sifre));

                kullanicibs.Update(kullanici);

                return Json(new { result = true ,Mesaj = "Şifreniz Başarıyla Güncellendi. Giriş Yapabilirisiniz." });
            }
            else
            {
                return Json(new { result = true, Mesaj = "Ip Adresiniz Kayıt Ediliyor. Lütfen Yetkisiz İşlem Yapmayınız." });
            }
        }

        public IActionResult LogOut()
        {
            sessionManager.AktifKullanici = null;


            return RedirectToAction("LogIn2", "User");
        }

        public IActionResult NonAuthentication()
        {



            return View();
        }
    }
}
