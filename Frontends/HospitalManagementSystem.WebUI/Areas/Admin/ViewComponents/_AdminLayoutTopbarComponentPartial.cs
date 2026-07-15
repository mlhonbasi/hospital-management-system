using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutTopbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
