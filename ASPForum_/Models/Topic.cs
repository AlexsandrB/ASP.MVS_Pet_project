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
        /// <summary>
        /// false = active, true = deleted
        /// </summary>
        public bool Deleted { get; set; }

        
        public virtual List<Comment> Comments { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}