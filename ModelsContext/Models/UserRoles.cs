using System.ComponentModel.DataAnnotations;

namespace ModelsContext.Models
{
    public class UserRoles
    {
        [Key]
        public string UserId { get; set; }

        [Key]
        public string RoleId { get; set; }
    }
}
