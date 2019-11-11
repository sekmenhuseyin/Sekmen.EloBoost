using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EloBoost.Roles.Dto;
using EloBoost.Users.Dto;

namespace EloBoost.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
