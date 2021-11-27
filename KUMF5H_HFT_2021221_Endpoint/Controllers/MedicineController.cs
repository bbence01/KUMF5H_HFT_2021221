using KUMF5H_HFT_2021221.Logic;
using KUMF5H_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KUMF5H_HFT_2021221_Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        IMedicineLogic ml;
        public MedicineController(IMedicineLogic ml)
        {
            this.ml = ml;
        }

        // GET: /Medicine       
        [HttpGet]
        public IEnumerable<Medicine> Get()
        {
            return ml.GetAll();
        }

        // GET /Medicine/5
        [HttpGet("{id}")]
        public Medicine Get(int id)
        {
            return ml.GetOne(id);
        }

        // POST api/<MedicineController>
        [HttpPost]
        public void Post([FromBody] Medicine value)
        {
            ml.Create(value);
        }

        // PUT api/<MedicineController>/5
        [HttpPut]
        public void Put([FromBody] Medicine value)
        {
            ml.Update(value);
        }

        // DELETE api/<MedicineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ml.Delete(id);
        }

    }
}
