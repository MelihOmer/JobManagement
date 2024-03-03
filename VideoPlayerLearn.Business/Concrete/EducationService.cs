using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Concrete
{
    public class EducationService : Service<Education>, IEducationService
    {
        private readonly IUow _uow;
        private readonly IHostingEnvironment _environment;
        public EducationService(IUow uow, IMapper mapper, IHostingEnvironment environment) : base(uow, mapper)
        {
            _uow = uow;
            _environment = environment;
        }
        public List<Education> EducationListWithInclude()
        {
            return _uow.GetRepository<Education>().GetAllQueryable()
                 .Include(x => x.EducationCategory)
                 .Include(x => x.AppUser)
                 .Include(x => x.Department)
                .ToList();
        }
        public async Task<int> EducationCreate(Education entity)
        {
            await CreateAsync(entity);
            return entity.Id;
        }
        public async Task<string> EducationImageSave(IFormFile file, int EduId)
        {
            string wwwroot = _environment.WebRootPath;
            string extension = Path.GetExtension(file.FileName);
            string fileName = $"{Guid.NewGuid().ToString()}{extension}";
            if (!Directory.Exists(wwwroot + "/EducationFiles/Images"))
            {
                Directory.CreateDirectory(wwwroot + "/EducationFiles/Images");
            }
            string path = $"{wwwroot}/EducationFiles/Images/{fileName}";
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var education = await GetById(EduId);
            education.ImagePath = $"/EducationFiles/Images/{fileName}";
            await _uow.SaveChangeAsync();
            return $"{wwwroot}/EducationFiles/Images/{fileName}";
        }
        public async Task<string> EducationVideoSave(IFormFile file, int EduId)
        {
            string wwwroot = _environment.WebRootPath;
            string extension = Path.GetExtension(file.FileName);
            string fileName = $"{Guid.NewGuid().ToString()}{extension}";
            if (!Directory.Exists(wwwroot + "/EducationFiles/Videos"))
            {
                Directory.CreateDirectory(wwwroot + "/EducationFiles/Videos");
            }
            string path = $"{wwwroot}/EducationFiles/Videos/{fileName}";
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var education = await GetById(EduId);
            education.VideoPath = $"/EducationFiles/Videos/{fileName}";
            await _uow.SaveChangeAsync();
            return $"{wwwroot}/EducationFiles/Videos/{fileName}";
        }
        //
        public async Task<EducationListDto> GetAllByPagingAsync(int currentPage = 1, int pageSize = 8, bool isAscending = false)
        {     
            var EduList = _uow.GetRepository<Education>().GetAllQueryable();
            EduList = EduList
                .Include(x => x.EducationCategory)
                .Include(x => x.AppUser)
                .Include(x => x.Department);


  
              

            var sortedList = isAscending
                ? EduList.OrderBy(x => x.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : EduList.OrderByDescending(x => x.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();


            return new EducationListDto
            {
                Educations = sortedList,
                CurrentPage = currentPage,
                PageSize = pageSize,
                IsAscending = isAscending,
                TotalCount = EduList.ToList().Count
            };
        }
        public async Task<Education> GetEducationById(int Id)
        {
            var data =await _uow.GetRepository<Education>().GetAllQueryable(x => x.Id == Id)
                .Include(x => x.AppUser)
                .Include(x => x.Department)
                .Include(x => x.EducationCategory).FirstOrDefaultAsync();
            return data;
            
        }
    }
}
