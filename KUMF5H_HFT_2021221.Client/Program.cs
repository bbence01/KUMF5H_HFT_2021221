using KUMF5H_HFT_2021221.Models;
using ConsoleTools;
using System;
using System.Linq;

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
                    Console.WriteLine(new { id = item.Id, name = item.Name });
                }
                Console.ReadLine();
            });

            consoleMenu.Add("List all Medicines", () => {
                var res = restService.Get<Medicine>("/medicine");

                foreach (var item in res)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            });

            consoleMenu.Add("List all Patients", () => {
                var res = restService.Get<Patient>("/patient");

                foreach (var item in res)
                {
                    Console.WriteLine(item.Illness);
                }
                Console.ReadLine();
            });


            //ADD
            consoleMenu.Add("Add a Producer", () => {
                var a = new Producer();
                Console.WriteLine("Please give the Prudcers a Name:");
                string name = Console.ReadLine();
                restService.Post<Producer>(
                    
            new Producer()
                    {
                        Name = name
            },
                    "/producer"
                );
            });

            consoleMenu.Add("Add a Medicine", () => {
                var a = new Producer();
                Console.WriteLine("Please give the Medicine a Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Please give the Medicine a Price:");
                string price = Console.ReadLine();
                Console.WriteLine("Please give the Medicine a Producer id:");
                string pID = Console.ReadLine();
                restService.Post<Medicine>(

            new Medicine()
            {
                Name = name,
                BasePrice = int.Parse(price),
                ProducerID = int.Parse(pID)

            },
                    "/medicine"
                );
            });

            
            consoleMenu.Add("Add a Patient", () => {
               /* var a = new Patient();
                Console.WriteLine("Please give the Patient an Illness:");
                string name = Console.ReadLine();
                Console.WriteLine("Please give the Patient a MedicinID:");
                string pID = Console.ReadLine();
                restService.Post<Patient>(

            new Patient()
            {
                Illness = name,
                MedicineID = int.Parse(pID)
            },
                    "/patient"
                );*/
            });
            



            consoleMenu.Add("Average Medicine Price by producers", () => {
                var res = restService.Get<AverageResult>("/stat/AvarageByProducers");

                foreach (var item in res)
                {
                    Console.WriteLine(item);
                }
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

            consoleMenu.Add("Medicine average price", () => {
                var res = restService.GetSingle<double>("/stat/averageprice");

                Console.WriteLine($"Avg medicine price={res}");
                Console.ReadLine();
            });

            consoleMenu.Show();
        }
    }
}
