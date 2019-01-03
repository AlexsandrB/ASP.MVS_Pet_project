using ASPForum_.Models;
using ASPForum_.Models.CommentsAdministrationModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ASPForum_.Controllers
{
    public class CommentsController : Controller
    {
        
        // GET: Comments/Add
        public ActionResult Add(string topicHeader, int topicId)
        {
            return View(new AddCommentModel()
            {
                TopicHeader = topicHeader,
                TopicId = topicId
            });
        }

        // POST: Comments/Add
        [HttpPost]
        public ActionResult Add(AddCommentModel model)
        {
            if (ModelState.IsValid)
            {
                string currentUserId = HttpContext.User.Identity.GetUserId();
                using (var context = ApplicationDbContext.Create())
                {
                    context.Comments.Add(new Comment()
                    {
                        Content = model.Content,
                        CreatedDate = DateTime.Now,
                        Deleted = false,
                        TopicId = model.TopicId,
                        UserId = currentUserId
                    });
                    context.SaveChanges();
                }

                return RedirectToAction("All", "Topics");
            }

            return View(model);
        }

        [Route("Comments/Delete/{Id}")]
        public ActionResult Delete(int id)
        {
            string result = "Comment successfully deleted!";
            string currentUserId = HttpContext.User.Identity.GetUserId();
            using (var context = ApplicationDbContext.Create())
            {
                var commentToDelete = context.Comments.FirstOrDefault(x => x.Id == id);
                if (commentToDelete?.UserId == currentUserId)
                {
                    commentToDelete.Deleted = true;
                    context.SaveChanges();
                }
                else
                {
                    result = "You can delete only your comments!";
                }
            }
            return Content(result);
        }
    }
}