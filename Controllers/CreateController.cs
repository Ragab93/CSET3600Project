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
using Newtonsoft.Json;

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
        public Network newNetwork;
       // public int NetworkID = 1;
        public static bool NetworkCreated = false;
       static string   NetworkName; 
        //constructor to initialize network components 
        public CreateController(PeopleContext context)
        {
            
            this._context = context;
            //this.newHost = new Host();
            //this.newSwitch = new Switch();
            //this.newNetwork = new Network();
            //SaveNetwork(_context, newNetwork);
        }
       
        //  /create or /create/index  returns the view in the views/create folder
        public IActionResult Index()
        {
            return View(NetworkCreated);
        }
        [HttpPost("Create/AddNetwork")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult AddNetwork([FromBody]string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
               
                NetworkName = name; 
                this.newNetwork = new Network();
                this.newNetwork.Name = name;
              
                SaveNetwork(_context, this.newNetwork);
                
            }

            return RedirectToAction("Index", NetworkCreated);
        }
        public void SaveNetwork(PeopleContext context, Network network)
        {
            context.Network.Add(network);
            context.SaveChanges();
        }


        //  /create/addhost 
        // used on post request to add a new host
        [HttpPost("Create/AddNewHost")]
        [EnableCors("AllowSpecificOrigin")]
        public IActionResult AddNewHost([FromBody]PostedHost host)
        {
          
            this.newHost = new Host();
           this.newHost.Name = host.name;
          this.newHost.Adapter = host.eth0;
            newHost.SwitchID = _context.getSwitchID(host.switchName) ;
             this.newHost.NetworkID = _context.getNetworkId(NetworkName);

            SaveHost(_context, this.newHost);


            return RedirectToAction("Index");
        }
        public void SaveHost(PeopleContext context, Host host)
        {
            context.Hosts.Add(host);
            context.SaveChanges();
        }


        // /create/addswitch
        [HttpPost("Create/AddNewSwitch")]
         [EnableCors("AllowSpecificOrigin")]
        public IActionResult AddNewSwitch([FromBody] PostedSwitch switch1)
        {
            this.newSwitch = new Switch();
            this.newSwitch.Name = switch1.name;
            this.newSwitch.Adapter = switch1.eth0;
            this.newSwitch.ports = switch1.ports;
            this.newSwitch.NetworkID = _context.getNetworkId(NetworkName);

            SaveSwitch(_context, this.newSwitch); 

            return RedirectToAction("Index");
        }


        public void SaveSwitch(PeopleContext context, Switch switch1)
        {
            context.Switchs.Add(switch1);
            context.SaveChanges();
        }

    }
}