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
    [Table("Patients")]
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string PatientName { get; set; }


        [Required]
        [MaxLength(20)]
        public string Illness { get; set; }
     

        [ForeignKey(nameof(Medicine))]
        public int MedicineID { get; set; }

        


        [NotMapped]
        [JsonIgnore]
        public virtual Medicine Medicine { get; set; }
    }
}
