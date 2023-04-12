using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface ICustomUserManager
    {
        Task<IdentityResult> CreateUserAsync(AppUserCreateDto model, string password);
        Task<SignInResult> LoginAsync(AppUserLoginDto model);
         Task<AppUser> FindUserWithNameAsync(string userName);
    }
}
