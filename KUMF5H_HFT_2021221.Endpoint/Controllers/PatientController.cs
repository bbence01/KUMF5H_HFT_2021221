using KUMF5H_HFT_2021221.Logic;
using KUMF5H_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
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
        public PatientController(IPatientLogic pl)
        {
            this.pl = pl;
        }


        // GET: /patient
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return pl.GetAll();
        }

        // GET /patient/5
        [HttpGet("{id}")]
        public Patient Get(int id)
        {
            return pl.GetOne(id);
        }

        // POST api/<PatientController>
        [HttpPost]
        public void Post([FromBody] Patient value)
        {
            pl.Create(value);
        }

        // PUT api/<PatientController>/5
        [HttpPut]
        public void Put([FromBody] Patient value)
        {
            pl.Update(value);
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
    }
}
