using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetProject.Models
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(128)]
        public string Id { get; set; }

        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        public byte EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public byte PhoneNumberConfirmed { get; set; }

        [Required]
        public byte TwoFactoryEnabled { get; set; }
        
        public DateTime? LockoutEndFateUtc { get; set; }
        
        [Required]
        public byte LockoutEnabled { get; set; }

        [Required]
        public int AccessFailedCount { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

    }
}