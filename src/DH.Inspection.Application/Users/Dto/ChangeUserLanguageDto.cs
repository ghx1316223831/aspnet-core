using System.ComponentModel.DataAnnotations;

namespace DH.Inspection.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}