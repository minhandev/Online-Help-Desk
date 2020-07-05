using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [Route("Index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            string hash = BCrypt.Net.BCrypt.HashPassword("123", BCrypt.Net.BCrypt.GenerateSalt());
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string username, string password)
        {

            return View();
        }
    }
}
