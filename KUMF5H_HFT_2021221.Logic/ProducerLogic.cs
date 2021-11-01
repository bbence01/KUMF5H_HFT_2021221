﻿using KUMF5H_HFT_2021221.Models;
using KUMF5H_HFT_2021221.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KUMF5H_HFT_2021221.Logic
{
    public interface IProducerLogic
    {
        IList<Producer> GetAll();
        Producer GetOne(int id);
        void ChangeProducerName(int id, string newProducerName);
        void Create(Producer newProducer);
        void Delete(Producer forDelete);
    }

    public class Producerlogic : IProducerLogic
    {
        IProducerLogic producerRepository;

        public Producerlogic(IProducerLogic producerRepository)
        {
            this.producerRepository = producerRepository;
        }

        public void ChangeProducerName(int id, string newProducerName)
        {
            producerRepository.ChangeProducerName(id, newProducerName);
        }

        public void Create(Producer newProducer)
        {
            producerRepository.Create(newProducer);
        }

        public void Delete(Producer forDelete)
        {
            producerRepository.Delete(forDelete);
        }

        public IList<Producer> GetAll()
        {
            return producerRepository.GetAll().ToList();
        }

        public Producer GetOne(int id)
        {
            return producerRepository.GetOne(id);
        }
    }
}
