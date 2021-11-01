using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KUMF5H_HFT_2021221.Models;

namespace KUMF5H_HFT_2021221.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id); //Read
        IQueryable<T> GetAll(); //Read
        void Delete(T entity);
        void Create(T entity);
        // !! NO !! Update
    }

    public interface IProducerReposiotory : IRepository<Producer>
    {
        void ChangeProducerName(int id, string newProducerName);
    }

    public interface IMedicineRepository : IRepository<Medicine>
    {
        //update
        void ChangePrice(int id, int newPrice);
    }

    public interface IPatientRepository : IRepository<Patient>
    {
        void ChangePatientName(int id, string newPatientName);
    }


}
