using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace emploiTemps.Models
{
    public class Enseignant
    {
        [Key]
        public int idEnseignant {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "username cannot be longer than 50 characters.", MinimumLength=5)]
        public string username {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(10, ErrorMessage = "password cannot be longer than 50 characters.", MinimumLength=2)]
        public string password {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(10, ErrorMessage = "titre cannot be longer than 50 characters.", MinimumLength=2)]
        public string titre {get; set;}

        [Column(TypeName = "varchar(45)")]
        [DataType(DataType.EmailAddress)]
        public string mail {get; set;}

        public virtual ICollection<UniteEnseignant> UniteEnseignants {get; set;}
    } 
}