using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using EloBoost.Configuration.Dto;

namespace EloBoost.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : EloBoostAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
