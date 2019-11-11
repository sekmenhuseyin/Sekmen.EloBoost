using System.ComponentModel.DataAnnotations;

namespace EloBoost.Shared.Enums
{
    public enum QueueTypes : byte
    {
        [Display(Name = "Flex Summoners Rift (5v5)")]
        flex_rift = 1,

        [Display(Name = "Solo/Duo (5v5)")]
        solo_duo = 2,

        [Display(Name = "Flex Twisted Treeline (3v3)")]
        flex_treeline = 3
    }
}
