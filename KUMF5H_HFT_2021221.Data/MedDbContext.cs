﻿using KUMF5H_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KUMF5H_HFT_2021221.Data
{
    class MedDbContext: DbContext
    {
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }

        public MedDbContext()
        {
            // this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarDb.mdf;Integrated Security=True;MultipleActiveResultSets=True");
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

           

            // "The primary key value needs to be specified even if it's usually generated by the database. It will be used to detect data changes between migrations"
            Producer bmw = new Producer() { Id = 1, Name = "BMW" };
            Producer citroen = new Producer() { Id = 2, Name = "Citroen" };
            Producer audi = new Producer() { Id = 3, Name = "Audi" };

            Medicine bmw1 = new Medicine() { Id = 1, ProducerID = bmw.Id, BasePrice = 20000,  Name= "BMW 116d" };
            Medicine bmw2 = new Medicine() { Id = 2, ProducerID = bmw.Id, BasePrice = 30000, Name = "BMW 510" };
            Medicine bmw3 = new Medicine() { Id = 3, ProducerID = bmw.Id, BasePrice = 800000, Name = "BMW X7 (G07)" };
            Medicine bmw4 = new Medicine() { Id = 4, ProducerID = bmw.Id, BasePrice = 900000, Name = "BMW 3/15" };
            Medicine citroen1 = new Medicine() { Id = 5, ProducerID = citroen.Id, BasePrice = 10000, Name = "Citroen C1" };
            Medicine citroen2 = new Medicine() { Id = 6, ProducerID = citroen.Id, BasePrice = 15000, Name = "Citroen C3" };
            Medicine citroen3 = new Medicine() { Id = 7, ProducerID = citroen.Id, BasePrice = 65000, Name = "Citroen DS" };
            Medicine audi1 = new Medicine() { Id = 8, ProducerID = audi.Id, BasePrice = 20000, Name = "Audi A3" };
            Medicine audi2 = new Medicine() { Id = 9, ProducerID = audi.Id, BasePrice = 25000, Name = "Audi A4" };

          //  Patient bence = new Patient() { Id = 1, MedicineID = bence.Id, Illness = "Nátha" };

            

            modelBuilder.Entity<Producer>().HasData(bmw, citroen, audi);
            modelBuilder.Entity<Medicine>().HasData(bmw1, bmw2, bmw3, bmw4, citroen1, citroen2, citroen3, audi1, audi2);
          //  modelBuilder.Entity<Patient>().HasData(bence);
        }

    }
}
