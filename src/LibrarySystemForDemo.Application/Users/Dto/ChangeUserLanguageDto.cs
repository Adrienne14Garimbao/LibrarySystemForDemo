using System.ComponentModel.DataAnnotations;

namespace LibrarySystemForDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}