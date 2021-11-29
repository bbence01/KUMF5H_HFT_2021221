using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Models
{
    public class AverageResult
    {
        public string ProducerName { get; set; }
        public double AveragePrice { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is AverageResult)
            {
                var other = obj as AverageResult;
                return this.AveragePrice == other.AveragePrice && this.ProducerName == other.ProducerName;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.ProducerName.GetHashCode() + (int)this.AveragePrice;
        }

        public override string ToString()
        {
            return $"Medicine Name={ProducerName}, Average Price={AveragePrice}";
        }
    }
}
