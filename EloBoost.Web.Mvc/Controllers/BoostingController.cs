using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Runtime.Session;
using Abp.Web.Models;
using EloBoost.Boosters;
using EloBoost.Boosters.Dto;
using EloBoost.Controllers;
using EloBoost.Models.Boosters;
using EloBoost.Shared.Enums;
using EloBoost.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EloBoost.Web.Controllers
{
    public class BoostingController : EloBoostControllerBase
    {
        private readonly OrdersAppService _ordersAppService;
        private readonly OrdersHistoryAppService _ordersHistoryAppService;

        /// <summary>
        /// Constructor
        /// </summary>
        public BoostingController(OrdersAppService ordersAppService, OrdersHistoryAppService ordersHistoryAppService)
        {
            _ordersAppService = ordersAppService;
            _ordersHistoryAppService = ordersHistoryAppService;
        }

        /// <summary>
        /// League Boosting Page
        /// </summary>
        public IActionResult Index()
        {
            var model = new BoostersPageViewModel
            {
                SourceLeagueTypes = LeagueTypes.Bronze.ToString(),
                SourceDivisionTypes = DivisionTypes.Division5.ToString(),
                DestinationLeagueTypes = LeagueTypes.Silver.ToString(),
                DestinationDivisionTypes = DivisionTypes.Division1.ToString(),
                LeaguePoints = LeaguePoints.Lp0.ToString(),
                QueueTypes = QueueTypes.flex_rift.ToString(),
                ServerNames = ServerNames.TR.ToString()
            };
            return View(model);
        }

        public IActionResult DuoBoosting()
        {
            return View();
        }

        public IActionResult WinBoosting()
        {
            return View();
        }

        public IActionResult PlacementMatches()
        {
            return View();
        }

        public IActionResult NormalWins()
        {
            return View();
        }

        /// <summary>
        /// Purchase 
        /// </summary>
        /// <returns></returns>
        [HttpPost, UnitOfWork, ValidateAntiForgeryToken]
        public async Task<JsonResult> Purchase(BoostersPageViewModel model)
        {
            if (!model.FormSecurity.IsNullOrEmpty() || model.Price <= 0 || AbpSession.UserId == null)
            {
                return Json(new AjaxResponse { Success = false, Error = new ErrorInfo { Message = "Hatalı gönderim" } });
            }
            //add to cart
            DtoOrders order = await _ordersAppService.Create(new DtoOrders
            {
                UserId = AbpSession.GetUserId(),
                Guid = Guid.NewGuid(),
                BoostType = BoostType.EloBoost,
                OrderStatus = OrderStatus.Created,
                ServerName = (ServerNames)model.ServerNames.ToInteger(),
                QueueType = (QueueTypes)model.QueueTypes.ToInteger(),
                CurrentLeague = (LeagueTypes)model.SourceLeagueTypes.ToInteger(),
                CurrentDivision = (DivisionTypes)model.SourceDivisionTypes.ToInteger(),
                CurrentPoints = (LeaguePoints)model.LeaguePoints.ToInteger(),
                DesiredLeague = (LeagueTypes)model.DestinationLeagueTypes.ToInteger(),
                DesiredDivision = (DivisionTypes)model.DestinationDivisionTypes.ToInteger(),
                ServiceType = 0,
                DesiredGamesOrWinsOrPoints = 0,
                Amount = model.Price
            });
            await _ordersHistoryAppService.Create(new DtoOrdersHistory
            {
                OrdersId = order.Id,
                OrderStatus = order.OrderStatus
            });
            //save
            await UnitOfWorkManager.Current.SaveChangesAsync();
            //return
            return Json(new AjaxResponse { TargetUrl = "/Cart" });
        }
    }
}