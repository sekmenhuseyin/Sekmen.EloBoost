using Abp;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Notifications;
using Abp.Timing;
using Abp.UI;
using Abp.Web.Models;
using Abp.Zero.Configuration;
using EloBoost.Authorization;
using EloBoost.Authorization.Users;
using EloBoost.Controllers;
using EloBoost.Identity;
using EloBoost.Models.Account;
using EloBoost.MultiTenancy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EloBoost.Web.Controllers
{
    /// <summary>
    /// Login, Logout & Register actions
    /// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    /// </summary>
    public class AccountController : EloBoostControllerBase
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly AbpLoginResultTypeHelper _abpLoginResultTypeHelper;
        private readonly LogInManager _logInManager;
        private readonly SignInManager _signInManager;
        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly INotificationPublisher _notificationPublisher;

        public AccountController(IUnitOfWorkManager unitOfWorkManager,
            AbpLoginResultTypeHelper abpLoginResultTypeHelper,
            LogInManager logInManager,
            SignInManager signInManager,
            UserRegistrationManager userRegistrationManager,
            INotificationPublisher notificationPublisher)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _abpLoginResultTypeHelper = abpLoginResultTypeHelper;
            _logInManager = logInManager;
            _signInManager = signInManager;
            _userRegistrationManager = userRegistrationManager;
            _notificationPublisher = notificationPublisher;
        }

        /// <summary>
        /// Login page
        /// </summary>
        /// <param name="userNameOrEmailAddress"></param>
        /// <param name="returnUrl"></param>
        /// <param name="successMessage"></param>
        /// <returns></returns>
        public ActionResult Login(string userNameOrEmailAddress = "", string returnUrl = "", string successMessage = "")
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = GetAppDashBoardUrl();
            }

            return View(new LoginFormViewModel
            {
                ReturnUrl = returnUrl,
                MultiTenancySide = AbpSession.MultiTenancySide
            });
        }

        /// <summary>
        /// login form submit
        /// </summary>
        /// <param name="loginModel"></param>
        /// <param name="returnUrl"></param>
        /// <param name="returnUrlHash"></param>
        /// <returns></returns>
        [HttpPost, UnitOfWork]
        public virtual async Task<JsonResult> Login(LoginViewModel loginModel, string returnUrl = "", string returnUrlHash = "")
        {
            returnUrl = NormalizeReturnUrl(returnUrl);
            if (!string.IsNullOrWhiteSpace(returnUrlHash))
            {
                returnUrl = returnUrl + returnUrlHash;
            }

            var loginResult = await GetLoginResultAsync(loginModel.UsernameOrEmailAddress, loginModel.Password);

            await _signInManager.SignInAsync(loginResult.Identity, loginModel.RememberMe);
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return Json(new AjaxResponse { TargetUrl = returnUrl });
        }

        /// <summary>
        /// logout actions
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect(GetAppHomeUrl());
        }

        /// <summary>
        /// login
        /// </summary>
        /// <param name="usernameOrEmailAddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task<AbpLoginResult<Tenant, User>> GetLoginResultAsync(string usernameOrEmailAddress, string password)
        {
            var loginResult = await _logInManager.LoginAsync(usernameOrEmailAddress, password, "Default");

            switch (loginResult.Result)
            {
                case AbpLoginResultType.Success:
                    return loginResult;
                default:
                    throw _abpLoginResultTypeHelper.CreateExceptionForFailedLoginAttempt(loginResult.Result, usernameOrEmailAddress, "Default");
            }
        }

        /// <summary>
        /// register new user page 
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View("Register", new RegisterViewModel());
        }

        /// <summary>
        /// register actions
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, UnitOfWork]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (model.EmailAddress.IsNullOrEmpty() || model.Password.IsNullOrEmpty())
                {
                    throw new UserFriendlyException(L("FormIsNotValidMessage"));
                }

                var user = await _userRegistrationManager.RegisterAsync(
                    model.Name,
                    model.Surname,
                    model.EmailAddress,
                    model.EmailAddress,
                    model.Password,
                    true // Assumed email address is always confirmed. Change this if you want to implement email confirmation.
                );

                // Getting tenant-specific settings
                var isEmailConfirmationRequiredForLogin = await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin);

                await _unitOfWorkManager.Current.SaveChangesAsync();

                return View("RegisterResult", new RegisterResultViewModel
                {
                    TenancyName = "Default",
                    NameAndSurname = user.Name + " " + user.Surname,
                    UserName = user.UserName,
                    EmailAddress = user.EmailAddress,
                    IsEmailConfirmed = user.IsEmailConfirmed,
                    IsActive = user.IsActive,
                    IsEmailConfirmationRequiredForLogin = isEmailConfirmationRequiredForLogin
                });
            }
            catch (UserFriendlyException ex)
            {
                ViewBag.ErrorMessage = ex.Message;

                return View("Register", model);
            }
        }

        /// <summary>
        /// Forgot password page
        /// </summary>
        /// <returns></returns>
        public ActionResult ForgotPassword(string id)
        {
            return View(id.IsNullOrEmpty() ? "ForgotPassword" : "VerifyAccount");
        }

        public ActionResult ChangePassword(string id)
        {
            return View();
        }

        [HttpPost, UnitOfWork]
        public JsonResult PasswordReminder(string email)
        {
            return Json(new AjaxResponse { TargetUrl = "/Account/ForgotPassword/VerifyAccount" });
        }

        [HttpPost, UnitOfWork]
        public JsonResult VerifyAccount(string email)
        {
            return Json(new AjaxResponse { TargetUrl = "/Account/ChangePassword" });
        }

        /// <summary>
        /// homepage url
        /// </summary>
        /// <returns></returns>
        public string GetAppHomeUrl()
        {
            return Url.Action("Index", "Home");
        }

        /// <summary>
        /// dashboard url
        /// </summary>
        /// <returns></returns>
        public string GetAppDashBoardUrl()
        {
            return Url.Action("Index", "DashBoard");
        }

        /// <summary>
        /// returnURl Normilzer
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <param name="defaultValueBuilder"></param>
        /// <returns></returns>
        private string NormalizeReturnUrl(string returnUrl, Func<string> defaultValueBuilder = null)
        {
            if (defaultValueBuilder == null)
            {
                defaultValueBuilder = GetAppDashBoardUrl;
            }

            if (returnUrl.IsNullOrEmpty())
            {
                return defaultValueBuilder();
            }

            if (Url.IsLocalUrl(returnUrl))
            {
                return returnUrl;
            }

            return defaultValueBuilder();
        }

        /// <summary>
        /// This is a demo code to demonstrate sending notification to default tenant admin and host admin uers.
        /// Don't use this code in production !!!
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<ActionResult> TestNotification(string message = "")
        {
            if (message.IsNullOrEmpty())
            {
                message = "This is a test notification, created at " + Clock.Now;
            }

            var defaultTenantAdmin = new UserIdentifier(1, 2);
            var hostAdmin = new UserIdentifier(null, 1);

            await _notificationPublisher.PublishAsync(
                    "App.SimpleMessage",
                    new MessageNotificationData(message),
                    severity: NotificationSeverity.Info,
                    userIds: new[] { defaultTenantAdmin, hostAdmin }
                 );

            return Content("Sent notification: " + message);
        }

    }
}
