using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace emploiTemps.Models
{
    public class Periode
    {
        [Key]
        public int idPeriode {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "namePeriode cannot be longer than 50 characters.", MinimumLength=5)]
        public string namePeriode {get; set;}

        [Column(TypeName = "varchar(255)")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateDebutPeriode {get; set;}

        [Column(TypeName = "varchar(255)")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dateFinPeriode {get; set;}

        public virtual ICollection<UnitePeriode> UnitePeriodes {get; set;}
    }
}