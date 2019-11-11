using System.Threading.Tasks;
using Abp.Application.Services;
using EloBoost.Sessions.Dto;

namespace EloBoost.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
