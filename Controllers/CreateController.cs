using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using NetworkConfigurator.DataManager;
using NetworkConfigurator.Model;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;

// create a save button that passes an instance of a network back to index and save the network to a list of networks in index
namespace NetworkConfigurator.Controllers
{
    //handles all /create urls
    public class CreateController : Controller
    {
        //used for post request to add new components
        public PeopleContext _context;
        public Host newHost;
        public Switch newSwitch;
        public static Network newNetwork;


        //constructor to initialize network components 
        public CreateController(PeopleContext context)
        {
            this._context = context;
            this.newHost = new Host();
            this.newSwitch = new Switch();
            CreateController.newNetwork = new Network();
        }

        //  /create or /create/index  returns the view in the views/create folder
        public IActionResult Index()
        {
            return View();
        }

        
       //  /create/addhost 
       // used on post request to add a new host
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult AddHost([FromBody] PostedHost host)
        {


            this.newHost.Name = host.name;
            this.newHost.NetworkAdapters = new List<Adapter> (){
                    new Adapter(host.eth0),
                    new Adapter(host.eth1)
                };
            this.newHost.SwitchID = _context.getSwitchID(host.switchName);

            //CreateController.newNetwork.Hosts.Add(this.newHost);
            _context.hosts.Add(this.newHost);
             _context.SaveChanges();
            // System.Console.WriteLine(newhost.Name + " " + newhost.SwitchID);
            return RedirectToAction("Index");
        }


        // /create/addswitch
        [HttpPost]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult AddSwitch([FromBody]PostedSwitch switch1)
        {
            this.newSwitch.Name = switch1.name;
            this.newSwitch.ports = switch1.ports;
            CreateController.newNetwork.Switchs.Add(this.newSwitch);
            return RedirectToAction("Index");
        }

        [HttpPost("/create/savenetwork")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult SaveNetwork([FromBody]string name)
        {
            CreateController.newNetwork.Name = name;
            _context.Network.Add(CreateController.newNetwork);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}