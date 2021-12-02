using KUMF5H_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DbContext ctx) : base(ctx)
        {
        }

        public void ChangePatientName(int id, string newPatientName)
        {
            var result = GetOne(id);
            if (result == null)
                throw new InvalidOperationException("Not found");
            result.PatientName = newPatientName;
        }

        public override void Delete(int id)
        {
            Delete(GetOne(id));
        }

        public override Patient GetOne(int id)
        {
            if (id == null || id <= 0)
                throw new ArgumentException(nameof(id), "ID must be positive");

            return GetAll().SingleOrDefault(patient => patient.Id == id);
        }

        public override void Update(Patient updated)
        {
            if (updated.Id == null || updated.Id <1)
                throw new ArgumentException("ID must be positive");
            if (updated.MedicineID == null || updated.MedicineID < 1)
                throw new ArgumentException("Medicine ID must be positive");
            if (updated.PatientName == null || updated.PatientName == "")
                throw new ArgumentException("Must give name");
            if (updated.Illness == null || updated.Illness == "")
                throw new ArgumentException("Must Have an illness");


            var forUpdate = GetOne(updated.Id);
            forUpdate.Illness = updated.Illness;
            forUpdate.MedicineID = updated.MedicineID;
            forUpdate.PatientName = updated.PatientName;
            ctx.SaveChanges();
        }
    }
}
