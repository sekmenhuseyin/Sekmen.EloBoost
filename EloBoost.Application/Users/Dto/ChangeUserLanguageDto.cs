using System.ComponentModel.DataAnnotations;

namespace EloBoost.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}