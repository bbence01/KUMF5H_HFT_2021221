using KUMF5H_HFT_2021221.Models;
using KUMF5H_HFT_2021221.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KUMF5H_HFT_2021221.Logic
{  


        public class AverageResult
        {
            public string ProducerName { get; set; }
            public double AveragePrice { get; set; }

            public override bool Equals(object obj)
            {
                if (obj is AverageResult)
                {
                    var other = obj as AverageResult;
                    return this.AveragePrice == other.AveragePrice && this.ProducerName == other.ProducerName; // close
                }
                else
                {
                    return false;
                }
            }

            public override int GetHashCode()
            {
                return this.ProducerName.GetHashCode() + (int)this.AveragePrice;
            }

            public override string ToString()
            {
                return $"MedicineName={ProducerName}, AveragePrice={AveragePrice}";
            }
        }


       

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

            public IList<Medicine> GetAll()
            {
                return medicineRepo.GetAll().ToList();
            }

        /*
            public IList<AverageResult> GetProducerAverages()
            {
                var q = from medicine in medicineRepo.GetAll()
                        group medicine by new { medicine.ProducerID, medicine.Name } into g
                        select new AverageResult()
                        {
                            ProducerName = g.Key.Name,
                            AveragePrice = g.Average(x => x.BasePrice) ?? 0
                        };
                return q.ToList();
            }
        /*/
        public IEnumerable<AverageResult> GetProducerAverages()
        {
            var q = from medicine in medicineRepo.GetAll()
                    group medicine by new { medicine.ProducerID, medicine.Producer.Name } into g
                    select new AverageResult()
                    {
                        ProducerName = g.Key.Name,
                        AveragePrice = g.Average(x => x.BasePrice) ?? 0
                    };
            return q.ToList().AsEnumerable();
        }

        public Medicine GetOne(int id)
            {
                return medicineRepo.GetOne(id);
            }

        public void Update(Medicine updated)
        {
            medicineRepo.Update(updated);
        }

    }

  

}

