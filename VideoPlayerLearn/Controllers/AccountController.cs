using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Extensions;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;
using VideoPlayerLearn.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace VideoPlayerLearn.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly ICustomUserManager _customUserManager;
        private readonly IDepartmentService _departmentService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _validatorUserCreate;
        private readonly INotyfService _notyf;
        public AccountController(ICustomUserManager customUserManager, IDepartmentService departmentService, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IHttpContextAccessor httpContextAccessor, IMapper mapper, IHostingEnvironment environment, UserManager<AppUser> userManager, IValidator<AppUserCreateDto> validatorUserCreate, INotyfService notyf)
        {
            _customUserManager = customUserManager;
            _departmentService = departmentService;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _HttpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _environment = environment;
            _userManager = userManager;
            _validatorUserCreate = validatorUserCreate;
            _notyf = notyf;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl)
        {
            return View(new AppUserLoginDto() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _customUserManager.FindUserWithNameAsync(appUserLoginDto.UserName);
                if (user != null)
                {
                    var loginResult = await _customUserManager.LoginAsync(appUserLoginDto);
                    if (loginResult.Succeeded)
                    {
                        await _customUserManager.RefreshClaimAsync(appUserLoginDto.UserName);
                        var roleCheck = await _userManager.GetRolesAsync(user);

                        if (roleCheck.Contains("Standart"))
                        {
                            return RedirectToAction("Index", "Home", new { departmentId = user.DepartmentId, standartUser = true });
                        }
                        if (!string.IsNullOrEmpty(appUserLoginDto.ReturnUrl))
                        {
                            return Redirect(appUserLoginDto.ReturnUrl);
                        }
                        _notyf.Success("Giriş Başarılı.", 3);
                        return RedirectToAction("Index", "Home", new { departmentId = user.DepartmentId, standartUser = false });
                    }
                        _notyf.Error("Kullanıcı Adı Veya Şifre Hatalı");
                    //ModelState.AddModelError("", "Kullanıcı Adı Veya Şifre Hatalı");
                    
                }
                _notyf.Error("Geçerli bir kullanıcı adı ve şifre giriniz.");
                return View(appUserLoginDto);
            }
            //ModelState.AddModelError("", "Kullanıcı Adı Veya Şifre Hatalı");
            _notyf.Error("Geçerli bir kullanıcı adı ve şifre giriniz.");
            return View(appUserLoginDto);

        }
        public async Task<IActionResult> LogOut()
        {
            await _customUserManager.RefreshClaimAsync(_HttpContextAccessor.HttpContext.User.GetLoggedInUserName());
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            AppUserCreateModel model = new AppUserCreateModel()
            {
                AppUserCreateDto = new AppUserCreateDto(),
                DepartmentList = new SelectList(await _departmentService.GetAllAsync(), "Id", "Decription"),
                RoleList = new SelectList(_roleManager.Roles.ToList(), "Id", "Name")
            };


            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Register(AppUserCreateModel model)
        {
            var validateResult = await _validatorUserCreate.ValidateAsync(model.AppUserCreateDto);
            if (validateResult.IsValid)
            {
                var result = await _customUserManager.CreateUserAsync(model.AppUserCreateDto, model.AppUserCreateDto.Password);
                if (result.Succeeded)
                {
                    await _customUserManager.RefreshClaimAsync(model.AppUserCreateDto.UserName);

                    _notyf.Success("Kullanıcı Oluşturma İşlemi Başarılı.");
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    _notyf.Error($"{item.Description}");
                    ModelState.AddModelError("", item.Description);
                }
            }
            model.DepartmentList = new SelectList(await _departmentService.GetAllAsync(), "Id", "Decription");
            model.RoleList = new SelectList(_roleManager.Roles.ToList(), "Id", "Name");
            foreach (var item in validateResult.Errors)
            {
                _notyf.Error($"{item.ErrorMessage}");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult GetUserList()
        {
            var list = _customUserManager.UserList();
            return View(list);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetOtherUserInfo(int Id)
        {
            var mapping = _mapper.Map<AppUserUpdateDto>(await _customUserManager.GetUserFindId(Id));
            AppUserDetailModel model = new AppUserDetailModel()
            {
                AppUserUpdateDto = mapping,
                DepartmentList = new SelectList(await _departmentService.GetAllAsync(), "Id", "Decription")
            };
            return View(model);
        }
        public async Task<IActionResult> GetUserInfo()
        {
            var userId = _HttpContextAccessor.HttpContext.User.GetLoggedInUserId();
            var mapping = _mapper.Map<AppUserUpdateDto>(await _customUserManager.GetUserFindId(userId));
            AppUserDetailModel model = new AppUserDetailModel()
            {
                AppUserUpdateDto = mapping,
                DepartmentList = new SelectList(await _departmentService.GetAllAsync(), "Id", "Decription")
            };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Update(AppUserDetailModel model)
        {

            await _customUserManager.UpdateUser(model.AppUserUpdateDto);
            _notyf.Information($"Profil Güncelleme İşlemi Başarılı.");
            return RedirectToAction("GetOtherUserInfo", "Account", new { Id = model.AppUserUpdateDto.Id });
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(AppUserDetailModel model)
        {
            await _customUserManager.ChangePassword(model.AppUserUpdateDto);
            _notyf.Information($"Şifre Güncelleme İşlemi Başarılı.");
            return RedirectToAction("GetUserInfo", "Account");
        }
        public async Task<IActionResult> ImageUpdate(IFormFile file, int Id)
        {
            if (file.Length > 0 & file != null)
            {
                await _customUserManager.ImageUpdate(Id, file);

            }
            if (Id == _HttpContextAccessor.HttpContext.User.GetLoggedInUserId())
            {
                return RedirectToAction("GetUserInfo", "Account");
            }
            return RedirectToAction("GetOtherUserInfo", "Account", new { Id = Id });
        }
        public async Task<IActionResult> AssigmentRole(int userId)
        {
            var user = await _customUserManager.GetUserWithDepartment().FirstOrDefaultAsync(x => x.Id == userId);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.ToList();

            UserRoleWithRoles model = new UserRoleWithRoles();
            List<RoleAssignListModel> list = new List<RoleAssignListModel>();
            foreach (var role in roles)
            {
                list.Add(new()
                {
                    RoleName = role.Name,
                    RoleId = role.Id,
                    Exist = userRoles.Contains(role.Name)
                });
            }
            model.Roles = list;
            model.UserId = userId;
            model.User = user;


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(UserRoleWithRoles model)
        {
            var user = await _customUserManager.GetUserFindId(model.UserId);
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in model.Roles)
            {
                if (role.Exist)
                {
                    if (!userRoles.Contains(role.RoleName))
                    {
                        await _userManager.AddToRoleAsync(user, role.RoleName);
                    }
                }
                else
                {
                    if (userRoles.Contains(role.RoleName))
                    {
                        await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                    }
                }
            }
            _notyf.Information("Rol Atama İşlemi Başarılı.");
            return RedirectToAction("AssigmentRole", "Account", new { userId = user.Id });
        }


    }
}
