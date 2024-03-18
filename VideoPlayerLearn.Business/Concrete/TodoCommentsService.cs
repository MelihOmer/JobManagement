using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.Business.Extensions;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.Concrete
{
    public class TodoCommentsService : Service<TodoComment>, ITodoCommentService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        readonly IHttpContextAccessor _contextAccessor;
        readonly int _loggedInUserId ;
        public TodoCommentsService(IUow uow, IMapper mapper, IHttpContextAccessor contextAccessor) : base(uow, mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _loggedInUserId = _contextAccessor.HttpContext.User.GetLoggedInUserId();
        }
        public async Task<List<TodoComment>> TodoCommentsList(int todoId)
        {
            var list = await _uow.GetRepository<TodoComment>()
                .GetAllQueryable(x => x.TodoId == todoId)
                .Include(x => x.AppUser)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
            return list;
        }
        public async Task<List<TodoCommentResultDto>> TodoCommentsListWhereTodoId(int todoId)
        {
            var list = await _uow.GetRepository<TodoComment>()
                .GetAllQueryable(x => x.TodoId == todoId)
                .Include(x => x.AppUser)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
          var resultList =   _mapper.Map<List<TodoCommentResultDto>>(list);

            return resultList;
        }
        public async Task TodoCommentCreateAsync(TodoCommentCreateDto todoCommentCreateDto)
        {
            var mappingEntity = _mapper.Map<TodoComment>(todoCommentCreateDto);
            mappingEntity.AppUserId = _loggedInUserId;
            await CreateAsync(mappingEntity);
        }
    }
}
