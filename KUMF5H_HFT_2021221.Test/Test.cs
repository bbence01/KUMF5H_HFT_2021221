using System;
using KUMF5H_HFT_2021221.Logic;
using KUMF5H_HFT_2021221.Models;
using KUMF5H_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace KUMF5H_HFT_2021221.Test
{

    class Test
    {



        Mock<IMedicineRepository> mockMedicineRepository = new Mock<IMedicineRepository>();
        Mock<IPatientRepository> mockPatientRepository = new Mock<IPatientRepository>();
        Mock<IProducerReposiotory> mockProducerRepository = new Mock<IProducerReposiotory>();
        MedicineLogic medLogic;
        PatientLogic patientLogic;
        Producerlogic producerLogic;

        public Test()
        {
            medLogic = new MedicineLogic(mockMedicineRepository.Object);
            patientLogic = new PatientLogic(mockPatientRepository.Object);
            producerLogic = new Producerlogic(mockProducerRepository.Object); 

            Medicine xanil = new Medicine() { MedicineName = "Xanil",Heals="Nátha" };
            Medicine covax = new Medicine() { MedicineName = "Covax" , Heals= "Covid"};

            Producer pfizer = new Producer() { ProducerName = "Pfizer", Medicines= new List<Medicine> { xanil,covax } };

           


            mockMedicineRepository.Setup(medRepo => medRepo.Create(It.IsAny<Medicine>()));

            mockMedicineRepository.Setup(medRepo => medRepo.GetAll()).Returns(
                   new List<Medicine>
                   {
                        new Medicine()
                        {
                            MedicineName= "Alpha",
                            Producer=pfizer,
                            BasePrice = 1000,
                            Heals ="Covid"

                        },
                        new Medicine()
                        {
                            MedicineName = "Beta",
                            Producer = pfizer,
                            BasePrice=2000,
                            Heals = "Nátha"
                        }
                   }.AsQueryable()
                );


            
            mockPatientRepository.Setup(patientRepo => patientRepo.Create(It.IsAny<Patient>()));
            mockPatientRepository.Setup(patientRepo => patientRepo.GetAll()).Returns(
                new List<Patient>
                {
                    new Patient()
                    {
                        Illness= "Headache",
                        Medicine = xanil,
                        PatientName = "Bence"


                     },
                    new Patient()
                    {
                        Illness= "Covid",
                        Medicine = covax,
                        PatientName = "Dani"


                    }



                }.AsQueryable()

                );
            mockProducerRepository.Setup(producerRep => producerRep.Create(It.IsAny<Producer>()));
            mockProducerRepository.Setup(producerRep => producerRep.GetAll()).Returns(
                new List<Producer>
                {
                    new Producer(){
                     ProducerName = "Pfizer",
                        Medicines = new List<Medicine> {
                        new Medicine() { MedicineName = "Covax" ,Heals="Covid"},
                        new Medicine() { MedicineName = "Xalin",Heals="Nátha" }
                        }

                },
                    new Producer(){
                     ProducerName = "Béres",
                        Medicines = new List<Medicine> {
                        new Medicine() { MedicineName = "Novirin",Heals="Nátha" },
                        new Medicine() { MedicineName = "Avil",Heals="Nátha" }
                        }

                }



                }.AsQueryable()

                );

        }

        

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void TestCreateValidMedicine(int producerId)
        {
            Assert.That(
                () =>
                {
                    medLogic.Create(new Medicine() { MedicineName = "yes", ProducerID = producerId });
                },
                Throws.Nothing
                );
        }
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void TestCreateInValidMedicine(int producerId)
        {
            Assert.That(
                () =>
                {
                    medLogic.Create(new Medicine() { MedicineName = "no", ProducerID = producerId });
                },
                Throws.Exception
                );
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void TestCreateValidPatient(int medicineId)
        {
            Assert.That(
                () =>
                {
                    patientLogic.Create(new Patient() { Illness = "yes", MedicineID = medicineId , Medicine = new Medicine() { MedicineName = "Covax", Heals = "Covid" }
                });
                },
                Throws.Nothing
                );
        }
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void TestCreateInValidPatient(int medicineId)
        {
            Assert.That(
                () =>
                {
                    patientLogic.Create(new Patient() { Illness = "no", MedicineID = medicineId , Medicine = new Medicine() { MedicineName = "Covax", Heals = "Covid" }
                });
                },
                Throws.Exception
                );
        }


        [TestCase("Xamil")]
        [TestCase("XAMILDHJSAKJSAGHJGDSJH")]
        [TestCase("123weJHKSDJH")]
        public void TestCreateValidProducer(string producerName)
        {
            Medicine xanil = new Medicine() { MedicineName = "Xanil" , Heals = "Nátha" };
            Medicine covax = new Medicine() { MedicineName = "Covax", Heals = "Covid" };

            

            Assert.That(
                () =>
                {
                    producerLogic.Create(new Producer()
                    {
                      ProducerName = producerName,
                      Medicines= new List<Medicine> { xanil, covax }

                    
                    });
                },
                Throws.Nothing
                );
        }

        [TestCase("")]
        
        public void TestCreateInValidProducer(string producername)
        {
            Assert.That(
                () =>
                {
                    producerLogic.Create(new Producer() {  
                        ProducerName = producername, 
                        Medicines = new List<Medicine> {
                        new Medicine() { MedicineName = "Covax",Heals = "Covid" },
                        new Medicine() { MedicineName = "Xalin" ,Heals = "Nátha"}

                } });
                },
                Throws.Exception
                );
        }




        [Test]
        public void TestAverage()
        {
            Producer pfizer = new Producer() { ProducerName = "Pfizer", Id = 1 };
            medLogic.Create(
                        new Medicine()
                        {
                            ProducerID = 1,
                            Producer = pfizer,
                            MedicineName = "Alpha",
                            BasePrice = 1000
                        }
            );
            medLogic.Create(
                        new Medicine()
                        {
                            ProducerID = 1,
                            Producer = pfizer,
                            MedicineName = "Beta",
                            BasePrice = 2000
                        }
            );
            var res = medLogic.GetProducerAverages();
            Assert.That(res, Is.EquivalentTo(
                new List<AverageResult>
                {
                    new AverageResult()
                    {
                        ProducerName="Pfizer",
                        AveragePrice=1500
                    }
                }
                ));



        }

        [Test]
        public void TestMax()
        {
            Producer pfizer = new Producer() { ProducerName = "Pfizer", Id = 1 };
            medLogic.Create(
                        new Medicine()
                        {
                            ProducerID = 1,
                            Producer = pfizer,
                            MedicineName = "Alpha",
                            BasePrice = 1000
                        }
            );
            medLogic.Create(
                        new Medicine()
                        {
                            ProducerID = 1,
                            Producer = pfizer,
                            MedicineName = "Beta",
                            BasePrice = 2000
                        }
            );
            var res = medLogic.GetProducerMax();
            Assert.That(res, Is.EquivalentTo(
                new List<HighestResult>
                {
                    new HighestResult()
                    {
                        ProducerName="Pfizer",
                        HighestPrice=2000
                    }
                }
                ));



        }


        [Test]
        public void TestCovid()
        {
            Producer pfizer = new Producer() { ProducerName = "Pfizer", Id = 1 };
            medLogic.Create(
                        new Medicine()
                        {
                            ProducerID = 1,
                            Producer = pfizer,
                            MedicineName = "Alpha",
                            BasePrice = 1000,
                            Heals ="Covid"
                        }
            );
            medLogic.Create(
                        new Medicine()
                        {
                            ProducerID = 1,
                            Producer = pfizer,
                            MedicineName = "Beta",
                            BasePrice = 2000,
                            Heals = "Nátha"
                        }
            );
            var res = medLogic.GetCovidcure();
            Assert.That(res, Is.EquivalentTo(
                new List<SameMedicineProducers>
                {
                    new SameMedicineProducers()
                    {
                        ProducersName="Pfizer",
                        Illness = "Covid",
                        MedicineName = "Alpha"
                    }
                }
                ));



        }



    }
}


