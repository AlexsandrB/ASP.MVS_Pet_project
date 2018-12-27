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
    }
}