using System.ComponentModel.DataAnnotations;

namespace EloBoost.Shared.Enums
{
    public enum ServiceType : byte
    {
        [Display(Name = "Solo")]
        Solo = 1,

        [Display(Name = "Duo")]
        Duo = 2
    }
}
