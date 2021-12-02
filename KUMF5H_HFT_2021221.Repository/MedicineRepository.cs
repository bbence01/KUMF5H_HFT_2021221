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
            if (id == null || id <= 0)
                throw new ArgumentException(nameof(id), "ID must be positive");
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public override void Delete(int id)
        {
            Delete(GetOne(id));
        }

        public override void Update(Medicine updated)
        {
            if (updated.Id == null || updated.Id <= 0)
                throw new ArgumentException("ID must be positive");
            if (updated.ProducerID == null || updated.ProducerID < 1)
                throw new ArgumentException("Producer iD must be positive");
            if (updated.MedicineName == null || updated.MedicineName == "")
                throw new ArgumentException("Must give name");
            if (updated.Heals == null || updated.Heals == "")
                throw new ArgumentException("Must Threat an illness");
            if (updated.BasePrice == null )
                throw new ArgumentException("Must have a price");

            var forUpdadte = GetOne(updated.Id);
            forUpdadte.ProducerID = updated.ProducerID;
            forUpdadte.BasePrice = updated.BasePrice;
            forUpdadte.MedicineName = updated.MedicineName;
            forUpdadte.Heals = updated.Heals;
            ctx.SaveChanges();
        }
    }
}
