using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Models
{
    public class Threatments
    {
        public string PatientName { get; set; }
        public string Illness { get; set; }
        public string MedicineName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Threatments)
            {
                var other = obj as Threatments;
                return this.PatientName == other.PatientName && this.Illness == other.Illness && this.MedicineName == other.MedicineName;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.PatientName.GetHashCode() + this.Illness.GetHashCode() + this.MedicineName.GetHashCode();
        }

        public override string ToString()
        {
            return $"Patient PatientName={PatientName}, Illness={Illness} ,MedicineName={MedicineName} ";
        }
    }
}

