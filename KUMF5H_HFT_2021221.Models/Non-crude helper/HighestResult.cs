using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Models
{
   public class HighestResult
    {
        public string ProducerName { get; set; }
        public double HighestPrice { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is HighestResult)
            {
                var other = obj as HighestResult;
                return this.HighestPrice == other.HighestPrice && this.ProducerName == other.ProducerName;
            }
            else
            {
                return false;
            }
        }



        public override int GetHashCode()
        {
            return this.ProducerName.GetHashCode() + (int)this.HighestPrice;
        }

        public override string ToString()
        {
            return $"Medicine Name={ProducerName}, Highest Price={HighestPrice}";
        }
    }
}
