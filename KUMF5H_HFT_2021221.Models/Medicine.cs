using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KUMF5H_HFT_2021221.Models
{
    [Table("Medicine")]
  public class Medicine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id", TypeName = "int")]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int? BasePrice { get; set; }


        [ForeignKey(nameof(Producer))]
        public int ProducerID { get; set; }


        // travel proberty
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Patient> Patients { get; set; }

        /*
        [NotMapped]
        public virtual ICollection<Producer> Producers { get; set; }
        */


        [NotMapped]
        [JsonIgnore]
        public virtual Producer Producer { get; set; }

        public Medicine()
        {
            Patients = new HashSet<Patient>();
           // Producers = new HashSet<Producer>();
        }


    }
}
