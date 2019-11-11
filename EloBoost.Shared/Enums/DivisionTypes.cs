using System.ComponentModel.DataAnnotations;

namespace EloBoost.Shared.Enums
{
    public enum DivisionTypes : byte
    {
        [Display(Name = "Küme 1")]
        Division1 = 1,

        [Display(Name = "Küme 2")]
        Division2 = 2,

        [Display(Name = "Küme 3")]
        Division3 = 3,

        [Display(Name = "Küme 4")]
        Division4 = 4,

        [Display(Name = "Küme 5")]
        Division5 = 5
    }
}
