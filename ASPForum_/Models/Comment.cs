using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPForum_.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// false = active, true = deleted
        /// </summary>
        public bool Deleted { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}