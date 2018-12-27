using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPForum_.Models
{
    public class Topic
    { 
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        
        public List<Comment> Comment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}