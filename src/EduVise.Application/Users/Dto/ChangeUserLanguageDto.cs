using System.ComponentModel.DataAnnotations;

namespace EduVise.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}