using Abp.Application.Services.Dto;
using EloBoost.Boosters.Dto;
using System.Threading.Tasks;

namespace EloBoost.Boosters
{
    public interface IGetAllAppService<T>
    {
        Task<PagedResultDto<T>> GetAllByUser(InputSearch input);
    }
}
