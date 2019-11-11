using System.ComponentModel.DataAnnotations;

namespace EloBoost.Shared.Enums
{
    public enum LeaguePoints : byte
    {
        [Display(Name = "LP 0-12")]
        Lp0 = 0,

        [Display(Name = "LP 13-16")]
        Lp1 = 1,

        [Display(Name = "LP 17-19")]
        Lp2 = 2,

        [Display(Name = "LP 20+")]
        Lp3 = 3
    }
}
