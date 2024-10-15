using mahya_store.Application.Services.Users.Commands.EditUser;
using mahya_store.Application.Services.Users.Commands.RegisterUser;
using mahya_store.Application.Services.Users.Commands.RemoveUser;
using mahya_store.Application.Services.Users.Commands.UserStatusChange;
using mahya_store.Application.Services.Users.Queries.GetRoles;
using mahya_store.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Endpoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IEditUserService _editUserService;
        private readonly IUserStatusChangeService _userStatusChangeService;
        public UsersController(IGetUsersService getUsersService,
            IGetRolesService getRolesService, 
            IRegisterUserService registerUserService,
            IRemoveUserService removeUserService,
            IEditUserService editUserService,
            IUserStatusChangeService userStatusChangeService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _editUserService = editUserService;
            _userStatusChangeService = userStatusChangeService;
        }
        

        public IActionResult Index(string searchKey, int page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUsersDto
            {
                Page = page,
                SearchKey = searchKey,
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                Roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto()
                    {
                        Id = RoleId
                    }
                },
                Password = Password,
                RePassword = RePassword,

            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult UserSatusChange(long UserId)
        {
            return Json(_userStatusChangeService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, String FullName)
        {
            return Json(_editUserService.Execute(new RequestEditUserDto
            {
                FullName = FullName,
                UserId = UserId
            }));
        }
    }
}
