using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace emploiTemps.Models
{
    public class Semestre
    {
        [Key]
        public int idSemestre {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "nameSemestre cannot be longer than 50 characters.", MinimumLength=5)]
        public string nameSemestre {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "nombreSemestre cannot be longer than 50 characters.", MinimumLength=5)]
        public int nombreSemestre {get; set;}

        [Column(TypeName = "varchar(255)")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateDebutSemestre {get; set;}

        [Column(TypeName = "varchar(255)")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateFinSemestre {get; set;}

        public virtual ICollection<Unite> Unites {get; set;}
    }
}