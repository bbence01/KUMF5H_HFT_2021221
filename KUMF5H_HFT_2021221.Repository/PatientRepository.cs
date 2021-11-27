﻿using KUMF5H_HFT_2021221.Models;
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
        }

        public override void Delete(int id)
        {
            Delete(GetOne(id));
        }

        public override Patient GetOne(int id)
        {
            return GetAll().SingleOrDefault(patient => patient.Id == id);
        }

        public override void Update(Patient updated)
        {
            var forUpdate = GetOne(updated.Id);
            forUpdate.Illness = updated.Illness;
            forUpdate.MedicineID = updated.MedicineID;
            forUpdate.PatientName = updated.PatientName;
            ctx.SaveChanges();
        }
    }
}
