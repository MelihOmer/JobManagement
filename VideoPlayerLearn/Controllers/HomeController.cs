using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Models;

namespace VideoPlayerLearn.Controllers
{
    //[Authorize]
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

            var list = result.Include(x => x.AppUser).Include(x => x.Department);
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}