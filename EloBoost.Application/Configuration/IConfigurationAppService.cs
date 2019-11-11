using System.Threading.Tasks;
using EloBoost.Configuration.Dto;

namespace EloBoost.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
