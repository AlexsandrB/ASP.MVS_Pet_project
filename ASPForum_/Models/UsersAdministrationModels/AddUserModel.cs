using System.ComponentModel.DataAnnotations;

namespace ASPForum_.Models.UsersAdministrationModels
{
    public class AddUserModel
    {
        [Required]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Descripotion of your account can consists of 200 symbols")]
        public string About { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Login must be 6 - 20 symbols length", MinimumLength = 6)]
        public string Login { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Password must be 6 - 20 symbols length", MinimumLength = 6)]
        public string Password { get; set; }

    }
}