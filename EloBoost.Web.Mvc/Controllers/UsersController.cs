using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using EloBoost.Authorization;
using EloBoost.Controllers;
using EloBoost.Models.Users;
using EloBoost.Users;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using EloBoost.Users.Dto;

namespace EloBoost.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.PagesUsers)]
    public class UsersController : EloBoostControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var users = (await _userAppService.GetAll(new PagedResultRequestDto { MaxResultCount = int.MaxValue })).Items.Where(m => m.Id > 1).ToList(); // Paging not implemented yet
            var roles = (await _userAppService.GetRoles()).Items;
            UserListViewModel model = new UserListViewModel
            {
                Users = users,
                Roles = roles
            };
            return View(model);
        }

        public async Task<ActionResult> EditUserModal(long userId)
        {
            UserDto user = await _userAppService.Get(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            EditUserModalViewModel model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return View("_EditUserModal", model);
        }
    }
}
