using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using Project.WebAPI.Models.AppUsers.RequestModels;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        IAppUserManager _userManager;
        public RegisterController(IAppUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel item)
        {
            AppUser appUser = new()
            {
                UserName = item.UserName,
                Email = item.Email,
                PasswordHash = item.Password
            };

            bool result = await _userManager.CreateUser(appUser);

            if (result)
            {
                return Ok("Kullanıcı Ekleme Başarılı");
            }
            else
            {
                return BadRequest("Kullanıcı Ekleme Kısmında Bir Sorun İle Karşılaşıldı");
            }


        }
    }
}
