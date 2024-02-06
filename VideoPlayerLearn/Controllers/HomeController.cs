﻿using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using VideoPlayerLearn.Business.Abstract;
using VideoPlayerLearn.Business.Extensions;
using VideoPlayerLearn.DataAccess.UnitOfWork;
using VideoPlayerLearn.Entities;
using VideoPlayerLearn.Entities.Dtos;
using VideoPlayerLearn.Entities.Dtos.TodoDtos;
using VideoPlayerLearn.Entities.Dtos.TodoFileDtos;
using VideoPlayerLearn.Models;

namespace VideoPlayerLearn.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {



        private readonly IValidator<TodoCreateDto> _validatorTodoCreate; 
        private readonly IValidator<TodoUpdateDto> _validatorTodoUpdate; 
        private readonly IUow _uow;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IDepartmentService _departmentService;
        private readonly ITodoStatusService _todoStatusService;
        private readonly IMapper _mapper;
        private readonly ITodoService _todoService;
        private readonly ICustomUserManager _customUserManager;
        private readonly ITodoCommentService _todoCommentService;
        private readonly ITodoFileService _todoFileService;
        private readonly ITodoViewsUserService _todoViewsUserService;
        private readonly INotyfService _notyf;



        public HomeController(IUow uow, IHttpContextAccessor httpContext, IDepartmentService departmentService, ITodoStatusService todoStatusService, IMapper mapper, ITodoService todoService, ICustomUserManager customUserManager, ITodoCommentService todoCommentService, ITodoFileService todoFileService, IValidator<TodoCreateDto> validator, IValidator<TodoUpdateDto> validatorTodoUpdate, ITodoViewsUserService todoViewsUserService, INotyfService notyf)
        {
            _uow = uow;
            _httpContext = httpContext;
            _departmentService = departmentService;
            _todoStatusService = todoStatusService;
            _mapper = mapper;
            _todoService = todoService;
            _customUserManager = customUserManager;
            _todoCommentService = todoCommentService;
            _todoFileService = todoFileService;
            _validatorTodoCreate = validator;
            _validatorTodoUpdate = validatorTodoUpdate;
            _todoViewsUserService = todoViewsUserService;
            _notyf = notyf;
        }


        public async Task<IActionResult> MyCreationsJobs()
        {
            var user = await _customUserManager.FindUserWithNameAsync(_httpContext.HttpContext.User.GetLoggedInUserName());
            var resultList = _todoService.TodoListWithDepartmentUserWhereUserId(user.Id);
            return View(resultList);
        }
        public async Task<IActionResult> Index(int departmentId,bool standartUser)
        {    
            if (User.IsInRole("Standart"))
            {
                var standartResultList = _todoService.TodoListWithDepartmentUserWhereUserId(_httpContext.HttpContext.User.GetLoggedInUserId()).Where(x => x.TodoStatusId == 1 || x.TodoStatusId == 2);

                return View(standartResultList);
            }

            var user = await _customUserManager.FindUserWithNameAsync(_httpContext.HttpContext.User.GetLoggedInUserName());
            if (departmentId == 0)
                departmentId = user.DepartmentId;


            var resultList = _todoService.GetTodoListWithInclude(x => x.DepartmentId == departmentId & ( x.TodoStatusId == 1 || x.TodoStatusId == 2) & x.AssignedToUserId == user.Id);
            return View(resultList);
        }
        public async Task<IActionResult> WorkListFilter(int Id)
        {
            //login olmuş kullanıcının oluşturdugu bildirimler listesi şart todostatus
            var resulList =  _todoService.TodoListWhereStatusId(Id).ToList();
            return View(resulList);
        }

