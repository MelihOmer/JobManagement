using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface ITodoStatusService :IService<TodoStatus>
    {
        Task<string> GetNameById(int Id);
    }
}
