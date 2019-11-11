using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EloBoost.Authorization.Users;
using EloBoost.Shared.Enums;

namespace EloBoost.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public UserType UserType { get; set; }

        public decimal Creadit { get; set; }
    }
}
