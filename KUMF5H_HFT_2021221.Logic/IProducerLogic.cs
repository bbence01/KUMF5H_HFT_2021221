using KUMF5H_HFT_2021221.Models;
using KUMF5H_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Logic
{
    public interface IProducerLogic
    {
        IEnumerable<Producer> GetAll();
        IEnumerable<Producer> GetOne(int id);
        void ChangeProducerName(int id, string newProducerName);

        void Create(Producer newProducer);
        void Update(Producer updated);
        void Delete(Producer forDelete);
        void Delete(int id);

    }
}
