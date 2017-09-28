using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NetworkConfigurator.Controllers
{
    public class SavedController : Controller
    {

        // /saved or /saved/index
        public IActionResult Index()
        {
            return View();
        }
    }
}