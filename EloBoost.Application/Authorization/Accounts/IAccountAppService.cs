using Abp.Application.Services;
using EloBoost.Authorization.Accounts.Dto;
using EloBoost.Users.Dto;
using System.Threading.Tasks;

namespace EloBoost.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<RegisterOutput> Register(RegisterInput input);

        Task<UserDto> MyProfile(long input);
    }
}
