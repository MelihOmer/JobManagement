using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.Concrete
{
    public class TodoCommentsService : Service<TodoComment>, ITodoCommentService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public TodoCommentsService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<List<TodoComment>> TodoCommentsList(int todoId)
        {
            var list = await _uow.GetRepository<TodoComment>()
                .GetAllQueryable(x => x.TodoId == todoId)
                .Include(x => x.AppUser)
                .OrderByDescending(x=> x.Id)
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
            await CreateAsync(mappingEntity);
        }
    }
}
