using KUMF5H_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        protected DbContext ctx;
        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            ctx.Set<T>().Remove(entity);
            ctx.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }
        public abstract T GetOne(int id);
    }

    public class Producerrepository : Repository<Producer>, IProducerReposiotory
    {
        public Producerrepository(DbContext ctx) : base(ctx)
        {
        }

       

        public void ChangeProducerName(int id, string newProducerName)
        {
            var result = GetOne(id);
            if (result == null)
                throw new InvalidOperationException("Not found");
        }

        public override Producer GetOne(int id)
        {
            return GetAll().SingleOrDefault(producer => producer.Id == id);
        }
    }

    public class MedicineRepository : Repository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(DbContext ctx) : base(ctx) { }

        public void ChangePrice(int id, int newPrice)
        {
            var medicine = GetOne(id);
            if (medicine == null) throw new InvalidOperationException("Not found");
            medicine.BasePrice = newPrice;
            ctx.SaveChanges();

        }

        public override Medicine GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id == id);
        }
    }

    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DbContext ctx) : base(ctx)
        {
        }

        public void ChangePatientName(int id, string newBrandName)
        {
            var result = GetOne(id);
            if (result == null)
                throw new InvalidOperationException("Not found");
        }

        public override Patient GetOne(int id)
        {
            return GetAll().SingleOrDefault(patient => patient.Id == id);
        }
    }




}

