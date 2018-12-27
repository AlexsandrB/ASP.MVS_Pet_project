using ASPForum_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPForum_.ViewModels
{
    public class RendomTopicViewModel
    {
        public Topic Topic { get; set; }
        public List<User> Users { get; set; }
    }
}