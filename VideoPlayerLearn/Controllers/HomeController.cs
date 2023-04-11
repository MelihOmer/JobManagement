using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Models;

namespace VideoPlayerLearn.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUow _uow;

        public HomeController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
           var result =  _uow.GetRepository<Todo>().GetAllQueryable();
            var result2 = result.Include(x => x.Department);
            foreach ( var item in result2)
            {
                var dep = item.Department.Decription;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}