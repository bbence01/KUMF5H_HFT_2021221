using KUMF5H_HFT_2021221.Models;
using KUMF5H_HFT_2021221.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KUMF5H_HFT_2021221.Logic
{
  
    public class PatientLogic : IPatientLogic
    {
        IPatientRepository patientRepository;

        public PatientLogic(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public void ChangePatientName(int id, string newPatientName)
        {
            patientRepository.ChangePatientName(id, newPatientName);
        }

        public void Create(Patient newPatient)
        {
            patientRepository.Create(newPatient);

            if (newPatient.MedicineID < 1)
                throw new ArgumentException(nameof(newPatient), "Medicine id must be positive");
            patientRepository.Create(newPatient);
        }

        public void Delete(int id)
        {
            patientRepository.Delete(id);
        }

        public void Delete(Patient forDelete)
        {
            patientRepository.Delete(forDelete);
        }

        public IList<Patient> GetAll()
        {
            return patientRepository.GetAll().ToList();
        }

        public Patient GetOne(int id)
        {
            return patientRepository.GetOne(id);
        }

        public void Update(Patient value)
        {
            patientRepository.Update(value);
        }
    }
}
