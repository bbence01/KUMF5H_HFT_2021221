using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.FrontendWPF.Sevice
{
     public class PatientService : RestService
    {
        public PatientService(string baseurl) : base(baseurl, "patients")
        {




        }
    }

    public class MedicineService : RestService
    {
        public MedicineService(string baseurl) : base(baseurl, "medicines")
        {
        }
    }

    public class ProducerService : RestService
    {
        public ProducerService(string baseurl) : base(baseurl, "producers")
        {
        }
    }
}
