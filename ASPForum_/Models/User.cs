using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPForum_.Models
{
    public class User
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// false = active, true = deleted
        /// </summary>
        public bool Deleted { get; set; }


        public List<Comment> Comments { get; set; }
        public List<Topic> Topics { get; set; }
    }
}