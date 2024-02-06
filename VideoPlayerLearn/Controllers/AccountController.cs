using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Controllers
{
    public class AccountController : Controller
    {

        private readonly ICustomUserManager _customUserManager;
        private readonly IDepartmentService _departmentService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(ICustomUserManager customUserManager, IDepartmentService departmentService, SignInManager<AppUser> signInManager)
        {
            _customUserManager = customUserManager;
            _departmentService = departmentService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            return View(new AppUserLoginDto() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _customUserManager.LoginAsync(appUserLoginDto);
                var user = await _customUserManager.FindUserWithNameAsync(appUserLoginDto.UserName);
                var departmentName = await _departmentService.GetById(user.DepartmentId);
                if (loginResult.Succeeded)
                {
                    List<Claim> claims = new List<Claim>() {
                        new Claim(
                            "deparmentId", user.DepartmentId.ToString()
                            )
                       ,new Claim(
                           "departmentName",departmentName.Decription)
                       ,new Claim(
                           "userId",user.Id.ToString())
                    };
                    await _customUserManager.RemoveClaimList(appUserLoginDto, claims);
                    await _customUserManager.AddClaimList(appUserLoginDto, claims);


                    if (!string.IsNullOrEmpty(appUserLoginDto.ReturnUrl))
                    {
                        return Redirect(appUserLoginDto.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home", new { user.DepartmentId });
                }
                ModelState.AddModelError("", "Kullanıcı Adı Veya Şifre Hatalıdır");


            }


            return View(appUserLoginDto);

        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }




        [HttpGet]
        public async Task<IActionResult> Register()
        {

            var list = await _departmentService.GetAllAsync();

            ViewBag.DepartmentList = new SelectList(list, "Id", "Decription");
            return View(new AppUserCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserCreateDto appUserCreateDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _customUserManager.CreateUserAsync(appUserCreateDto, appUserCreateDto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
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
