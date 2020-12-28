namespace emploiTemps.Models
{
    public class UniteEnseignant
    {
        public int idUnite {get; set;}
        public Unite Unite {get; set;}
        public int idEnseignant {get; set;}
        public Enseignant Enseignant {get; set;}
    }
}