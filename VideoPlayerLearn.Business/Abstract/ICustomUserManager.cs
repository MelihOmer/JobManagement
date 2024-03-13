using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        Task<IList<Claim>> GetClaims(AppUserLoginDto model);
        Task AddClaims(AppUserLoginDto model, Claim claim);
        Task AddClaimList(string userName, List<Claim> claims);
        Task RemoveClaimList(AppUserLoginDto model, List<Claim> claims);
        List<AppUserListDto> UserList();
        Task RoleAssign(AppUserCreateDto userCreateDto);
        Task UpdateUser(AppUserUpdateDto appUser);
        Task ChangePassword(AppUserUpdateDto model);
        Task ImageUpdate(int Id,IFormFile file);
        Task<List<AppUser>> GetAll();
        Task<AppUser> GetUserFindId(int Id);
        IQueryable<AppUser> GetUserWithDepartment();
        Task RefreshClaimAsync(string userName);
        Task<List<AppUser>> GetAllFromTodoUpdate();
        Task<List<AppUser>> GetUsersFromTodoDetailModelWhereDepartmentId(int departmentId);
    }
}
