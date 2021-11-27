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
    [Table("Producer")]
    public class Producer
    {
      
        
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [MaxLength(20)]
            [Required]
            public string Name { get; set; }


            // travel proberty
            [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Medicine> Medicines { get; set; }

            public Producer()
            {
                Medicines = new HashSet<Medicine>();
            }

        
    }
}
