using Abp.MultiTenancy;

namespace EloBoost.Models.Account
{
    public class LoginFormViewModel
    {
        public string ReturnUrl { get; set; }

        public MultiTenancySides MultiTenancySide { get; set; }
    }
}
