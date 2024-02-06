using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Extensions;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;
using VideoPlayerLearn.Entities.Dtos.TodoDtos;

namespace VideoPlayerLearn.Business.Concrete
{
    public class TodoService : Service<Todo>, ITodoService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IHostingEnvironment _environment;
        private readonly ICustomUserManager _customUserManager;

        public TodoService(IUow uow, IMapper mapper, IHttpContextAccessor httpContext, IHostingEnvironment environment, ICustomUserManager customUserManager) : base(uow, mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _httpContext = httpContext;
            _environment = environment;
            _customUserManager = customUserManager;
        }
        public async Task<int> CreateTodo(TodoCreateDto dto)
        {
            
            dto.AppUserId = _httpContext.HttpContext.User.GetLoggedInUserId();
            var entity = _mapper.Map<Todo>(dto);
            await CreateAsync(entity);
            return entity.Id;
        }
        public IQueryable<Todo> GetTodoListWithInclude(Expression<Func<Todo, bool>> filter = null)
        {
            return filter != null 
                ? _uow.GetRepository<Todo>().GetAllQueryable(filter)
                .Include(x => x.Department)
                .Include(x => x.AppUser)
                .Include(x => x.TodoStatus)
                .Include(x => x.AssignedToUser)
                : _uow.GetRepository<Todo>().GetAllQueryable()
                .Include(x => x.Department)
                .Include(x => x.AppUser)
                .Include(x => x.TodoStatus)
                .Include(x => x.AssignedToUser);

        }

        public async Task<IQueryable<Todo>> TodoListWithDepartmentUserWhereDepartmentAsync(int statusId)
        {
            var user = await _customUserManager.GetUserFindId(_httpContext.HttpContext.User.GetLoggedInUserId());
            return GetTodoListWithInclude(x => x.AssignedToUserId == user.Id & x.DepartmentId == user.DepartmentId & x.TodoStatusId == statusId);


        }
        public IQueryable<Todo> InJobPoolWhereDepartment(int departmentId)
        {
            return GetTodoListWithInclude(x => x.DepartmentId == departmentId);

        } 
        public IQueryable<Todo> TodoListWithDepartmentUserWhereUserId(int userId)
        {
            return GetTodoListWithInclude(x => x.AppUserId == userId);
        }
        public IQueryable<Todo> TodoListWhereStatusId(int statusId)
        {
            return GetTodoListWithInclude(x => x.AppUserId == _httpContext.HttpContext.User.GetLoggedInUserId()&x.TodoStatusId == statusId);
        }
        public async Task AssignTodoAsync(int todoId, int userId)
        {
            var todo = await _uow.GetRepository<Todo>().GetById(todoId);
            todo.AssignedToUserId = userId;
            await _uow.SaveChangeAsync();
        }
        public IQueryable<Todo> TodoDetailsWithDepartmentUserComments(int Id)
        {
            var todo = _uow.GetRepository<Todo>().GetAllQueryable(x => x.Id == Id)
                .Include(x => x.Department)
                .Include(x => x.AppUser)
                .ThenInclude(x => x.Department)
                .Include(x => x.AssignedToUser)
                .Include(x => x.TodoStatus)
                .AsSingleQuery();
            return todo;
        }
        public async Task<Todo> TodoGetById(int Id)
        {
            var todo = await _uow.GetRepository<Todo>().GetById(Id);
            return todo;
        }
        public async Task<string> Update(TodoUpdateDto dto)
        {
            string messages = default;
            var unchangedData = await GetById(dto.Id);
            if (unchangedData == null)
            {
                messages = $"{dto.Id} Nolu Kayıt Bulunamadı.";
            }
            var data = _mapper.Map<Todo>(dto);

            _uow.GetRepository<Todo>().Update(data, unchangedData);
            await _uow.SaveChangeAsync();

            return messages;

        }
        public async Task TodoResolution(TodoResolutionDto dto)
        {
            string messages = "";
            var unchangedData = await GetById(dto.Id);
            if (unchangedData == null)
            {
                messages = $"{dto.Id} Nolu Kayıt Bulunamadı.";
            }


            unchangedData.ResolutionNote = dto.ResolutionNote;
            unchangedData.TodoStatusId = 3;
            unchangedData.FinishedDate = dto.FinishedDate;

            await _uow.SaveChangeAsync();

        }
        public async Task TodoAnalysis(TodoReviewDto dto)
        {
            string messages = "";
            var unchangedData = await GetById(dto.Id);
            if (unchangedData == null)
            {
                messages = $"{dto.Id} Nolu Kayıt Bulunamadı.";
            }


            unchangedData.ReviewNote = dto.ReviewNote;
            unchangedData.TodoStatusId = 2;
            unchangedData.AnalysisStartDate = dto.AnalysisStartDate;

            await _uow.SaveChangeAsync();

        }
        public async Task TodoRejected(TodoRejectedDto dto)
        {
            string messages = "";
            var unchangedData = await GetById(dto.Id);
            if (unchangedData == null)
            {
                messages = $"{dto.Id} Nolu Kayıt Bulunamadı.";
            }
            unchangedData.RejectedDate = dto.RejectedDate;
            unchangedData.RejectedNote=dto.RejectedNote;
            unchangedData.TodoStatusId = dto.TodoStatusId;
            await _uow.SaveChangeAsync();

        }


    }
}
