using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetworkConfigurator.DataManager;
using NetworkConfigurator.Model;

namespace NetworkConfigurator.Controllers
{
    public class SavedController : Controller
    {
        PeopleContext context;
       // SavedDataManager savedData;
        public SavedController(PeopleContext _context)
        {
            this.context = _context;
           // savedData = new SavedDataManager(this.context);
        }

        
       private async Task<int> GetNumNetworks()
        { 
            var num = from n in this.context.Network
                      select n;
            return num.Count(); 
        }
        private async Task<SavedViewModel> GetNetwork(int id)
        {
            int ID =  this.context.Network.Where(x => x.ID == id).Select(x => x.ID).First();
            //int ID = network.ID;
            string name = this.context.Network.Where(x => x.ID == id).Select(x => x.Name).First();
            var hosts =this.context.Hosts.Where(x => x.NetworkID == ID).Select(x => x).ToList();
            var switchs = this.context.Switchs.Where(x => x.NetworkID == ID).Select(x => x).ToList();
            var svm = new SavedViewModel()
            {
                Network = new Network() { ID = ID, Name = name },
                Hosts = hosts,
                Switchs = switchs,
            };
            return svm; 
        }
        public async Task<List<SavedViewModel>> GetAllNetworks()
        {
            List<SavedViewModel> svm = new List<SavedViewModel>() ;
            for(int i = 27; i <  await GetNumNetworks() + 27; i++)
            {
                SavedViewModel viewModel = await GetNetwork(i);
                svm.Add(viewModel);
            }
            return svm;
        }

        // /saved or /saved/index
        public async Task<IActionResult> Index()
        {
           IList<SavedViewModel> networks = await GetAllNetworks();
           
            return View(networks);
        }

        public async Task<IActionResult> Detail(int id)
        {
            SavedViewModel network =await GetNetwork(id);

            return View("Detail", network);
        }
    }
}