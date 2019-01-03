using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPForum_.ViewModels
{
    public class CommentViewModel
    {
        public string CommentatorName { get; set; }
        
        public string Content { get; set; }

        public DateTime CreationDate { get; set; }
    }
}