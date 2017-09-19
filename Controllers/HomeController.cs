using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkConfigurator.Model;
namespace NetworkConfigurator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Person person = new Person()
            {
                Age = 29,
                Name = "Matt"
            };
            return View("Index", person);
        }
    }
}