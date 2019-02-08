using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebADMs.Model;
using WebADMs.Services;

namespace WebADMs.Hubs
{

    //  [HubName("admchanges")]
    public class AdmChanges : Hub
    {
        private Repo _repo;
        public AdmChanges(Repo repo)
        {
            _repo = repo;
        }
        public void AddAdm( string name, int system)
        {
            Clients.All.SendAsync("AddAdm", name, system);
            var repo = _repo;
            
            var eveHome = repo.ReadDy();
            for (int i = 0; i < eveHome.eveSystem.Count; i++)
            {
                if (eveHome.eveSystem[i].id == system)
                {
                    eveHome.eveSystem[i].adms.Add(new Adm { id = 1, name = name });
                }
            }
            repo.Save( eveHome.ToString(), eveHome);
        }
        public void RemoveAdm(string name, int system)
        {
            Clients.All.SendAsync("RemoveAdm", name, system);
            var repo = _repo;
            var eveHome = repo.ReadDy();
            for (int i = 0; i < eveHome.eveSystem.Count; i++)
            {
                if (eveHome.eveSystem[i].id == system)
                {
                    for (int ii = 0; ii < eveHome.eveSystem[i].adms.Count; ii++)
                    {
                        var adms = eveHome.eveSystem[i].adms as List<Adm>;
                        var adm = adms.FirstOrDefault(n => n.name == name);
                        adms.Remove(adm);
                    }
                    eveHome.eveSystem[i].adms.Add(new Adm { id = 1, name = name });
                }
            }
            repo.Save(eveHome.ToString(), eveHome); 

        }

    }
}
