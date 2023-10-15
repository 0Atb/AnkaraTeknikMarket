using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TeknikMarket.CoreMVCUI.Extensions;
using TeknikMarket.Model.Entity;
using TeknikMarket.Model.Static;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.Filter
{
    public class RolFilter:ActionFilterAttribute
    {
        string[] ctrlRoles;

        public RolFilter(params string[] ctrlRoles)
        {
            this.ctrlRoles = ctrlRoles;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Sessionda Giriş Yapan Kişi
            Kullanici kullanici = context.HttpContext.Session.GetObject<Kullanici>(SessionKeys.AktifKullanici);

            //Giriş yapan Kişinin Rollerini Getir.

            string[] Rols = new string[kullanici.KullaniciRols.Count]; //AKtif Kullanıcının Etkin Rolü

            for (int i = 0; i < kullanici.KullaniciRols.Count; i++)
            {
                Rols[i] = kullanici.KullaniciRols.ToList()[i].Rol.RolAdi;
            }

            bool YetkisiVarMi = false;

            foreach (string item in Rols)  //Aktif Kaullanıcının etkin Rolleri
            {
                foreach (string r in ctrlRoles) //Controllerden gelen izin verilen roller 
                {
                    if (item==r)   //Aktif Kullanıcının rollerinde controlerdan izin verilen rollerde var mı. 
                    {
                        YetkisiVarMi = true;
                    }
                    break;
                }
            }

            if (!YetkisiVarMi)
            {
                context.Result = new RedirectResult("/Admin/User/NonAuthentication");
            }



            base.OnActionExecuting(context);
        }


    }
}
