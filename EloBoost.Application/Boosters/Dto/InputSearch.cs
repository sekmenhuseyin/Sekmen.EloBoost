using Abp.Application.Services.Dto;

namespace EloBoost.Boosters.Dto
{
    public class InputSearch : PagedAndSortedResultRequestDto
    {
        public long UserId { get; set; }
        public long ClientId { get; set; }
        public string Guid { get; set; }
    }
}
