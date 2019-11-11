using Abp.AspNetCore.Mvc.Authorization;
using EloBoost.Authorization.Accounts;
using EloBoost.Boosters;
using EloBoost.Boosters.Dto;
using EloBoost.Controllers;
using EloBoost.Models.Boosters;
using EloBoost.Sessions;
using EloBoost.Sessions.Dto;
using EloBoost.Shared.Enums;
using EloBoost.Users;
using EloBoost.Users.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EloBoost.Web.Controllers
{
    [AbpMvcAuthorize]
    public class OrdersController : EloBoostControllerBase
    {
        private readonly IAccountAppService _accountAppService;
        private readonly OrdersAppService _ordersAppService;
        private readonly UserAppService _userAppService;
        private readonly UserLoginInfoDto _user;
        private readonly InputSearch _inputSearch;

        public OrdersController(ISessionAppService sessionAppService, OrdersAppService ordersAppService, UserAppService userAppService, IAccountAppService accountAppService)
        {
            _ordersAppService = ordersAppService;
            _userAppService = userAppService;
            _accountAppService = accountAppService;
            _user = sessionAppService.GetCurrentLoginInformations().Result.User;
            _inputSearch = new InputSearch { ClientId = _user.UserType == UserType.User ? _user.Id : 0 };
        }

        public async Task<ActionResult> Index()
        {
            var orders = (await _ordersAppService.GetAllByUser(_inputSearch)).Items;
            var users = _user.UserType == UserType.User
                ? new List<UserDto> { await _accountAppService.MyProfile(_user.Id) }//if user is client get only his info
                : (await _userAppService.GetAll(_inputSearch)).Items;//else get all clients
            //add client info to order list
            var model = (from item in orders
                         let user = users.FirstOrDefault(m => m.Id == item.UserId)
                         where user != null
                         select new OrderListViewModel
                         {
                             Guid = item.Guid,
                             CurrentLeague = item.CurrentLeague,
                             CurrentPoints = item.CurrentPoints,
                             CurrentDivision = item.CurrentDivision,
                             QueueType = item.QueueType,
                             ServerName = item.ServerName,
                             ServiceType = item.ServiceType,
                             BoostType = item.BoostType,
                             OrderStatus = item.OrderStatus,
                             CreatorUserId = item.CreatorUserId,
                             UserId = item.UserId,//we write the name of the use who works with this order
                             Username = user.UserName
                         }).ToList();

            ViewBag.isUser = _user.UserType == UserType.User;
            return View("Index", model);
        }
    }
}