﻿using KUMF5H_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KUMF5H_HFT_2021221.Data
{
   public class MedDbContext: DbContext
    {
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MedDb.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>(entity =>
            {
                entity
                .HasOne(medicine => medicine.Producer)                
                .WithMany(producer => producer.Medicines)                
                .HasForeignKey(medicine => medicine.ProducerID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity
                .HasOne(patient => patient.Medicine)
                .WithMany(medicine => medicine.Patients)
                .HasForeignKey(patient => patient.MedicineID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });


            /*
            List<string> a = new List<string>() { "Nátha", "Fejfájás", "Láz" };
            List<string> b =  new List<string>() { "Fejfájás", "Görcs" };
            List<string> c = new List<string>() { "Nátha", "Fejfájás", "Láz" };
            List<string> d = new List<string>() { "Influenza", "Fejfájás", "Láz" };
            List<string> e = new List<string>() { "Covid" };
            List<string> f = new List<string>() { "Álmatlanság", "Depresszió", "Fáradékonyság" };
            */

            // "The primary key value needs to be specified even if it's usually generated by the database. It will be used to detect data changes between migrations"
            Producer richter = new Producer() { Id = 1, ProducerName = "Richter" , Location= "Hungary" };
            Producer pfizer = new Producer() { Id = 2, ProducerName = "Pfizer" , Location="USA"};
            Producer beres = new Producer() { Id = 3, ProducerName = "Béres" ,Location= "Hungary"};


            Medicine richter1 = new Medicine() { Id = 1, ProducerID = richter.Id, BasePrice = 3000,  MedicineName= "Zilola" , Heals = "Nátha" };
            Medicine richter2 = new Medicine() { Id = 2, ProducerID = richter.Id, BasePrice = 3000, MedicineName = "Daedalon" , Heals = "Görcs" };
            Medicine richter3 = new Medicine() { Id = 3, ProducerID = richter.Id, BasePrice = 8000, MedicineName = "Dipankrin" , Heals = "Covid" };
            Medicine richter4 = new Medicine() { Id = 4, ProducerID = richter.Id, BasePrice = 9000, MedicineName = "Flamborin", Heals = "Depresszió" };
            Medicine richter5 = new Medicine() { Id = 5, ProducerID = richter.Id, BasePrice = 5000, MedicineName = "Namas", Heals = "Nátha" };

            Medicine pfizer1 = new Medicine() { Id = 6, ProducerID = pfizer.Id, BasePrice = 10000, MedicineName = "ACCUPRIL" , Heals = "Nátha" };
            Medicine pfizer2 = new Medicine() { Id = 7, ProducerID = pfizer.Id, BasePrice = 15000, MedicineName = "ELELYSO", Heals = "Covid" };
            Medicine pfizer3 = new Medicine() { Id = 8, ProducerID = pfizer.Id, BasePrice = 6500, MedicineName = "MANNITOL", Heals = "Görcs" };

            Medicine beres1 = new Medicine() { Id = 9, ProducerID = beres.Id, BasePrice = 6000, MedicineName = " Actival Max" , Heals = "Izületi_fájdalom" };
            Medicine beres2 = new Medicine() { Id = 10, ProducerID = beres.Id, BasePrice = 4500, MedicineName = "Antifront" , Heals = "Álmatlanság" };


            Patient bence = new Patient() { Id = 1, MedicineID = richter1.Id, Illness = "Nátha" , PatientName="Bence" };
            Patient dani = new Patient() { Id = 2, MedicineID = pfizer2.Id, Illness = "Covid" ,PatientName="Dani"};
            Patient krisztian = new Patient() { Id = 3, MedicineID = beres1.Id, Illness = "Izületi_fájdalom",PatientName="Krisztián" };





            modelBuilder.Entity<Producer>().HasData(richter, pfizer, beres);
            modelBuilder.Entity<Medicine>().HasData(richter1, richter2, richter3, richter4, pfizer1, pfizer2, pfizer3, beres1, beres2);
            modelBuilder.Entity<Patient>().HasData(bence, dani, krisztian);
        }

        public MedDbContext()
        {

            this.Database.EnsureCreated();

        }

    }
}
