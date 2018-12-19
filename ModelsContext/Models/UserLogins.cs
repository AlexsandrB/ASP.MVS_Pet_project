using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsContext.Models
{
    public class UserLogins
    {
        [Key]
        public string LoginProvider { get; set; }

        [Key]
        public string ProviderKey { get; set; }

        [Key]
        public string Userid { get; set; }
    }
}
