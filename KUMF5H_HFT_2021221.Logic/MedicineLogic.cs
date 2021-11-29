using KUMF5H_HFT_2021221.Models;
using KUMF5H_HFT_2021221.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KUMF5H_HFT_2021221.Logic
{  


              

        public class MedicineLogic : IMedicineLogic
        {
            IMedicineRepository medicineRepo;

            public void Delete(Medicine forDelete)
            {
                medicineRepo.Delete(forDelete);
            }


        public void Delete(int id)
        {
            medicineRepo.Delete(id);
        }

        public void Create(Medicine newMedicine)
            {
                if (newMedicine.ProducerID < 1)
                    throw new ArgumentException(nameof(newMedicine), "Producer id must be positive");
                medicineRepo.Create(newMedicine);
            }

            public MedicineLogic(IMedicineRepository medicineRepo)
            {
                this.medicineRepo = medicineRepo;
            }

            public void ChangePrice(int id, int newPrice)
            {
                medicineRepo.ChangePrice(id, newPrice);
            }

            public IEnumerable<Medicine> GetAll()
            {
                return medicineRepo.GetAll().ToList();
            }

       
        public Medicine GetOne(int id)
            {
                return medicineRepo.GetOne(id);
            }

        public void Update(Medicine updated)
        {
            medicineRepo.Update(updated);
        }

        /*
           public IList<AverageResult> GetProducerAverages()
           {
               var q = from medicine in medicineRepo.GetAll()
                       group medicine by new { medicine.ProducerID, medicine.PatientName } into g
                       select new AverageResult()
                       {
                           ProducerName = g.Key.PatientName,
                           AveragePrice = g.Average(x => x.BasePrice) ?? 0
                       };
               return q.ToList();
           }
       /*/
        public IEnumerable<AverageResult> GetProducerAverages()
        {
            var q = from medicine in medicineRepo.GetAll()
                    group medicine by new { medicine.ProducerID, medicine.Producer.ProducerName } into g
                    select new AverageResult()
                    {
                        ProducerName = g.Key.ProducerName,
                        AveragePrice = g.Average(x => x.BasePrice) ?? 0
                    };
            return q;
        }




        public double AveragePrice()
        {
            return (double)medicineRepo.GetAll().Average(x => x.BasePrice);
        }


        public IEnumerable<HighestResult> GetProducerMax()
        {

            
            var q = from medicine in medicineRepo.GetAll()
                    group medicine by new { medicine.ProducerID, medicine.Producer.ProducerName } into g
                    select new HighestResult()
                    {
                        ProducerName = g.Key.ProducerName,
                        HighestPrice = g.Max(x => x.BasePrice) ?? 0
                    };
            return q;
           


        }
        
        public IEnumerable<SameMedicineProducers> GetProducerwithsamemedicine()
        {


            var q = from medicine in medicineRepo.GetAll()
                    group medicine by new {medicine.Heals, medicine.Producer.ProducerName, medicine.MedicineName} into g
                    ///where g.Count() > 0
                    select new SameMedicineProducers()
                    {
                        Illness = g.Key.Heals,
                        ProducersName = g.Key.ProducerName,
                        MedicineName = g.Key.MedicineName
                        
                        
                    };
            return q;



        }

        public IEnumerable<SameMedicineProducers> GetCovidcure()
        {


            var q = from medicine in medicineRepo.GetAll()
                    group medicine by new { medicine.Heals, medicine.MedicineName, medicine.Producer.ProducerName } into g
                    where g.Key.Heals == "Covid"
                    select new SameMedicineProducers()
                    {
                        Illness = g.Key.Heals,
                        ProducersName = g.Key.ProducerName,
                        MedicineName = g.Key.MedicineName


                    };
            return q;



        }




        public IEnumerable<SameMedicineProducers> GetHUNgary()
        {


            var q = from medicine in medicineRepo.GetAll()
                    group medicine by new { medicine.Producer.Location, medicine.MedicineName, medicine.Producer.ProducerName } into g
                    where g.Key.Location == "Hungary"
                    select new SameMedicineProducers()
                    {
                        ProducersName = g.Key.ProducerName,
                        MedicineName = g.Key.MedicineName


                    };
            return q;



        }



    }



}

