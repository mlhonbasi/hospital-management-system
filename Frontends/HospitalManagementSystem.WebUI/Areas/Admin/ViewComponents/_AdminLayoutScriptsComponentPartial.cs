using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
