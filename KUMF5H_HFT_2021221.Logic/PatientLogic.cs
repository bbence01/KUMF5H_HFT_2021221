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
          //  patientRepository.Create(newPatient);

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

        public IEnumerable<Patient> GetAll()
        {
            return patientRepository.GetAll().ToList();
        }

        /*
        public Patient GetOne(int id)
        {
            return patientRepository.GetOne(id);
        }*/

        public IEnumerable<Patient> GetOne(int id)
        {
            if (id == null || id <1)
                throw new ArgumentException(nameof(id), "ID must be positive");

            List<Patient> pr = new List<Patient>();
            pr.Add(patientRepository.GetOne(id));
            return pr;
        }

        public void Update(Patient value)
        {
            patientRepository.Update(value);
        }

       

        /*
        public IEnumerable<Threatments> GetThreatment()
        {


            var q = from patients in patientRepository.GetAll()
                   
                    where  patients.Medicine.Heals == patients.Illness 
                    select new Threatments()
                    {
                        PatientName = patients.PatientName,
                        Illness = patients.Illness,
                        MedicineName = patients.Medicine.MedicineName
                    };

            return q;


        
        }*/

        public IEnumerable<Threatments> GetThreatment()
        {


            var q = from patients in patientRepository.GetAll()
                    group patients by new { patients.Illness, patients.Medicine.Heals, patients.PatientName, patients.Medicine.MedicineName} into g
                    where  g.Key.Heals ==  g.Key.Illness
                    select new Threatments()
                    {
                        PatientName = g.Key.PatientName,
                        Illness = g.Key.Illness,
                        MedicineName = g.Key.MedicineName
                    };

            return q;



        }

    }
}
