using KUMF5H_HFT_2021221.Logic;
using KUMF5H_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using KUMF5H_HFT_2021221.Endpoint.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KUMF5H_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        IMedicineLogic ml;
        IHubContext<SignalRHub> hub;
        public MedicineController(IMedicineLogic ml, IHubContext<SignalRHub> hub)
        {
            this.ml = ml;
            this.hub = hub;

        }

        // GET: /medicine       
        [HttpGet]
        public IEnumerable<Medicine> Get()
        {
            return ml.GetAll();
        }

        // GET /medicine/5
        [HttpGet("{id}")]
        public IEnumerable<Medicine> Get(int id)
        {
            return ml.GetOne(id);
        }

        // POST api/<MedicineController>
        [HttpPost]
        public void Post([FromBody] Medicine value)
        {
            ml.Create(value);
            this.hub.Clients.All.SendAsync("Created", value);

        }

        // PUT api/<MedicineController>/5
        [HttpPut]
        public void Put([FromBody] Medicine value)
        {
            ml.Update(value);
            this.hub.Clients.All.SendAsync("Updated", value);

        }

        // DELETE api/<MedicineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var patientToDelete = this.ml.GetOne(id);

            ml.Delete(id);
            this.hub.Clients.All.SendAsync("Deleted", patientToDelete);
        }

    }
}
