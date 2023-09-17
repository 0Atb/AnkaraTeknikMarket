using Microsoft.AspNetCore.Mvc;
using TeknikMarket.Business.Abstract;
using TeknikMarket.Model.Entity;
using TeknikMarket.Model.ViewModel.Area.Admin.User;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        IKullaniciBS kullanicibs;

        public UserController(IKullaniciBS kullanicibs)
        {
            this.kullanicibs = kullanicibs;
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


            Kullanici kullanici = kullanicibs.Get(x=>x.Email == model.Email && x.Sifre==model.Sifre && x.Aktif == true);

            if (kullanici != null)
            {
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

    }
}
