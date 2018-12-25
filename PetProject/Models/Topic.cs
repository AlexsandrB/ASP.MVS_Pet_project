using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetProject.Models
{
    public class Topic
    {
        [Required]
        [StringLength(50)]
        public string Header { get; set; }
        
        public string Desription { get; set; }
    }
}