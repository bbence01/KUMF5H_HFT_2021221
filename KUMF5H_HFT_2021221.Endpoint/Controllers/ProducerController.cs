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
    public class ProducerController : ControllerBase
    {
        IProducerLogic pl;

        public ProducerController(IProducerLogic pl)
        {
            this.pl = pl;
        }

        // GET: api/<ProducerController>
        [HttpGet]
        public IEnumerable<Producer> Get()
        {
            return pl.GetAll();
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public IEnumerable<Producer> Get(int id)
        {
            return pl.GetOne(id);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public void Post([FromBody] Producer value)
        {
            pl.Create(value);
        }

        // PUT api/<ProducerController>/5
        [HttpPut]
        public void Put([FromBody] Producer value)
        {
            pl.Update(value);
        }

        // DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pl.Delete(id);
        }
    }
}
