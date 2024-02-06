using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace VideoPlayerLearn.Business.Concrete
{
    public class CustomUserManager : ICustomUserManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IHostingEnvironment _environment;
        private readonly IUow _uow;
        private readonly IDepartmentService _departmentService;

        public CustomUserManager(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IHostingEnvironment enviroment, IUow uow, IDepartmentService departmentService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _environment = enviroment;
            _uow = uow;
            _departmentService = departmentService;
        }

        public async Task<IdentityResult> CreateUserAsync(AppUserCreateDto model, string password)
        {
            var entity = _mapper.Map<AppUser>(model);

            var identityResult = await _userManager.CreateAsync(entity, password);
            if (identityResult.Succeeded)
            {
                await RoleAssign(model);
            }


            return identityResult;
        }
        public async Task<SignInResult> LoginAsync(AppUserLoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            return result;
        }
        public async Task<AppUser> FindUserWithNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;

        }
        public async Task<IList<Claim>> GetClaims(AppUserLoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);


            var claims = await _userManager.GetClaimsAsync(user);
            return claims;
        }

        public async Task AddClaims(AppUserLoginDto model, Claim claim)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            await _userManager.AddClaimAsync(user, claim);
        }
        public async Task AddClaimList(string userName, List<Claim> claims)
        {
            var user = await _userManager.FindByNameAsync(userName);
            await _userManager.AddClaimsAsync(user, claims);

        }
        public async Task RemoveClaimList(AppUserLoginDto model, List<Claim> claims)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            await _userManager.RemoveClaimsAsync(user, claims);
        }
        public List<AppUserListDto> UserList()
        {


            var dtosList = _mapper.Map<List<AppUserListDto>>(_userManager.Users.Include(x => x.Department).Where(x => x.Id != 1 & x.Id != 2).ToList());


            return dtosList;
        }
        public async Task RoleAssign(AppUserCreateDto userCreateDto)
        {


            var appUser = await _userManager.FindByNameAsync(userCreateDto.UserName);

            var role = await _roleManager.FindByIdAsync(userCreateDto.RoleId.ToString());

            await _userManager.AddToRoleAsync(appUser, role.Name);
        }
        public async Task UpdateUser(AppUserUpdateDto appUser)
        {
            var unChanged = await _userManager.FindByIdAsync(appUser.Id.ToString());
            unChanged.FirstName = appUser.FirstName;
            unChanged.LastName = appUser.LastName;
            unChanged.PhoneNumber = appUser.PhoneNumber;
            unChanged.Email = appUser.Email;
            unChanged.DepartmentId = appUser.DepartmentId;




            await _userManager.UpdateAsync(unChanged);
        }
        public async Task ChangePassword(AppUserUpdateDto model)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, model.Password);
        }
        private async Task<string> FileSave(IFormFile file)
        {
            if (file.Length > 0)
            {
                string wwwroot = _environment.WebRootPath;
                var extension = Path.GetExtension(file.FileName);
                var fileName = $"{Guid.NewGuid().ToString()}{extension}";
                string path = $"{wwwroot}/ProfileImage/{fileName}";
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return $"/ProfileImage/{fileName}";
            }
            return "Dosya Seçilmedi";

        }
        private void ImageDelete(string path)
        {
            if (!path.Contains("default"))
            {
                File.Delete(path);
            }
            
        }
        public async Task ImageUpdate(int Id, IFormFile file)
        {
            string wwwroot = _environment.WebRootPath;
            var filePath = await FileSave(file);
            var user = await _userManager.FindByIdAsync(Id.ToString());
            var oldPath = user.ImagePath;
            
            user.ImagePath = filePath;
            await _userManager.UpdateAsync(user);
            await _userManager.ReplaceClaimAsync(user, new Claim("ImagePath", oldPath), new Claim("ImagePath", filePath));
            ImageDelete($"{wwwroot}/{oldPath}");

        }
        public async Task<List<AppUser>> GetAll()
        {
            return await _userManager.Users.Where(x=> x.Id != 1 & x.Id != 2).ToListAsync();
        }
        public async Task<AppUser> GetUserFindId(int Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            return user;
        }
        public IQueryable<AppUser> GetUserWithDepartment()
        {
            var result = _userManager.Users
                .Include(x => x.Department);
            return result;
        }
        public async Task RefreshClaimAsync(string userName)
        {
            var user =await _userManager.FindByNameAsync(userName);
            var departmentName = await _departmentService.GetById(user.DepartmentId);
            var oldClaimList = await _userManager.GetClaimsAsync(user);
            await _userManager.RemoveClaimsAsync(user, oldClaimList);
            List<Claim> claims = new List<Claim>() {
                        new Claim(
                            "deparmentId", user.DepartmentId.ToString()
                            )
                       ,new Claim(
                           "departmentName",departmentName.Decription)
                       ,new Claim(
                           "userId",user.Id.ToString())
                       ,new Claim(
                           "ImagePath",user.ImagePath
                           )
                       ,new Claim(
                           "UserFirstLastName",user.FirstName +" "+ user.LastName
                           )
                    };
            await AddClaimList(userName, claims);

        }
        public async Task<List<AppUser>> GetAllFromTodoUpdate()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
