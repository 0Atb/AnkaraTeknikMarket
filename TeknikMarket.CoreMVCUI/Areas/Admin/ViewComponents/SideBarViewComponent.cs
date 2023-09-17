using Microsoft.AspNetCore.Mvc;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.ViewComponents
{
    public class SideBarViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {


            return View();
        }
    }
}
