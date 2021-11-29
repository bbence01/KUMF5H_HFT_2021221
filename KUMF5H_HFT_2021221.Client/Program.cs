﻿using KUMF5H_HFT_2021221.Models;
using ConsoleTools;
using System;
using System.Linq;
using System.Collections.Generic;

namespace KUMF5H_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {


            RestService restService = new RestService("http://localhost:5000");
            ConsoleMenu consoleMenu = new ConsoleMenu();

            //List
            consoleMenu.Add("List all Producers", () => {
                var res = restService.Get<Producer>("/producer");

                foreach (var item in res)
                {
                    Console.WriteLine(new { id = item.Id, name = item.ProducerName });
                }
                Console.ReadLine();
            });

            consoleMenu.Add("List all Medicines", () => {
                var res = restService.Get<Medicine>("/medicine");

                foreach (var item in res)
                {
                    Console.WriteLine(item.MedicineName);
                }
                Console.ReadLine();
            });

            consoleMenu.Add("List all Patients", () => {
                var res = restService.Get<Patient>("/patient");

                foreach (var item in res)
                {
                    Console.WriteLine(item.Illness, item.PatientName);
                }
                Console.ReadLine();
            });

            //GET one 
            consoleMenu.Add("Get one Producer", () => {
                Console.WriteLine("Please give an ID:");
                string id = Console.ReadLine();
                var res = restService.Get<Producer>($"/producer/5?id={id}");

                foreach (var item in res)
                {
                    Console.WriteLine(new { id = item.Id, name = item.ProducerName });
                }



                Console.ReadLine();
            });



            //POST ADD
            consoleMenu.Add("Add a Producer", () => {
                var a = new Producer();
                Console.WriteLine("Please give the Prudcers a PatientName:");
                string name = Console.ReadLine();
                Console.WriteLine("Please give the Prudcers a Location:");
                string loc = Console.ReadLine();
                restService.Post<Producer>(
                    
            new Producer()
                    {
                        ProducerName = name,
                        Location = loc
                        
            },
                    "/producer"
                );
            });

            consoleMenu.Add("Add a Medicine", () => {
                var a = new Producer();
                Console.WriteLine("Please give the Medicine a PatientName:");
                string name = Console.ReadLine();
                Console.WriteLine("Please give the Medicine a Price:");
                string price = Console.ReadLine();
                Console.WriteLine("Please give the Medicine a Producer id:");
                string pID = Console.ReadLine();
                Console.WriteLine("Please give the Medicine an Illnes it heals: " );
                string heals = Console.ReadLine();


                restService.Post<Medicine>(

            new Medicine()
            {
                MedicineName = name,
                BasePrice = int.Parse(price),
                ProducerID = int.Parse(pID),
                Heals = heals

            },
                    "/medicine"
                ); ;
            });

            
            consoleMenu.Add("Add a Patient", () => {
                var a = new Patient();
                Console.WriteLine("Please give the Patient a PatientName:");
                string name = Console.ReadLine();
                Console.WriteLine("Please give the Patient an Illness:");
                string ill = Console.ReadLine();
                Console.WriteLine("Please give the Patient a MedicinID:");
                string pID = Console.ReadLine();
                restService.Post<Patient>(

            new Patient()
            {
                Illness = ill,
                MedicineID = int.Parse(pID),
                PatientName = name

            },
                    "/patient"
                ); ;
            });


            //PUT Update

            consoleMenu.Add("Update a Producer", () => {
                var a = new Producer();
                Console.WriteLine("Please give an ID:");
                string id = Console.ReadLine();
                Console.WriteLine("Please give the Prudcers a Producername:");
                string name = Console.ReadLine();
                Console.WriteLine("Please give the Prudcers a Location:");
                string loc = Console.ReadLine();
                restService.Put<Producer>(

            new Producer()
            {
                Id= int.Parse(id),
                ProducerName = name,
                Location = loc

            },
                    "/producer"
                );
            });

            consoleMenu.Add("Update a Medicine", () => {
                var a = new Producer();
                Console.WriteLine("Please give an ID:");
                string id = Console.ReadLine();
                Console.WriteLine("Please give the Medicine a PatientName:");
                string name = Console.ReadLine();
                Console.WriteLine("Please give the Medicine a Price:");
                string price = Console.ReadLine();
                Console.WriteLine("Please give the Medicine a Producer id:");
                string pID = Console.ReadLine();
                Console.WriteLine("Please give the Medicine an Illnes it heals: ");
                string heals = Console.ReadLine();


                restService.Put<Medicine>(

            new Medicine()
            {
                Id = int.Parse(id),
                MedicineName = name,
                BasePrice = int.Parse(price),
                ProducerID = int.Parse(pID),
                Heals = heals

            },
                    "/medicine"
                ); ;
            });

            consoleMenu.Add("Add a Patient", () => {
                var a = new Patient();
                Console.WriteLine("Please give an ID:");
                string id = Console.ReadLine();
                Console.WriteLine("Please give the Patient a PatientName:");
                string name = Console.ReadLine();
                Console.WriteLine("Please give the Patient an Illness:");
                string ill = Console.ReadLine();
                Console.WriteLine("Please give the Patient a MedicinID:");
                string pID = Console.ReadLine();
                restService.Put<Patient>(

            new Patient()
            {
                Id = int.Parse(id),
                Illness = ill,
                MedicineID = int.Parse(pID),
                PatientName = name

            },
                    "/patient"
                ); ;
            });


            //LINQ

            consoleMenu.Add("Average Medicine Price by producers", () => {
                var res = restService.Get<AverageResult>("/stat/AvarageByProducers");

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            });

            consoleMenu.Add("Medicine average price", () => {
                var res = restService.GetSingle<double>("/stat/averageprice");

                Console.WriteLine($"Avg medicine price={res}");
                Console.ReadLine();
            });

            consoleMenu.Add("Highest Medicine Price by producers", () => {
                var res = restService.Get<HighestResult>("/stat/HighestMedicineByProducer");

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            });

            consoleMenu.Add("Search medication for the patients", () => {
                var res = restService.Get<Threatments>("/stat/GetThreatment");

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            });


            consoleMenu.Add("Search Producers with the same medication healing", () => {
                var res = restService.Get<SameMedicineProducers>("/stat/GetProducerwithsamemedicine");

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            });

            consoleMenu.Add("Search for Covid Cure", () => {
                var res = restService.Get<SameMedicineProducers>("/stat/GetCovidcure");

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            });

            consoleMenu.Add("Search for Medicines produced in Hungary", () => {
                var res = restService.Get<LocationResults>("/stat/GetLocations");

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
                Console.ReadLine();
            });

            consoleMenu.Show();
        }
    }
}
