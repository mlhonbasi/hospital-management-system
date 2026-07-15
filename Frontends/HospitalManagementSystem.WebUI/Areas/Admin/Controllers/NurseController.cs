using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NurseController : Controller
    {
        public IActionResult NurseList()
        {
            return View();
        }
    }
}
