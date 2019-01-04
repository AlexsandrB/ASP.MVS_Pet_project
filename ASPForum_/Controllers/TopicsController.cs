using ASPForum_.Models;
using ASPForum_.Models.Topics;
using ASPForum_.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPForum_.Controllers
{
    public class TopicsController : Controller
    {

        // GET: Topics/Today
        public ActionResult Today()
        {
            List<Topic> topics = new List<Topic>();
            using (var context = ApplicationDbContext.Create())
            {
                topics = context.Topics.Where(x => !x.Deleted
                                                 && x.CreationDate.Year == DateTime.Now.Year
                                                 && x.CreationDate.Month == DateTime.Now.Month
                                                 && x.CreationDate.Day == DateTime.Now.Day).ToList();
            }

            var topicsViewModel = new TopicsListViewModel();
            topicsViewModel.Topics = new List<TopicViewModel>();

            topics.ForEach(x =>
            {
                var topicViewModel = new TopicViewModel()
                {
                    Header = x.Header,
                    Id = x.Id,
                    Description = x.Description,
                    Comments = new List<CommentViewModel>()
                };

                using (var context = ApplicationDbContext.Create())
                {
                    topicViewModel.Comments = context.Comments
                                                     .Where(q => q.TopicId == topicViewModel.Id && !q.Deleted)
                                                     .Select(q => new CommentViewModel()
                                                     {
                                                         Content = q.Content,
                                                         CommentatorName = q.User.UserName,
                                                         CreationDate = q.CreatedDate
                                                     }).ToList();
                }

                topicsViewModel.Topics.Add(topicViewModel);
            });

            return View(topicsViewModel);
        }

        // GET: Topics/All
        public ActionResult All()
        {
            List<Topic> topics = new List<Topic>();
            using (var context = ApplicationDbContext.Create())
            {
                topics = context.Topics.Where(x => !x.Deleted).ToList();
            }

            var topicsViewModel = new TopicsListViewModel();
            topicsViewModel.Topics = new List<TopicViewModel>();

            topics.ForEach(x =>
            {
                var topicViewModel = new TopicViewModel()
                {
                    Header = x.Header,
                    Id = x.Id,
                    Description = x.Description,
                    Comments = new List<CommentViewModel>()
                };

                using (var context = ApplicationDbContext.Create())
                {
                    topicViewModel.Comments = context.Comments
                                                     .Where(q => q.TopicId == topicViewModel.Id && !q.Deleted)
                                                     .Select(q => new CommentViewModel()
                                                     {
                                                         Content = q.Content,
                                                         CommentatorName = q.User.UserName,
                                                         CreationDate = q.CreatedDate
                                                     }).ToList();
                }

                topicsViewModel.Topics.Add(topicViewModel);
            });

            return View(topicsViewModel);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // GET: Topics/Add
        public ActionResult Add()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Topics", "Today");
        }

        // POST: Topics/Add
        [HttpPost]
        public ActionResult Add(AddTopicModel model)
        {
            if (ModelState.IsValid)
            {
                string CurrentUserId = HttpContext.User.Identity.GetUserId();

                using (ApplicationDbContext context = ApplicationDbContext.Create())
                {
                    context.Topics.Add(new Topic()
                    {
                        CreationDate = DateTime.Now,
                        Description = model.Description,
                        Deleted = false,
                        Header = model.Header,
                        UserId = CurrentUserId
                    });
                    context.SaveChanges();
                }
                return RedirectToAction("Topics", "Today");
            }

            return View(model);
        }

        // GET: Topics/Delete/{id}
        [Route("Topics/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            string result = "Topic successfully deleted";
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                var topicToDelete = context.Topics.FirstOrDefault(x => x.Id == id);
                if (topicToDelete == null)
                {
                    topicToDelete.Deleted = true;
                }
                else
                {
                    result = "Something goes wrong";
                }
                context.SaveChanges();
            }
            return Content(result);
        }

        // GET: Topics/Created/{year}/{month}/{day}
        [Route("topics/created/{year}/{month:regex(\\d{2}):range(1, 12)}/{day:regex(\\d):range(1, 31)}")]
        public ActionResult TopicsByDate(int year, int? month, int? day)
        {
            List<Topic> topics = new List<Topic>();
            using (var context = ApplicationDbContext.Create())
            {
                topics = context.Topics.Where(x => !x.Deleted
                                                 && x.CreationDate.Year == year
                                                 && x.CreationDate.Month == month
                                                 && x.CreationDate.Day == day).ToList();
            }

            var topicsViewModel = new TopicsListViewModel();
            topicsViewModel.Topics = new List<TopicViewModel>();

            topics.ForEach(x =>
            {
                var topicViewModel = new TopicViewModel()
                {
                    Header = x.Header,
                    Id = x.Id,
                    Description = x.Description,
                    Comments = new List<CommentViewModel>()
                };

                using (var context = ApplicationDbContext.Create())
                {
                    topicViewModel.Comments = context.Comments
                                                     .Where(q => q.TopicId == topicViewModel.Id && !q.Deleted)
                                                     .Select(q => new CommentViewModel()
                                                     {
                                                         Content = q.Content,
                                                         CommentatorName = q.User.UserName,
                                                         CreationDate = q.CreatedDate
                                                     }).ToList();
                }

                topicsViewModel.Topics.Add(topicViewModel);
            });

            return View(topicsViewModel);
        }
    }
}