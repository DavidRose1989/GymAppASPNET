using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Http.Headers;
using Testing.Models;

namespace Testing.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository repo;

        public UsersController(IUsersRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var users = repo.GetAllUsers();
            return View(users);
        }

        public IActionResult ViewUsers(int id)
        {
            var users = repo.GetUsers(id);
            return View(users);
        }

        public IActionResult UpdateUsers(int id)
        {
            Users use = repo.GetUsers(id);
            if (use == null)
            {
                return View("UserNotFound");
            }
            return View(use);
        }

        public IActionResult UpdateUsersToDatabase(Users users)
        {
            repo.UpdateUsers(users);

            return RedirectToAction("ViewUsers", new { id = users.MID });
        }

        public IActionResult InsertUsers()
        {
            var user = new Users();
            return View(user); 
        }

        public IActionResult InsertUsersToDatabase(Users UserstoInsert)
        {
            repo.InsertUsers(UserstoInsert);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteUsers(Users users)
        {
            repo.DeleteUsers(users);

            return RedirectToAction("Index");

        }
    }
}
