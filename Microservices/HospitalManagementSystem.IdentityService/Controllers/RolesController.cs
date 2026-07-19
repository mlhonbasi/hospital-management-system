using HospitalManagementSystem.IdentityService.Dtos;
using HospitalManagementSystem.IdentityService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleService roleService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto dto)
        {
            var result = await roleService.CreateRoleAsync(dto);

            if (!result)
                return BadRequest("Role zaten mevcut veya bir hata oluştu");

            return Ok("Rol başarıyla oluşturuldu.");  
        }
    }
}
