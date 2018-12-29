using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPForum_.Models.Topics
{
    public class AddTopicModel
    {
        [Required]
        [StringLength(200, ErrorMessage = "asdqweqwe", MinimumLength = 0)]
        public string Header { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }
    }
}