using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace emploiTemps.Models
{
    public class Unite
    {
        [Key]
        public int idUnite {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "codeUnite cannot be longer than 50 characters.", MinimumLength=5)]
        public string codeUnite {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "nameUnite cannot be longer than 50 characters.", MinimumLength=5)]
        public string nameUnite {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "nombreCreditUnite cannot be longer than 50 characters.", MinimumLength=5)]
        public int nombrereditUnite {get; set;}

        public int DepartementID {get; set;}

        public virtual Departement Departement {get; set;}

        public int SemestreID {get; set;}

        public virtual Semestre Semestre {get; set;}

        public int NiveauID {get; set;}

        public virtual Niveau Niveau {get; set;}

        public virtual ICollection<UniteEnseignant> UniteEnseignants {get; set;}

        public virtual ICollection<UnitePeriode> UnitePeriodes {get; set;}

        public virtual ICollection<Seance> Seances {get; set;} 
    }
}