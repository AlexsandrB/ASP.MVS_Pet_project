using System;
using System.ComponentModel.DataAnnotations;

namespace ModelsContext.Models
{
    public class Users
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public byte EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SequrityStamp { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public byte PhoneNumberConfirmed { get; set; }

        public byte TwoFactorEnabled { get; set; }

        public DateTime LockoutEndDateUtc { get; set; }

        public byte LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Required]
        [StringLength(30)]
        public string UserName { get; set; }
    }
}
