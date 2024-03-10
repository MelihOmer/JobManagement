using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface IStatusMessageService : IService<StatusMessage>
    {
        Task<List<StatusMessageResultDto>> GetStatusMessageAsync();
        Task<StatusMessageResultDto> CreateStatusMessage(string statusText);
    }
}
