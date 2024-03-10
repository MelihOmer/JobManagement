using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.Business.Extensions;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Concrete
{
    public class StatusMessageService : Service<StatusMessage>, IStatusMessageService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private int _userId;

        public StatusMessageService(IUow uow, IMapper mapper, IHttpContextAccessor contextAccessor) : base(uow, mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _userId = _contextAccessor.HttpContext.User.GetLoggedInUserId();
        }

        public async Task<List<StatusMessageResultDto>> GetStatusMessageAsync()
        {

            var query = _uow.GetRepository<StatusMessage>().GetAllQueryable()
                 .Include(x => x.StatusUser)
                 .Where(x => x.CreatedDate > DateTime.Now.AddDays(-1))
                 .OrderByDescending(x => x.Id)
                 .Take(24);
            var list = await query.ToListAsync();
            var resultList = _mapper.Map<List<StatusMessageResultDto>>(list);
            return resultList;


        }
        public async Task<StatusMessageResultDto> CreateStatusMessage(string statusText)
        {
            StatusMessage entity = new()
            {
                StatusUserId = _userId,
                StatusContent = statusText
            };
            await CreateAsync(entity);
            var returnData = await GetAllQueryable()
                .Where(x => x.Id == entity.Id)
                .Include(x => x.StatusUser)
                .SingleOrDefaultAsync();
            var returnDataMapping = _mapper.Map<StatusMessageResultDto>(returnData);
            return returnDataMapping;

        }

    }
}
