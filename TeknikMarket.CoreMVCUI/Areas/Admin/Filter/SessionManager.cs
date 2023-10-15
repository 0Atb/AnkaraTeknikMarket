using TeknikMarket.CoreMVCUI.Extensions;
using TeknikMarket.Model.Entity;
using TeknikMarket.Model.Static;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.Filter
{
    public class SessionManager : ISessionManager
    {
        IHttpContextAccessor httpContextAccessor;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }


        public Kullanici AktifKullanici 
        { 
            get
            {
               return httpContextAccessor.HttpContext.Session.GetObject<Kullanici>(SessionKeys.AktifKullanici);
            }
            set
            {
                httpContextAccessor.HttpContext.Session.SetObject(SessionKeys.AktifKullanici, value);
            } 
        }
    }
}
