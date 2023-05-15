using KUMF5H_HFT_2021221.Endpoint.Services;
using KUMF5H_HFT_2021221.Logic;
using KUMF5H_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KUMF5H_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientLogic pl;
        IHubContext<SignalRHub> hub;

        public PatientController(IPatientLogic pl, IHubContext<SignalRHub> hub)
        {
            this.pl = pl;
            this.hub = hub;
        }


        // GET: /patient
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return pl.GetAll();
        }

        // GET /patient/5
        [HttpGet("{id}")]
        public IEnumerable<Patient> Get(int id)
        {
            return pl.GetOne(id);
        }

        // POST api/<PatientController>
        [HttpPost]
        public void Post([FromBody] Patient value)
        {
            pl.Create(value);
            this.hub.Clients.All.SendAsync("Created", value);

        }

        // PUT api/<PatientController>/5
        [HttpPut]
        public void Put([FromBody] Patient value)
        {
            pl.Update(value);
          this.hub.Clients.All.SendAsync("Updated", value);

        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var patientToDelete = this.pl.GetOne(id);

            pl.Delete(id);
            this.hub.Clients.All.SendAsync("Deleted", patientToDelete);

        }
    }
}
