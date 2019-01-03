using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPForum_.ViewModels
{
    public class TopicViewModel
    {
        public int Id { get; set; }

        public string Header { get; set; }

        public string Description { get; set; }

        public List<CommentViewModel> Comments { get; set; }
    }
}