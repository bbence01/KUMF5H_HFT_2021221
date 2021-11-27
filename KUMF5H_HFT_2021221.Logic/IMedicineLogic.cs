using KUMF5H_HFT_2021221.Models;
using KUMF5H_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Logic
{
    public interface IMedicineLogic 
    {
        Medicine GetOne(int id);
        IList<Medicine> GetAll();
        void ChangePrice(int id, int newPrice);
      

        IEnumerable<AverageResult> GetProducerAverages();

        double AveragePrice();

        void Create(Medicine newCar);
        void Update(Medicine updated);
        void Delete(Medicine forDelete);
        void Delete(int id);
    }
}
