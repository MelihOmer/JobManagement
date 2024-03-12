using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.Business.Extensions;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Enums;

namespace VideoPlayerLearn.Business.Concrete
{
    public class ClientNotificationServicce : Service<ClientNotification>, IClientNotificationService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly int _loginUserId;
        public ClientNotificationServicce(IUow uow, IMapper mapper, IHttpContextAccessor contextAccessor) : base(uow, mapper)
        {
            _uow = uow;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _loginUserId = _contextAccessor.HttpContext.User.GetLoggedInUserId();
        }
        public async Task<List<ClientNotificationResultDto>> GetNotifyListByTodoIdAsync(ClientNotficationType clientNotficationType,int takeByNotifyCount = 5)
        {
            if((int)clientNotficationType > 0)
            {
                var resultList = _uow.GetRepository<ClientNotification>()
                .GetAllQueryable()
                .Include(x => x.AppUser)
                .Include(y => y.AssignedToUser)
                .OrderByDescending(x => x.Id)
                .AsQueryable();
                
                resultList = clientNotficationType == ClientNotficationType.AssignedToUser
                    ? resultList.Where(x => !x.AssignedToUserSeen & x.AssignedToUserId == _loginUserId).Take(takeByNotifyCount)
                    : resultList.Where(x => !x.AppUserSeen & x.AppUserId == _loginUserId).Take(takeByNotifyCount);

                var mappingResult = _mapper.Map<List<ClientNotificationResultDto>>(resultList);
                return mappingResult;
            }
            return null;
            
        }
        public async Task CustomCreateAsync(ClientNotification clientNotification)
        {
            var loginUserId = _contextAccessor.HttpContext.User.GetLoggedInUserId();
            if (clientNotification.AssignedToUserId == loginUserId)
                clientNotification.AssignedToUserSeen = true;

           if(clientNotification.AppUserId == loginUserId)
                clientNotification.AppUserSeen = true;

                await CreateAsync(clientNotification);

        }

        public async Task NotifyNotSeenForAppUserAsync(int todoId)
        {
            var listAppUserNotSeen = _uow.GetRepository<ClientNotification>()
                .GetAllQueryable(x => x.TodoId == todoId
                & x.AppUserId == _loginUserId
                & x.AppUserSeen == false);
            var list = listAppUserNotSeen.ToList();

            var repo = _uow.GetRepository<ClientNotification>();
            foreach (var item in list)
            {
                
                repo.Update(item.Id);
            }
            // list.ForEach(x => x.AppUserSeen = true);
            //await _uow.GetRepository<ClientNotification>().Update(listAppUserNotSeen.ToList());
        }
        public async Task NotifyNotSeenForAssignedUserAsync(int todoId)
        {
            var listAssignedNotSeen = _uow.GetRepository<ClientNotification>()
                .GetAllQueryable(x => x.TodoId == todoId
                & x.AssignedToUserId == _loginUserId
                & !x.AssignedToUserSeen);
            await listAssignedNotSeen.ForEachAsync(x => x.AssignedToUserSeen = true);
            await _uow.GetRepository<ClientNotification>().Update(listAssignedNotSeen.ToList());
        }


    }
}
