using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Abstract
{
    public interface ITodoCommentService : IService<TodoComment>
    {
        Task<List<TodoComment>> TodoCommentsList(int todoId);
        Task<List<TodoCommentResultDto>> TodoCommentsListWhereTodoId(int todoId);
    }
}
