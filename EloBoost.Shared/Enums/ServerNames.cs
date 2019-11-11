using System.ComponentModel.DataAnnotations;

namespace EloBoost.Shared.Enums
{
    public enum ServerNames : byte
    {
        [Display(Name = "Europe Nordic & East")]
        EUNE = 1,

        [Display(Name = "Europe West")]
        EUW = 2,

        [Display(Name = "North America")]
        NA = 3,

        [Display(Name = "Russia")]
        RU = 4,

        [Display(Name = "Oceania")]
        OCE = 5,

        [Display(Name = "Japan")]
        JP = 6,

        [Display(Name = "Korea")]
        KR = 8,

        [Display(Name = "Brazil")]
        BR = 9,

        [Display(Name = "Latin America North")]
        LAN = 10,

        [Display(Name = "Latin America South")]
        LAS = 11,

        [Display(Name = "Turkey")]
        TR = 12
    }
}
