﻿using KUMF5H_HFT_2021221.Logic;
using KUMF5H_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KUMF5H_HFT_2021221_Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IMedicineLogic ml;

        public StatController(IMedicineLogic ml)
        {
            this.ml = ml;
        }

        [HttpGet]
        public double AveragePrice()
        {
            return ml.AveragePrice();
        }

        [HttpGet]
        public IEnumerable<AverageResult> AverageByBrands()
        {
            return ml.GetProducerAverages();
        }
    }
}