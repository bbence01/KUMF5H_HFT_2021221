using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Models
{
   public class SameMedicineProducers
    {

        public string ProducersName { get; set; }
       
        public string MedicineName { get; set; }

        public string Illness { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is SameMedicineProducers)
            {
                var other = obj as SameMedicineProducers;
                return this.ProducersName == other.ProducersName  && this.MedicineName == other.MedicineName && this.Illness == other.Illness;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.ProducersName.GetHashCode() + this.MedicineName.GetHashCode()+this.Illness.GetHashCode();
        }

        public override string ToString()
        {
            return $"Producers Name={ProducersName},Illness={Illness} ,Medicine Name={MedicineName} ";
        }
    }
}
