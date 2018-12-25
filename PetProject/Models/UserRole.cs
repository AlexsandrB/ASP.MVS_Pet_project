using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetProject.Models
{
    public class UserRole
    {
        [Key]
        [Required]
        [StringLength(128)]
        public string UserId { get; set; }
        public User User { get; set; }

        [Key]
        [Required]
        [StringLength(128)]
        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}