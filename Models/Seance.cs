namespace emploiTemps.Models
{
    public class Seance
    {
        public int idUnite {get; set;}
        public Unite Unite {get; set;}
        public int idSalle {get; set;}
        public Salle Salle {get; set;}
    }
}