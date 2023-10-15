using TeknikMarket.Model.Entity;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.Filter
{
    public interface ISessionManager
    {
        public Kullanici AktifKullanici { get; set; }
    }
}
