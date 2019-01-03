using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPForum_.Models.CommentsAdministrationModels
{
    public class AddCommentModel
    {

        [Required]
        public string Content { get; set; }

        [Required]
        public int TopicId { get; set; }
        [Required]
        public string TopicHeader { get; set; }
    }
}