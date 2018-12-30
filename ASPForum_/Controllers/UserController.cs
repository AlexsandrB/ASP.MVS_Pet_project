using ASPForum_.Models;
using ASPForum_.Models.UsersAdministrationModels;
using ASPForum_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPForum_.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/GetAll
        public ActionResult GetAll()
        {
            List<User> users = new List<User>();
            using (var context = ApplicationDbContext.Create())
            {
                users = context.Users.ToList();
            }

            var usersListViewModel = new UsersListViewModel();

            usersListViewModel.Users = users.Select(x => new UserViewModel()
            {
                About = x.About,
                Name = x.Name
            }).ToList();

            return View(usersListViewModel);
        }

        [HttpPost]
        public ActionResult Add(AddUserModel model)
        {
            if (ModelState.IsValid)
            {
                
                using (ApplicationDbContext context = ApplicationDbContext.Create())
                {
                    context.Users.Add(new User()
                    {
                        About = model.About,
                        Name = model.Name,
                        Deleted = false,
                        Login = model.Login,
                        Password = model.Password
                    });
                    context.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        // Get: Users/Delete/{id}
        [Route("Users/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            string result = "User successfully deleted";
            using (ApplicationDbContext context = ApplicationDbContext.Create())
            {
                var userToDelete = context.Users.FirstOrDefault(x => x.Id == id);
                if (userToDelete == null)
                {
                    userToDelete.Deleted = true;
                }
                else
                {
                    result = "Something goes wrong";
                }
                context.SaveChanges();
            }
            return Content(result);
        }
    }
}