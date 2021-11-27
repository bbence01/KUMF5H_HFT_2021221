using KUMF5H_HFT_2021221.Models;
using KUMF5H_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Logic
{
    public interface IPatientLogic
    {
        IEnumerable<Patient> GetAll();
        Patient GetOne(int id);
        void ChangePatientName(int id, string newPatientName);
        void Create(Patient newPatient);
        void Update(Patient updated);
        void Delete(Patient forDelete);
        void Delete(int id);

      //  IEnumerable<AverageResult> GetProducerAverages();


    }

}
