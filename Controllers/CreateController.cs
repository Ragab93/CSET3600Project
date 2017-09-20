using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using NetworkConfigurator.DataManager;
using NetworkConfigurator.Model;
using Microsoft.AspNetCore.Cors;
namespace NetworkConfigurator.Controllers
{
    public class CreateController : Controller
    {
        public PeopleContext _context;
        public CreateController(PeopleContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

       
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult AddHost([FromBody]string name)
        {
            var person = new Person(name, 6969);
            _context.people.Add(person);
            _context.SaveChanges();
            System.Console.WriteLine(name);
            System.Console.WriteLine(person);
            return RedirectToAction("Index");
        }
    }
}