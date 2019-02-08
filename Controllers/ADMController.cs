using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using WebADMs.Hubs;

using WebADMs.Model;
using WebADMs.Services;

namespace WebADMs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmController : ControllerBase
    {
        private Repo _repo;
        public AdmController(Repo repo)
        {
            _repo = repo;
        }
        //private readonly Data _data;
        //public string Data
        //{
        //    get { return _data.data; }
        //}
        //private IHubContext<AdmChanges, IAdmChanges> _hubContext;
        //public AdmController(IHubContext<AdmChanges, IAdmChanges> hc)
        //{
        //    _hubContext = hc;
        //}
        // GET: api/ADM
        [HttpGet]
        public string Get()
        {
            
            return _repo.Read();
        }

        // GET: api/ADM/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "eveHome";
        }

        // POST: api/ADM
        [HttpPost]
        public void Post([FromBody] dynamic eveHome)
        {
            try
            {

                //var serializer = JsonSerializer.Create();
                
                //var eveHome = serializer.Deserialize<EveHome>(data);
                
                if (eveHome.key != "evePower")
                    return;
                string val = eveHome.ToString();
                if (val.Length > 100000)
                    return;
                if (val.IndexOf("5XR-KZ") > 0)
                {
                    _repo.Save(val, eveHome);
                }
            }
            catch
            {
                return;
            }

            //using (StreamWriter outputFile = new StreamWriter(Path.Combine(Startup.root, "adms.json"), true))
            //{
            //    outputFile.Write(eveHome);
            //}
        }

        // PUT: api/ADM/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
