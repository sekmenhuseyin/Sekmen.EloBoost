using Abp.AspNetCore.Mvc.Authorization;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Abp.Web.Models;
using EloBoost.Authorization;
using EloBoost.Boosters;
using EloBoost.Boosters.Dto;
using EloBoost.Controllers;
using EloBoost.Models.Boosters;
using EloBoost.Sessions;
using EloBoost.Sessions.Dto;
using EloBoost.Shared.Enums;
using EloBoost.Users;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EloBoost.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.PagesSelect)]
    public class SelectController : EloBoostControllerBase
    {
        private readonly OrdersAppService _ordersAppService;
        private readonly OrdersHistoryAppService _ordersHistoryAppService;
        private readonly UserAppService _userAppService;
        private readonly UserLoginInfoDto _user;
        private readonly InputSearch _inputSearch;

        public SelectController(ISessionAppService sessionAppService, OrdersAppService ordersAppService, UserAppService userAppService, OrdersHistoryAppService ordersHistoryAppService)
        {
            _ordersAppService = ordersAppService;
            _userAppService = userAppService;
            _ordersHistoryAppService = ordersHistoryAppService;
            _user = sessionAppService.GetCurrentLoginInformations().Result.User;
            _inputSearch = new InputSearch { UserId = _user.Id };
        }

        /// <summary>
        /// See my list for coaches and boosters
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var orders = (await _ordersAppService.GetAllByUser(_inputSearch)).Items;
            var users = (await _userAppService.GetAll(_inputSearch)).Items;
            //add client info to order list
            var model = (from item in orders
                         let user = users.FirstOrDefault(m => m.Id == item.CreatorUserId)
                         where user != null &&
                               (item.OrderStatus == OrderStatus.RequestActive || item.OrderStatus == OrderStatus.BoostStarted || item.OrderStatus == OrderStatus.BoostFinished) &&
                               (item.UserId == _user.Id || item.UserId == item.CreatorUserId)
                         select new OrderListViewModel
                         {
                             Id = item.Id,
                             UserId = item.UserId,
                             Guid = item.Guid,
                             BoostType = item.BoostType,
                             OrderStatus = item.OrderStatus,
                             ServerName = item.ServerName,
                             QueueType = item.QueueType,
                             CurrentLeague = item.CurrentLeague,
                             CurrentDivision = item.CurrentDivision,
                             CurrentPoints = item.CurrentPoints,
                             DesiredLeague = item.DesiredLeague,
                             DesiredDivision = item.DesiredDivision,
                             ServiceType = item.ServiceType,
                             DesiredGamesOrWinsOrPoints = item.DesiredGamesOrWinsOrPoints,
                             CreationTime = item.CreationTime,
                             CreatorUserId = item.CreatorUserId,
                             Username = user.UserName
                         }).ToList();

            ViewBag.UserType = _user.UserType;
            return View("Index", model);
        }

        /// <summary>
        /// select a client from Coaching waiting list
        /// </summary>
        public IActionResult ForCoaching()
        {
            return View();
        }

        /// <summary>
        /// select a client from Boosting waiting list
        /// </summary>
        public IActionResult ForBoosting()
        {
            return View();
        }

        /// <summary>
        /// Status report
        /// </summary>
        public IActionResult Status()
        {
            return View();
        }

        /// <summary>
        /// Start working on an order
        /// </summary>
        /// <param name="id">guid of order</param>
        [HttpPost, UnitOfWork]
        public async Task<JsonResult> StartOrder(string id)
        {
            //control
            AjaxResponse result = new AjaxResponse { Success = false, Error = new ErrorInfo { Message = L("OrderNotFound") } };
            DtoOrders order = (await _ordersAppService.GetAllByUser(new InputSearch { Guid = id })).Items.FirstOrDefault();
            if (order == null)
                return Json(result);
            //save
            order.OrderStatus = OrderStatus.BoostStarted;
            order.UserId = AbpSession.GetUserId();
            await _ordersAppService.Update(order);
            await _ordersHistoryAppService.Create(new DtoOrdersHistory
            {
                OrdersId = order.Id,
                OrderStatus = order.OrderStatus
            });
            //save
            await UnitOfWorkManager.Current.SaveChangesAsync();
            //return
            result.Success = true;
            result.Error = null;
            result.TargetUrl = "/Select";
            return Json(result);
        }

        /// <summary>
        /// Finish working on an order
        /// </summary>
        /// <param name="id">guid of order</param>
        [HttpPost, UnitOfWork]
        public async Task<JsonResult> FinishOrder(string id)
        {
            //control
            AjaxResponse result = new AjaxResponse { Success = false, Error = new ErrorInfo { Message = L("OrderNotFound") } };
            DtoOrders order = (await _ordersAppService.GetAllByUser(new InputSearch { Guid = id })).Items.FirstOrDefault();
            if (order == null)
                return Json(result);
            //save
            order.OrderStatus = OrderStatus.BoostFinished;
            order.UserId = AbpSession.GetUserId();
            await _ordersAppService.Update(order);
            await _ordersHistoryAppService.Create(new DtoOrdersHistory
            {
                OrdersId = order.Id,
                OrderStatus = order.OrderStatus
            });
            //save
            await UnitOfWorkManager.Current.SaveChangesAsync();
            //return
            result.Success = true;
            result.Error = null;
            result.TargetUrl = "/Select";
            return Json(result);
        }
    }
}