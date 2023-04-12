using Microsoft.AspNetCore.Mvc;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Controllers
{
    public class AccountController : Controller
    {

        private readonly ICustomUserManager _customUserManager;

        public AccountController( ICustomUserManager customUserManager)
        {
            _customUserManager = customUserManager;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            return View(new AppUserLoginDto() {ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _customUserManager.LoginAsync(appUserLoginDto);
                if (loginResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(appUserLoginDto.ReturnUrl))
                    {
                        return Redirect(appUserLoginDto.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Kullanıcı Adı Veya Şifre Hatalıdır");

            }
            return View(appUserLoginDto);

        }




        [HttpGet]
        public IActionResult Register()
        {
            return View(new AppUserCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserCreateDto appUserCreateDto)
        {
            
            if (ModelState.IsValid)
            {
              var result =   await _customUserManager.CreateUserAsync(appUserCreateDto, appUserCreateDto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(appUserCreateDto);
        }
    }
}
