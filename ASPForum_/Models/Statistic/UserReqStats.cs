using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPForum_.Models.Statistic
{
    public class UserReqStats
    {
        [Key]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        #region Topics
        public int AllTopics { get; set; }
        public int TodayTopics { get; set; }
        public int AddTopic { get; set; }
        public int DeleteTopic { get; set; }
        #endregion Topics

        #region Comments
        public int AddComment { get; set; }
        public int DeleteComment { get; set; }
        #endregion Comments

        #region User
        public double Activity { get; set; }
        #endregion User 
        
    }
}