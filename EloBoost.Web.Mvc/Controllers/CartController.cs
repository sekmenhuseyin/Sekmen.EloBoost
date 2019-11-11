using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Web.Models;
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
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EloBoost.Web.Controllers
{
    [AbpMvcAuthorize]
    public class CartController : EloBoostControllerBase
    {
        private readonly OrdersAppService _ordersAppService;
        private readonly OrdersHistoryAppService _ordersHistoryAppService;
        private readonly UserAppService _userAppService;
        private readonly UserLoginInfoDto _user;
        private readonly InputSearch _inputSearch;
        private readonly UserDto _userDto;

        public CartController(ISessionAppService sessionAppService, OrdersAppService ordersAppService, UserAppService userAppService, OrdersHistoryAppService ordersHistoryAppService)
        {
            _ordersAppService = ordersAppService;
            _userAppService = userAppService;
            _ordersHistoryAppService = ordersHistoryAppService;
            _user = sessionAppService.GetCurrentLoginInformations().Result.User;
            _inputSearch = new InputSearch { ClientId = _user.Id };
            _userDto = new UserDto { Id = _user.Id };
        }

        /// <summary>
        /// Cart Page
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var list = (await _ordersAppService.GetAllByUser(_inputSearch)).Items
                .Where(m => m.OrderStatus == OrderStatus.Created);

            return View(list);
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Pay(string id)
        {
            ViewBag.id = id;
            return View();
        }

        public IActionResult Summary()
        {
            return View();
        }

        /// <summary>
        /// Checkout 
        /// </summary>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> Checkout(BoostersPageViewModel model)
        {
            if (!model.FormSecurity.IsNullOrEmpty())
            {
                return Json(new AjaxResponse { Success = false, Error = new ErrorInfo { Message = "Hatalı gönderim" } });
            }
            //add to cart
            var order = (await _ordersAppService.GetAll(new PagedAndSortedResultRequestDto { MaxResultCount = 20 })).Items
                            .FirstOrDefault(m => m.OrderStatus == OrderStatus.Created);
            var guid = order?.Guid ?? Guid.NewGuid();
            //return
            return Json(new AjaxResponse { TargetUrl = "/Cart/Pay/" + guid });
        }

        /// <summary>
        /// Pay 
        /// </summary>
        /// <returns></returns>
        [HttpPost, UnitOfWork, ValidateAntiForgeryToken]
        public async Task<JsonResult> Pay(BoostersPageViewModel model)
        {
            if (!model.FormSecurity.IsNullOrEmpty())
            {
                return Json(new AjaxResponse { Success = false, Error = new ErrorInfo { Message = "Hatalı gönderim" } });
            }
            //add to cart
            var order = (await _ordersAppService.GetAllByUser(new InputSearch { Guid = model.Guid })).Items.FirstOrDefault();
            if (order == null)
                return Json(new AjaxResponse { Error = new ErrorInfo { Details = "Order not found", Message = "Refresh page" } });

            order.OrderStatus = OrderStatus.RequestActive;
            //order.OrderStatus = OrderStatus.WaitingPaymentApproval;
            await _ordersAppService.Update(order);
            await _ordersHistoryAppService.Create(new DtoOrdersHistory
            {
                OrdersId = order.Id,
                OrderStatus = order.OrderStatus
            });
            //save
            await UnitOfWorkManager.Current.SaveChangesAsync();
            //return
            return Json(new AjaxResponse { TargetUrl = "/Cart/Summary" });
        }
    }
}