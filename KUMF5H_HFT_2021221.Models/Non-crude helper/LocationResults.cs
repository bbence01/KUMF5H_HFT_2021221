using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Models
{
   public class LocationResults
    {
        public string ProducersName { get; set; }

        public string MedicineName { get; set; }

        public string Location { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is LocationResults)
            {
                var other = obj as LocationResults;
                return this.ProducersName == other.ProducersName && this.MedicineName == other.MedicineName && this.Location == other.Location;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.ProducersName.GetHashCode() + this.MedicineName.GetHashCode()+this.Location.GetHashCode();
        }

        public override string ToString()
        {
            return $"ProducersName={ProducersName},Location={Location} ,MedicineName={MedicineName} ";
        }
    }
}
