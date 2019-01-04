using ASPForum_.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ASPForum_.Utils
{
    public class StatsModule : IHttpHandler 
    {
        private ApplicationDbContext DbContext;

        public bool IsReusable => throw new NotImplementedException();
        
        public void ProcessRequest(HttpContext context)
        {
            using (var dbContext = ApplicationDbContext.Create())
            {
                
            }
        }
    }
}