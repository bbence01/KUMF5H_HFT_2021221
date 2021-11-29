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
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IMedicineLogic medl;
        IPatientLogic patl;
        IProducerLogic prdl;


        public StatController(IMedicineLogic ml, IPatientLogic patl, IProducerLogic prdl)
        {
            this.medl = ml;
            this.patl = patl;
            this.prdl = prdl;
        }

        [HttpGet]
        public double AveragePrice()
        {
            return medl.AveragePrice();
        }

        [HttpGet]
        public IEnumerable<AverageResult> AvarageByProducers()
        {
            return medl.GetProducerAverages();
        }

        [HttpGet]
        public IEnumerable<HighestResult> HighestMedicineByProducer()
        {
            return medl.GetProducerMax();
        }

        [HttpGet]
        public IEnumerable<Threatments> GetThreatment()
        {
            return patl.GetThreatment();
        }

        [HttpGet]
        public IEnumerable<SameMedicineProducers> GetProducerwithsamemedicine()
        {
            return medl.GetProducerwithsamemedicine();
        }

        [HttpGet]
        public IEnumerable<SameMedicineProducers> GetCovidcure()
        {
            return medl.GetCovidcure();
        }


        [HttpGet]
        public IEnumerable<LocationResults> GetLocations()
        {
            return medl.GetLocations();
        }


    }
}
