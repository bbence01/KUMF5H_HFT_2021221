using KUMF5H_HFT_2021221.Models;
using KUMF5H_HFT_2021221.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KUMF5H_HFT_2021221.Logic
{
  

    public class Producerlogic : IProducerLogic
    {
        IProducerReposiotory producerRepository;

        public Producerlogic(IProducerReposiotory producerRepository)
        {
            this.producerRepository = producerRepository;
        }

        public void ChangeProducerName(int id, string newProducerName)
        {
            producerRepository.ChangeProducerName(id, newProducerName);
        }

        public void Create(Producer newProducer)
        {
            if (newProducer.Name ==null||newProducer.Name =="")
                throw new ArgumentException(nameof(newProducer), "Name is needed");
            producerRepository.Create(newProducer);



        }

        public void Delete(Producer forDelete)
        {
            producerRepository.Delete(forDelete);
        }


        public void Delete(int id)
        {
            producerRepository.Delete(id);
        }

        public IEnumerable<Producer> GetAll()
        {
            return producerRepository.GetAll().ToList();
        }

        public Producer GetOne(int id)
        {
            return producerRepository.GetOne(id);
        }

        public void Update(Producer value)
        {
            producerRepository.Update(value);
        }
    }
}
