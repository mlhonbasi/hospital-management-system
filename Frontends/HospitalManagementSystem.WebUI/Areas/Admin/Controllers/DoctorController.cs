using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        public IActionResult DoctorList()
        {
            return View();
        }
    }
}
