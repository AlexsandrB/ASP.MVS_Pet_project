using ASPForum_.Models;
using System;
using System.Linq;
using System.Web;

namespace ASPForum_.Utils
{
    public class StatsModule : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(this.Application_EndRequest);
        }

        public void Application_EndRequest(Object source, EventArgs e)
        {
            //creating request intanse from source
            HttpApplication request = source as HttpApplication;

            //check if user exists and autetifacted
            if (request.User != null && request.User.Identity.IsAuthenticated)
            {
                using (var context = ApplicationDbContext.Create())
                {
                    //geting current user by user name from reuest.user
                    var currentUser = context.Users.FirstOrDefault(x => x.UserName == request.User.Identity.Name);
                    switch (request.Request.FilePath)
                    {
                        case "/Topics/All":
                            context.Stats.FirstOrDefault(x => x.UserId == currentUser.Id).AllTopics++;
                            break;
                        case "/Topics/Add":
                            context.Stats.FirstOrDefault(x => x.UserId == currentUser.Id).AddTopic++;
                            break;
                        case "/Topics/Delete":
                            context.Stats.FirstOrDefault(x => x.UserId == currentUser.Id).DeleteTopic++;
                            break;
                        case "/Comments/Add":
                            context.Stats.FirstOrDefault(x => x.UserId == currentUser.Id).AddComment++;
                            break;
                        case "/Comments/Delete":
                            context.Stats.FirstOrDefault(x => x.UserId == currentUser.Id).DeleteComment++;
                            break;
                        case "/Topics/Today":
                            context.Stats.FirstOrDefault(x => x.UserId == currentUser.Id).TodayTopics++;
                            break;
                    }
                    context.Stats.FirstOrDefault(x => x.UserId == currentUser.Id).Activity++;
                    context.SaveChanges();
                }
            }
        }
    }
}