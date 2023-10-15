using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TeknikMarket.CoreMVCUI.Extensions;
using TeknikMarket.Model.Entity;
using TeknikMarket.Model.Static;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.Filter
{
    public class AktifKullaniciFilter:ActionFilterAttribute,IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //NOT : Burası bu filtrenin uygulandığı action metot çalıştılmadan sonra çalışacak kodların yazlacağı yerdir.

            Kullanici kullanici = context.HttpContext.Session.GetObject<Kullanici>(SessionKeys.AktifKullanici);

            if (kullanici == null)
            {
                context.Result = new RedirectResult("/Admin/User/LogIn2");
            }

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //NOT : Burası bu filtrenin uygulandığı action metot çalıştılmadan önce çalışacak kodların yazlacağı yerdir.
            base.OnActionExecuted(context);
        }
    }
}
