using KUMF5H_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Repository
{
    public class Producerrepository : Repository<Producer>, IProducerReposiotory
    {
        public Producerrepository(DbContext ctx) : base(ctx)
        {
        }



        public void ChangeProducerName(int id, string newProducerName)
        {
            var result = GetOne(id);
            if (result == null)
                throw new InvalidOperationException("No producer with this id");
           
                result.ProducerName = newProducerName;
            ctx.SaveChanges();

        }

        public override void Delete(int id)
        {
           /* if (id == null || id <= 0)
                throw new ArgumentException(nameof(id), "ID must be positive");*/
            ctx.Set<Producer>().Remove(GetOne(id));
            ctx.SaveChanges();
        }

        
        public override Producer GetOne(int id)
        {
            if (id == null || id <= 0)
                throw new ArgumentException(nameof(id), "ID must be positive");

            return GetAll().SingleOrDefault(producer => producer.Id == id);
        }


        public override void Update(Producer updated)
        {
            if (updated.Id == null || updated.Id <= 0)
                throw new ArgumentException( "ID must be positive");
            if (updated.ProducerName == null || updated.ProducerName == "")
                throw new ArgumentException("Must give name");

            var forUpdate = GetOne(updated.Id);
            forUpdate.ProducerName = updated.ProducerName;
            forUpdate.Location = updated.Location;
            ctx.SaveChanges();
        }
    }

}
