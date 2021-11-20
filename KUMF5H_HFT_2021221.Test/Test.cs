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

            Medicine xanil = new Medicine() { Name = "Xanil" };
            Medicine covax = new Medicine() { Name = "Covax" };

            Producer pfizer = new Producer() { Name = "Pfizer", Medicines= new List<Medicine> { xanil,covax } };

           


            mockMedicineRepository.Setup(medRepo => medRepo.Create(It.IsAny<Medicine>()));

            mockMedicineRepository.Setup(medRepo => medRepo.GetAll()).Returns(
                   new List<Medicine>
                   {
                        new Medicine()
                        {
                            Name= "alpha",
                            Producer=pfizer,
                            BasePrice = 1000,

                        },
                        new Medicine()
                        {
                            Name = "beta",
                            Producer = pfizer,
                            BasePrice=2000
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
                        Medicine = xanil



                     },
                    new Patient()
                    {
                        Illness= "Covid",
                        Medicine = covax



                    }



                }.AsQueryable()

                );
            mockProducerRepository.Setup(producerRep => producerRep.Create(It.IsAny<Producer>()));
            mockProducerRepository.Setup(producerRep => producerRep.GetAll()).Returns(
                new List<Producer>
                {
                    new Producer(){
                     Name = "Pfizer",
                        Medicines = new List<Medicine> {
                        new Medicine() { Name = "Covax" },
                        new Medicine() { Name = "Xalin" }
                        }

                },
                    new Producer(){
                     Name = "Béres",
                        Medicines = new List<Medicine> {
                        new Medicine() { Name = "Novirin" },
                        new Medicine() { Name = "Avil" }
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
                    medLogic.Create(new Medicine() { Name = "yes", ProducerID = producerId });
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
                    medLogic.Create(new Medicine() { Name = "no", ProducerID = producerId });
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
                    patientLogic.Create(new Patient() { Illness = "yes", MedicineID = medicineId , Medicine = new Medicine() { Name = "Covax" }
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
                    patientLogic.Create(new Patient() { Illness = "no", MedicineID = medicineId , Medicine = new Medicine() { Name = "Covax" }
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
            Medicine xanil = new Medicine() { Name = "Xanil" };
            Medicine covax = new Medicine() { Name = "Covax" };

            

            Assert.That(
                () =>
                {
                    producerLogic.Create(new Producer()
                    {
                      Name = producerName,
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
                        Name = producername, 
                        Medicines = new List<Medicine> {
                        new Medicine() { Name = "Covax" },
                        new Medicine() { Name = "Xalin" }

                } });
                },
                Throws.Exception
                );
        }




        [Test]
        public void TestAverage()
        {
            Producer pfizer = new Producer() { Name = "Pfizer", Id = 1 };
            medLogic.Create(
                        new Medicine()
                        {
                            ProducerID = 1,
                            Producer = pfizer,
                            Name = "Alpha",
                            BasePrice = 1000
                        }
            );
            medLogic.Create(
                        new Medicine()
                        {
                            ProducerID = 1,
                            Producer = pfizer,
                            Name = "Beta",
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





    }
}


