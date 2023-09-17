using Microsoft.AspNetCore.Mvc;

namespace TeknikMarket.CoreMVCUI.Areas.Admin.ViewComponents
{
    public class ContentHeaderViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {


            return View();
        }
    }
}
