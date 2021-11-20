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

        public abstract void Delete(int id);

        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }
        public abstract T GetOne(int id);

       

        public abstract void Update(T updated);
    }

   
   

 




}

