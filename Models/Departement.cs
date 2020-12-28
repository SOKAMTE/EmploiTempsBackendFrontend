using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace emploiTemps.Models
{
    public class Departement
    {
        [Key]
        public int idDepartement {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "codeDepartement cannot be longer than 50 characters.", MinimumLength=5)]
        public string codeDepartement {get; set;}

        [Column(TypeName = "varchar(255)")]
        [Required]
        [StringLength(50, ErrorMessage = "nameDepartement cannot be longer than 50 characters.", MinimumLength=5)]
        public string nameDepartement {get; set;}

        public virtual ICollection<Unite> Unites {get; set;}

        public virtual ICollection<User> Users {get; set;}
    }
}