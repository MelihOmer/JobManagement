using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Dtos;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;

namespace VideoPlayerLearn.Business.Concrete
{
    public class TodoViewsUserService : Service<TodoViewsUser>, ITodoViewsUserService
    {
        private IUow _uow;
        public TodoViewsUserService(IUow uow, IMapper mapper) : base(uow, mapper)
        {
            _uow = uow;
        }
        public List<TodoViewsUserDto> GetViewsUserCountByTodoId(int Id)
        {
            var query = from t in _uow.GetRepository<TodoViewsUser>().GetAllQueryable().Include(x => x.AppUser)
                        where t.TodoId == Id
                        group t by new { t.TodoId, t.AppUserId,t.AppUser.FirstName,t.AppUser.LastName,t.AppUser.ImagePath } into g
                        select new
                        {
                            Todo = g.Key.TodoId,
                            Kullanici = g.Key.AppUserId,
                            FullName = g.Key.FirstName +" "+g.Key.LastName.ToUpper(),
                            ImagePath = g.Key.ImagePath,
                            Sayi = g.Count()
                        };

            List<TodoViewsUserDto> list = new();
            foreach (var item in query)
            {
                list.Add(new()
                {
                    Todo = item.Todo,
                    Kullanici = item.Kullanici,
                    FullName = item.FullName,
                    ImagePath = item.ImagePath,
                    Sayi = item.Sayi,
                });
            }
            return list;
        }
    }
}
