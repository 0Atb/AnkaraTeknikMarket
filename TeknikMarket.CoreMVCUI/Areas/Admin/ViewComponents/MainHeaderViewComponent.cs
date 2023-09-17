using Microsoft.AspNetCore.Mvc;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.ViewComponents
{
    public class MainHeaderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {


            return View();
        }
    }
}
