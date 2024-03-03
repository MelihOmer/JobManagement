using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Enums;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface IClientNotificationService : IService<ClientNotification>
    {
        Task<List<ClientNotificationResultDto>> GetNotifyListByTodoIdAsync(ClientNotficationType clientNotficationType);
        Task CustomCreateAsync(ClientNotification clientNotification);
    }
}
