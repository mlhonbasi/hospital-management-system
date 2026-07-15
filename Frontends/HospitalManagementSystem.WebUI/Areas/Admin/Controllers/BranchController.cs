using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BranchController : Controller
    {
        public IActionResult BranchList()
        {
            return View();
        }
    }
}
