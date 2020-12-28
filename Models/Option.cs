using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace emploiTemps.Models
{
    public class Option
    {
        [Key]
        public int idOption {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "nameOption cannot be longer than 50 characters.", MinimumLength=5)]
        public string nameOption {get; set;}

        public virtual ICollection<NiveauOption> NiveauOptions {get; set;}
    }
}