        public async Task<IActionResult> FilterList(int Id)
        {
            ViewBag.Status = await _todoStatusService.GetNameById(Id);
            var resulList =await _todoService.TodoListWithDepartmentUserWhereDepartmentAsync(Id);
            return View(resulList);
        }
        [Authorize(Roles = "Admin,Teknik")]
        public async Task<IActionResult> InPoolJobs()
        {
            var user = await _customUserManager.FindUserWithNameAsync(_httpContext.HttpContext.User.GetLoggedInUserName());
            var resultList = _todoService.InJobPoolWhereDepartment(user.DepartmentId).Where(x => x.AssignedToUserId == 2).Where(x => x.TodoStatusId == 1 || x.TodoStatusId == 2);
            return View(resultList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var entity = new TodoCreateDto();
            entity.CreatedDate = DateTime.Parse(DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
            var model = new TodoCreateModel();
            model.TodoCreateDto = entity;
            model.DepartmentList = new SelectList( _departmentService.DepartmentList(), "Id", "Decription");
            model.StatusList = new SelectList(await _todoStatusService.GetAllAsync(), "Id", "Description");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TodoCreateModel model)
        {
            ValidationResult val = await _validatorTodoCreate.ValidateAsync(model.TodoCreateDto);
            if (val.IsValid)
            {
                var user = await _customUserManager.GetUserFindId(_httpContext.HttpContext.User.GetLoggedInUserId());
                var todoId = await _todoService.CreateTodo(model.TodoCreateDto);
                TodoComment comment = new TodoComment()
                {
                    AppUserId = 2,
                    Definition = $"{user.FirstName} {user.LastName} Bildirimi Oluşturdu.",
                    TodoId = todoId,
                    CreatedDate = DateTime.Now,
                };
                await _todoCommentService.CreateAsync(comment);
                if (model.TodoCreateDto.File != null)
                {
                    var mappingFile = new TodoFileCreateDto()
                    {
                        TodoId = todoId
                    };
                    await _todoFileService.CreateTodoFile(mappingFile, model.TodoCreateDto.File);
                    TodoComment commentFile = new TodoComment()
                    {
                        AppUserId = 2,
                        Definition = $"{user.FirstName} {user.LastName} Bildirime Dosya Ekledi <strong class='text-success'>{model.TodoCreateDto.File.FileName}</strong>",
                        TodoId = todoId,
                        CreatedDate = DateTime.Now,
                    };
                    await _todoCommentService.CreateAsync(commentFile);
                }
                _notyf.Success("Bildirim Oluşturuldu.",3);
                return RedirectToAction("Index", "Home");
               
            }
            model.DepartmentList = new SelectList(_departmentService.DepartmentList(), "Id", "Decription");
            model.StatusList = new SelectList(await _todoStatusService.GetAllAsync(), "Id", "Description");

            foreach (var error in val.Errors)
            {
                _notyf.Error(error.ErrorMessage, 3);
            }
            
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var entity = await _todoService.GetById(Id);
            var mappingEntity = _mapper.Map<TodoUpdateDto>(entity);
            var model = new TodoUpdateModel()
            {
                TodoUpdateDto = mappingEntity,
                DepartmentList = new SelectList(_departmentService.DepartmentList(),"Id","Decription"),
                StatusList = new SelectList(await _todoStatusService.GetAllAsync(),"Id","Description"),
                UserList= new SelectList(await _customUserManager.GetAllFromTodoUpdate(),"Id","UserName")
                
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(TodoUpdateModel model)
        {
            var user = await _customUserManager.GetUserFindId(_httpContext.HttpContext.User.GetLoggedInUserId());
            var validate = await _validatorTodoUpdate.ValidateAsync(model.TodoUpdateDto);
            if (validate.IsValid)
            {
                await _todoService.Update(model.TodoUpdateDto);
                TodoComment comment = new TodoComment()
                {
                    AppUserId = 2,
                    CreatedDate = DateTime.Now,
                    TodoId = model.TodoUpdateDto.Id,
                    Definition = $"{user.FirstName} {user.LastName} Bildirimi Güncelledi."
                };
                await _todoCommentService.CreateAsync(comment);
                string message = $"({model.TodoUpdateDto.Id}) Nolu Bildirim Güncellendi.";
                _notyf.Success(message, 3);
                return RedirectToAction("Index", "Home");
            }
            foreach (var item in validate.Errors)
            {
                _notyf.Error($"{item.ErrorMessage}");
            }
            model.DepartmentList = new SelectList(_departmentService.DepartmentList(), "Id", "Decription");
            model.StatusList = new SelectList(await _todoStatusService.GetAllAsync(), "Id", "Description");
            model.UserList = new SelectList(await _customUserManager.GetAll(), "Id", "UserName");
            return View(model);

        }
        [Authorize(Roles ="Admin,Teknik")]
        public async Task<IActionResult> ResolutionTodo(TodoDetailsWithTodoCommentsModel model)
        {
            var user = await _customUserManager.GetUserFindId(_httpContext.HttpContext.User.GetLoggedInUserId());
            if (ModelState.IsValid)
            {  
                await _todoService.TodoResolution(model.ResolutionDto);
                var comment = new TodoComment()
                {
                    TodoId = model.ResolutionDto.Id,
                    AppUserId = 2,
                    CreatedDate = DateTime.Now,
                    Definition = $"{user.FirstName} {user.LastName} Bildirimi <strong>Çözümledi</strong>."
                };
                await _todoCommentService.CreateAsync(comment);
            }
            _notyf.Information($"({model.ResolutionDto.Id}) Nolu Bildirim Çözümlendi.");
            return RedirectToAction("TodoDetails", "Home", new { id = model.ResolutionDto.Id });
        }
        [Authorize(Roles = "Admin,Teknik")]
        public async Task<IActionResult> AnalysisTodo(TodoDetailsWithTodoCommentsModel model)
        {
            var user = await _customUserManager.GetUserFindId(_httpContext.HttpContext.User.GetLoggedInUserId());
            if (ModelState.IsValid)
            {
                await _todoService.TodoAnalysis(model.ReviewDto);
                var comment = new TodoComment()
                {
                    TodoId = model.ReviewDto.Id,
                    AppUserId = 2,
                    CreatedDate = DateTime.Now,
                    Definition = $"{user.FirstName} {user.LastName} Bildirimde <strong>Analiz-İnceleme</strong> Başlattı."
                };
                await _todoCommentService.CreateAsync(comment);
            }
            _notyf.Information($"({model.ReviewDto.Id}) Nolu Bildirim Analize Alındı.");
            return RedirectToAction("TodoDetails", "Home", new { id = model.ReviewDto.Id });
        }
        [Authorize(Roles = "Admin,Teknik")]
        public async Task<IActionResult> AssignToMe(int todoId)
        {
            var user = await _customUserManager.GetUserFindId(_httpContext.HttpContext.User.GetLoggedInUserId());
            await _todoService.AssignTodoAsync(todoId, _httpContext.HttpContext.User.GetLoggedInUserId());
            var comment = new TodoComment()
            {
                TodoId = todoId,
                AppUserId = 2,
                CreatedDate = DateTime.Now,
                Definition = $"{user.FirstName} {user.LastName} Bildirimi <strong>{user.FirstName} {user.LastName}</strong> Kullanıcısına Atadı."
            };
            await _todoCommentService.CreateAsync(comment);
            _notyf.Information($"({todoId}) Nolu Bildirim {user.FirstName} {user.LastName} Kullanıcısına Atandı.");
            return RedirectToAction("InPoolJobs", "Home");
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Teknik")]
        public async Task<IActionResult> AssignTodo(TodoDetailsWithTodoCommentsModel model)
        {
            var oldUser = await _customUserManager.GetUserFindId(_httpContext.HttpContext.User.GetLoggedInUserId());
            var newUser = await _customUserManager.GetUserFindId(model.TodoAssignDto.NewUserId);
            await _todoService.AssignTodoAsync(model.TodoAssignDto.TodoId, model.TodoAssignDto.NewUserId);
            var comment = new TodoComment()
            {
                TodoId=model.TodoAssignDto.TodoId,
                AppUserId = 2,
                CreatedDate = DateTime.Now,
                Definition = $"<strong class='text-warning'>{oldUser.FirstName} {oldUser.LastName}</strong> Bildirimi <strong class='text-success'>{newUser.FirstName} {newUser.LastName}</strong>" +
                $" Adlı Kullanıcıya Atadı <br> <strong>Atama Notu :</strong> {model.TodoAssignDto.AssignNote}"
            };
            await _todoCommentService.CreateAsync(comment);
            _notyf.Information($"({model.TodoAssignDto.TodoId}) Nolu Bildirim {newUser.FirstName} {newUser.LastName} Kullanıcısına Atandı.");
            return RedirectToAction("TodoDetails", "Home", new { Id = model.TodoAssignDto.TodoId });
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Teknik")]
        public async Task<IActionResult> RejectedTodo(TodoDetailsWithTodoCommentsModel model)
        {
            var user = await _customUserManager.GetUserFindId(_httpContext.HttpContext.User.GetLoggedInUserId());
            await _todoService.TodoRejected(model.TodoRejectedDto);
            var comment = new TodoComment()
            {
                TodoId = model.TodoRejectedDto.Id,
                AppUserId = 2,
                CreatedDate = DateTime.Now,
                Definition = $"<strong>{user.FirstName} {user.LastName}</strong> Bildirimin Takip Sürecini <strong class='text-danger'>Durdurdu-Reddetti</strong>."
            };
            await _todoCommentService.CreateAsync(comment);
            _notyf.Information($"({model.TodoRejectedDto.Id}) Nolu Bildirim Çözümü Durduruldu.");
            return RedirectToAction("TodoDetails", "Home", new { Id = model.TodoRejectedDto.Id });
        }
        public async Task<IActionResult> TodoDetails(int Id)
        {
            var todo = _todoService.TodoDetailsWithDepartmentUserComments(Id).SingleOrDefault();
            if (todo ==null)
            {
                return RedirectToAction("NotFound", "Status");
            }
            
            var commentList = await _todoCommentService.TodoCommentsList(Id);
            var fileList = _todoFileService.GetAllQueryable().Where(x => x.TodoId == Id);
            var resolutionDto = new TodoResolutionDto()
            {
                Id = Id,
                TodoStatusId = 3
            };
            var reviewDto = new TodoReviewDto()
            {
                Id = Id,
                TodoStatusId = 2
            };
            var userList = await _customUserManager.GetAll();
            var list = userList.Where(x => x.DepartmentId == todo.DepartmentId);
            var todoAssignDto = new TodoAssignDto()
            {
                OldUserId = todo.AssignedToUserId,
                TodoId = todo.Id

            };
            var todoRejectedDto = new TodoRejectedDto()
            {
                Id = todo.Id,
            };
            await _todoViewsUserService.CreateAsync(new()
            {
                AppUserId = _httpContext.HttpContext.User.GetLoggedInUserId(),
                TodoId = Id
            });
            TodoDetailsWithTodoCommentsModel model = new()
            {
                Todo = todo,
                TodoComments = commentList.OrderByDescending(x => x.Id).ToList(),
                TodoFiles = fileList.ToList(),
                ResolutionDto = resolutionDto,
                ReviewDto = reviewDto,
                TodoAssignDto = todoAssignDto,
                TodoRejectedDto = todoRejectedDto,
                UserList = new SelectList(list,"Id","UserName"),
                UserViewsTodo = _todoViewsUserService.GetViewsUserCountByTodoId(Id).OrderByDescending(x => x.Sayi).ToList()
            };
            
            return View(model);
        }
        public async Task<IActionResult> AddComment(TodoDetailsWithTodoCommentsModel model)
        {
            if (!string.IsNullOrEmpty(model.TodoCommentCreate.Definition))
            {
                var mappingEntity = _mapper.Map<TodoComment>(model.TodoCommentCreate);
                mappingEntity.AppUserId = _httpContext.HttpContext.User.GetLoggedInUserId();
                mappingEntity.TodoId = model.Todo.Id;
                await _todoCommentService.CreateAsync(mappingEntity);
                return RedirectToAction("TodoDetails", "Home", new { Id = model.Todo.Id });
            }
            return RedirectToAction("TodoDetails", "Home", new { Id = model.Todo.Id });
        }
        [HttpGet]
        public async Task<FileResult> DownloadFile(string name)
        {
            var bytes = await _todoFileService.GetDownloadFile(name);

            return File(bytes, "application/octet-stream", name);
        }
        [HttpPost]
        public async Task<IActionResult> TodoFileUpload(int Id, IFormFile file)
        {
            if (file != null  &&file.Length > 5)
            {
                var user =await _customUserManager.GetUserFindId(_httpContext.HttpContext.User.GetLoggedInUserId());
                
                var entity = new TodoFileCreateDto()
                {
                    TodoId = Id,
                };
                await _todoFileService.CreateTodoFile(entity, file);
                var comment = new TodoComment()
                {
                    TodoId = Id,
                    AppUserId = 2,
                    CreatedDate = DateTime.Now,
                    Definition = $"{user.FirstName} {user.LastName} Bildirime Dosya Ekledi <strong class='text-success'>{file.FileName}</strong>"

                };
               await  _todoCommentService.CreateAsync(comment);
            }
            _notyf.Information($"({Id}) Nolu Bildirime {file.FileName} Dosya Eklendi.");
            return RedirectToAction("TodoDetails", "Home", new { id = Id });
        }



    }
}