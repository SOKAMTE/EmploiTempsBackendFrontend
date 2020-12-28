using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace emploiTemps.Models
{
    public class Salle
    {
        [Key]
        public int idSalle {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "nameSalle cannot be longer than 50 characters.", MinimumLength=5)]
        public string nameSalle {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "nombreSalle cannot be longer than 50 characters.", MinimumLength=5)]
        public int nombreSalle {get; set;}

        public virtual ICollection<Seance> Seances {get; set;}
    }
}