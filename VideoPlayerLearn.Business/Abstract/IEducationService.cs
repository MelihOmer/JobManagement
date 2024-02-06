using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface IEducationService:IService<Education>
    {
        List<Education> EducationListWithInclude();
        Task<int> EducationCreate(Education entity);
        Task<string> EducationImageSave(IFormFile file, int EduId);
        Task<string> EducationVideoSave(IFormFile file, int EduId);
        Task<EducationListDto> GetAllByPagingAsync(int currentPage = 1, int pageSize = 4, bool isAscending = false);
        Task<Education> GetEducationById(int Id);
    }
}
