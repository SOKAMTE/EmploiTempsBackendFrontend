using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace emploiTemps.Models
{ 
    public class Niveau
    {
        [Key]
        public int idNiveau {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "nameLevel cannot be longer than 50 characters.", MinimumLength=5)]
        public string nameLevel {get; set;}

        public virtual ICollection<Unite> Unites {get; set;}

        public virtual ICollection<NiveauOption> NiveauOptions {get; set;}
    }
}