using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
