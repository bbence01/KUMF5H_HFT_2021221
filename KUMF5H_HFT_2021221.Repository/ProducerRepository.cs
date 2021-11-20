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
                throw new InvalidOperationException("Not found");
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Producer GetOne(int id)
        {
            return GetAll().SingleOrDefault(producer => producer.Id == id);
        }

        public override void Update(Producer updated)
        {
            throw new NotImplementedException();
        }
    }

}
