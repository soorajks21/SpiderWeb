using System.ComponentModel.DataAnnotations;

namespace SpiderWeb.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8,MinimumLength=4,ErrorMessage="You must specify password of 4")]
        public string Password { get; set; }
    }
}