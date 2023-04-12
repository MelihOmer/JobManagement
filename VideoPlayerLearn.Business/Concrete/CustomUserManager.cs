using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.Concrete
{
    public class CustomUserManager :ICustomUserManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public CustomUserManager(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(AppUserCreateDto model,string password)
        {
            var entity = _mapper.Map<AppUser>(model);

            var identityResult = await _userManager.CreateAsync(entity,password);

            return identityResult;
        }
        public async Task<SignInResult> LoginAsync(AppUserLoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,model.RememberMe,false);
            return result;
        }
        public async Task<AppUser> FindUserWithNameAsync(string userName)
        {
            var user =await _userManager.FindByNameAsync(userName);
            return user;

        }
    }
}
