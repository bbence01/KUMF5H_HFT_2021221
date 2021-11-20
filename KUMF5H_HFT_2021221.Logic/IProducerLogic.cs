﻿using KUMF5H_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Logic
{
    public interface IProducerLogic
    {
        IList<Producer> GetAll();
        Producer GetOne(int id);
        void ChangeProducerName(int id, string newProducerName);

        void Create(Producer newProducer);
        void Update(Producer updated);
        void Delete(Producer forDelete);
        void Delete(int id);

    }
}
