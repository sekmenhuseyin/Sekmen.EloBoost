using System.ComponentModel.DataAnnotations;

namespace EloBoost.Shared.Enums
{
    public enum BoostType : byte
    {
        [Display(Name = "Elo Boost")]
        EloBoost = 1,

        [Display(Name = "League Boost")]
        LeagueBoost = 2,

        [Display(Name = "Win Boost")]
        WinBoost = 3,

        [Display(Name = "Duo Boost")]
        DuoBoost = 4,

        [Display(Name = "Placement Match")]
        PlacementMatch = 5,

        [Display(Name = "Normal WinBoost")]
        NormalWinBoost = 6,

        [Display(Name = "3x3 Boost")]
        ThreeByThreeBoost = 7,

        [Display(Name = "Startup")]
        Startup = 8,

    }
}
