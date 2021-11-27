using KUMF5H_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Repository
{
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

        public override void Delete(int id)
        {
            Delete(GetOne(id));
        }

        public override void Update(Medicine updated)
        {
            var forUpdadte = GetOne(updated.Id);
            forUpdadte.ProducerID = updated.ProducerID;
            forUpdadte.BasePrice = updated.BasePrice;
            forUpdadte.MedicineName = updated.MedicineName;
            forUpdadte.Heals = updated.Heals;
            ctx.SaveChanges();
        }
    }
}
