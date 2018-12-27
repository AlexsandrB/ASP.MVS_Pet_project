using ASPForum_.Models;
using ASPForum_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPForum_.Controllers
{
    public class TopicsController : Controller
    {
        // GET: Topics/Random
        public ActionResult Random()
        {
            var topic = new Topic()
            {
                Description = "My first topic",
                Header = "Hello world!",
                CreationDate = DateTime.Now
            };

            var users = new List<User>
            {
                new User() { Name = "user1" },
                new User() { Name = "user2" }
            };

            var vm = new RendomTopicViewModel()
            {
                Topic = topic,
                Users = users
            };

            return View(vm);
        }

        // GET: Topics/Today
        public ActionResult Today()
        {
            List<Topic> topics = new List<Topic>();
            using (var context = ApplicationDbContext.Create())
            {
                topics = context.Topics.ToList();
            }

            TodayTopicsViewModel topicsVM = new TodayTopicsViewModel();
            topicsVM.Topics = topics.Select(x => new TopicViewModel()
                                                 {
                                                     Header = x.Header,
                                                 }).ToList();

            return View(topicsVM);
        }

        [Route("topics/created/{year}/{month:regex(\\d{2}):range(1, 12)}/{day:regex(\\d):range(1, 31)}")]
        public ActionResult TopicsByDate(int year, int? month, int? day)
        {
            return Content(year + "/" + (month.HasValue ? month.ToString() : "") + "/" + (day.HasValue ? day.ToString() : ""));
        }
    }
}