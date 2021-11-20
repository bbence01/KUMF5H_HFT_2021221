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

namespace KUMF5H_HFT_2021221.Tests
{

     class Test
    {



        Mock<IMedicineRepository> mockMedRepository = new Mock<IMedicineRepository>();
        MedicineLogic medLogic;
        public Test()
        {
            medLogic = new MedicineLogic(mockMedRepository.Object);

            Producer pfizer = new Producer() { Name = "Pfizer" };
            mockMedRepository.Setup(medRepo => medRepo.Create(It.IsAny<Medicine>()));

            mockMedRepository.Setup(medRepo => medRepo.GetAll()).Returns(
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
        }


        [TestCase(1)]
        [TestCase(10)]
        [TestCase(100)]
        public void TestCreateValid(int producerId)
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
        public void TestCreateInValid(int producerId)
        {
            Assert.That(
                () =>
                {
                    medLogic.Create(new Medicine() { Name = "no", ProducerID = producerId });
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


        [Test]
        public void PatientTest()
        {

        }

        [Test]
        public void ProduceTest()
        {

        }


    }
}

