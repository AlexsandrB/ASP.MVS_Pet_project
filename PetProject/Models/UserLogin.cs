using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetProject.Models
{
    public class UserLogin
    {
        [Key]
        [Required]
        [StringLength(128)]
        public string LoginProvider { get; set; }

        [Key]
        [Required]
        [StringLength(128)]
        public string ProviderKey { get; set; }

        [Key]
        [Required]
        [StringLength(128)]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}