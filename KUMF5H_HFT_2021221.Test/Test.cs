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

            Medicine xanil = new Medicine() { Id = 1, MedicineName = "Xanil", Heals = "Nátha", BasePrice=2000,ProducerID=1 };
            Medicine covax = new Medicine() { Id = 2, MedicineName = "Covax", Heals = "Covid" , BasePrice = 5000, ProducerID = 1  };

            Producer pfizer = new Producer() { Id = 1, ProducerName = "Pfizer", Medicines = new List<Medicine> { xanil, covax }, Location = "Hungary" };

         


            mockMedicineRepository.Setup(medRepo => medRepo.Create(It.IsAny<Medicine>()));

            mockMedicineRepository.Setup(medRepo => medRepo.GetAll()).Returns(
                   new List<Medicine>
                   {
                        new Medicine()
                        {
                            Id=1,
                            MedicineName= "Alpha",
                            Producer=pfizer,
                            BasePrice = 1000,
                            Heals ="Covid",
                            ProducerID=1

                        },
                        new Medicine()
                        {
                            Id=2,
                            MedicineName = "Beta",
                            Producer = pfizer,
                            BasePrice=2000,
                            Heals = "Nátha",
                             ProducerID=1
                        }
                   }.AsQueryable()
                );



            mockPatientRepository.Setup(patientRepo => patientRepo.Create(It.IsAny<Patient>()));
            mockPatientRepository.Setup(patientRepo => patientRepo.GetAll()).Returns(
                new List<Patient>
                {
                    new Patient()
                    {
                        Id=1,
                        Illness= "Headache",
                        Medicine = xanil,
                        PatientName = "Bence",
                        MedicineID = 1

                     },
                    new Patient()
                    {
                        Id=2,
                        Illness= "Covid",
                        Medicine = covax,
                        PatientName = "Dani",
                        MedicineID =2


                    }



                }.AsQueryable()

                );
            mockProducerRepository.Setup(producerRep => producerRep.Create(It.IsAny<Producer>()));
            mockProducerRepository.Setup(producerRep => producerRep.GetAll()).Returns(
                new List<Producer>
                {
                    new Producer(){
                        Id=1,
                        Location= "Hungary",
                     ProducerName = "Pfizer",
                        Medicines = new List<Medicine> {
                        new Medicine() { Id=1,MedicineName = "Covax" ,Heals="Covid",ProducerID=1, BasePrice=2000},
                        new Medicine() { Id=2,MedicineName = "Xalin",Heals="Nátha" ,ProducerID=1,BasePrice=1000}
                        }

                },
                    new Producer(){
                        Id=2,
                     ProducerName = "Béres",
                     Location = "USA",
                        Medicines = new List<Medicine> {
                        new Medicine() { Id=3,MedicineName = "Novirin",Heals="Nátha",ProducerID=2, BasePrice=3000 },
                        new Medicine() {Id=4, MedicineName = "Avil",Heals="Nátha" ,ProducerID=2, BasePrice=2500}
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
        [TestCase(0)]
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
                    patientLogic.Create(new Patient()
                    {
                        Illness = "yes",
                        MedicineID = medicineId,
                        Medicine = new Medicine() { MedicineName = "Covax", Heals = "Covid" }
                    });
                },
                Throws.Nothing
                );
        }
        [TestCase(0)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void TestCreateInValidPatient(int medicineId)
        {
            Assert.That(
                () =>
                {
                    patientLogic.Create(new Patient()
                    {
                        Illness = "no",
                        MedicineID = medicineId,
                        Medicine = new Medicine() { MedicineName = "Covax", Heals = "Covid" }
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
            Medicine xanil = new Medicine() { MedicineName = "Xanil", Heals = "Nátha" };
            Medicine covax = new Medicine() { MedicineName = "Covax", Heals = "Covid" };



            Assert.That(
                () =>
                {
                    producerLogic.Create(new Producer()
                    {
                        ProducerName = producerName,
                        Medicines = new List<Medicine> { xanil, covax }


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
                    producerLogic.Create(new Producer()
                    {
                        ProducerName = producername,
                        Medicines = new List<Medicine> {
                        new Medicine() { MedicineName = "Covax",Heals = "Covid" },
                        new Medicine() { MedicineName = "Xalin" ,Heals = "Nátha"}

                }
                    });
                },
                Throws.Exception
                );
        }
        /*
        [Test]
        public void TestGetAllprodducers()
        {/*
            Medicine xanil = new Medicine() { MedicineName = "Xanil", Heals = "Nátha" };
            Medicine covax = new Medicine() { MedicineName = "Covax", Heals = "Covid" };
            


            var res = producerLogic.GetAll();
            Assert.That(res, Is.EquivalentTo(
                
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


                }
                ));
        }*/

        [TestCase(0)]
        [TestCase(-1)]
        public void TestInvalidGetOneProdducers(int id)
        {
           

            Assert.That(
              () =>
              {
                  producerLogic.GetOne(id);   
              },
                  
              
              Throws.Exception
              );
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestInvalidGetOneMedicine(int id)
        {

            Assert.That(
              () =>
              {
                  medLogic.GetOne(id);
              },


              Throws.Exception
              );
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void TestInvalidGetOnePatient(int id)
        {

            Assert.That(
              () =>
              {
                  patientLogic.GetOne(id);
              },


              Throws.Exception
              );
        }

        /*
        [TestCase(1)]
        public void TestGetOneProdducers(int id)
        {
        
        var res = producerLogic.GetOne(id);
        CollectionAssert.AreEqual(res, 

            new List<Producer>
            {

            new Producer(){
                 ProducerName = "Pfizer",
                    Medicines = new List<Medicine> {
                    new Medicine() { MedicineName = "Covax" ,Heals="Covid"},
                    new Medicine() { MedicineName = "Xalin",Heals="Nátha" }
                    }

            }



            }
            );     


     }*/
        /*
        [Test]
        public void TestGetallProdducers()
        {
           

            var res = producerLogic.GetAll();
            CollectionAssert.AreEqual(res, 
                           
                new List<Producer>
                {
                    new Producer(){
                        Id=1,
                     ProducerName = "Pfizer",
                        Medicines = new List<Medicine> {
                        new Medicine() { Id=1,MedicineName = "Covax" ,Heals="Covid",ProducerID=1, BasePrice=2000},
                        new Medicine() { Id=2,MedicineName = "Xalin",Heals="Nátha" ,ProducerID=1,BasePrice=1000}
                        }

                },
                    new Producer(){
                        Id=2,
                     ProducerName = "Béres",
                        Medicines = new List<Medicine> {
                        new Medicine() { Id=3,MedicineName = "Novirin",Heals="Nátha",ProducerID=2, BasePrice=3000 },
                        new Medicine() {Id=4, MedicineName = "Avil",Heals="Nátha" ,ProducerID=2, BasePrice=2500}
                        }

                }



                }
                );
        
             







         }*/

            [TestCase(1)]
        public void TestDeletProducer(int id)
        {/*
            Medicine xanil = new Medicine() { MedicineName = "Xanil", Heals = "Nátha" };
            Medicine covax = new Medicine() { MedicineName = "Covax", Heals = "Covid" };
            */


            Assert.That(
                () =>
                {
                    producerLogic.Delete(id);
                },
                Throws.Nothing
                );
        }

        [TestCase(1)]
        public void TestDeletMed(int id)
        {/*
            Medicine xanil = new Medicine() { MedicineName = "Xanil", Heals = "Nátha" };
            Medicine covax = new Medicine() { MedicineName = "Covax", Heals = "Covid" };
            */


            Assert.That(
                () =>
                {
                    medLogic.Delete(id);
                },
                Throws.Nothing
                );
        }


        [TestCase(1)]
        public void TestDeletePatient(int id)
        {
                /*
            Medicine xanil = new Medicine() { MedicineName = "Xanil", Heals = "Nátha" };
            Medicine covax = new Medicine() { MedicineName = "Covax", Heals = "Covid" };
                */


            Assert.That(
                () =>
                {
                    patientLogic.Delete(id);
                },
                Throws.Nothing
                );
        }



        [Test]
        public void TestAverage()
        {/*
            Producer pfizer = new Producer() { ProducerName = "Pfizer", Id = 1, Location = "Hungary" };
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
            );*/
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
        {/*
            Producer pfizer = new Producer() { ProducerName = "Pfizer", Id = 1, Location = "Hungary" };
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
            );*/
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
        {/*
            Producer pfizer = new Producer() { ProducerName = "Pfizer", Id = 1, Location = "Hungary" };
            medLogic.Create(
                        new Medicine()
                        {
                            ProducerID = 1,
                            Producer = pfizer,
                            MedicineName = "Alpha",
                            BasePrice = 1000,
                            Heals = "Covid"
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
            );*/
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

        [Test]
        public void TestPatientMed()
        {/*
            Producer pfizer = new Producer() { ProducerName = "Pfizer", Id = 1, Location = "Hungary" };
            medLogic.Create(
                        new Medicine()
                        {
                            Id=1,
                            ProducerID = 1,
                            Producer = pfizer,
                            MedicineName = "Alpha",
                            BasePrice = 1000,
                            Heals = "Covid"
                        }
            );
            medLogic.Create(
                        new Medicine()
                        {
                            Id = 2,
                            ProducerID = 1,
                            Producer = pfizer,                            
                            MedicineName = "Beta",
                            BasePrice = 2000,
                            Heals = "Nátha"
                        }
            );

            patientLogic.Create(

                new Patient()
                {
                    
                    MedicineID=1,
                    PatientName = "Bence",
                    Illness= "Nátha"
                }

                );

            */
            var res = patientLogic.GetThreatment();
            Assert.That(res, Is.EquivalentTo(
                new List<Threatments>
                {
                      new Threatments()
                {
                    
                    PatientName = "Dani",
                    Illness= "Covid",
                    MedicineName= "Covax"
                }

                }
                ));




        }



        [Test]
        public void TestHungary()
        {/*
            Producer pfizer = new Producer() { ProducerName = "Pfizer", Id = 1, Location = "Hungary" };
            medLogic.Create(
                        new Medicine()
                        {
                            ProducerID = 1,
                            Producer = pfizer,
                            MedicineName = "Alpha",
                            BasePrice = 1000,
                            Heals = "Covid"
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
            );*/
            var res = medLogic.GetLocations();
            Assert.That(res, Is.EquivalentTo(
                new List<LocationResults>
                {
                    new LocationResults()
                    {
                        ProducersName="Pfizer",
                        Location = "Hungary",
                        MedicineName = "Alpha"
                    },
                    new LocationResults()
                    {
                        ProducersName="Pfizer",
                        Location = "Hungary",
                        MedicineName = "Beta"
                    }
                }
                ));




        }
    }

}


