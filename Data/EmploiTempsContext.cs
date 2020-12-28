using emploiTemps.Models;
using Microsoft.EntityFrameworkCore;

namespace emploiTemps.Data 
{
    public class EmploiTempsContext: DbContext
    {

        public EmploiTempsContext(DbContextOptions<EmploiTempsContext> options)
            : base(options)
        {
        }

        public DbSet<Departement> Departements { get; set; }
        public DbSet<Unite> Unites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Periode> Periodes { get; set; }
        public DbSet<Salle> Salles { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Niveau> Niveaus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*modelBuilder.Entity<Discussion>()
                .HasMany(c => c.Clients).WithMany(i => i.Discussions)
                .Map(t => t.MapLeftKey("idDiscussion")
                    .MapRightKey("idClient")
                    .ToTable("DiscussionClient"));

            modelBuilder.Entity<Admin>()
                .HasMany(c => c.Clients).WithMany(i => i.Admins)
                .Map(t => t.MapLeftKey("idAdmin")
                    .MapRightKey("idClient")
                    .ToTable("AdminClient"));*/

            modelBuilder.Entity<UniteEnseignant>()
            .HasKey(t => new { t.idUnite, t.idEnseignant });

            modelBuilder.Entity<UniteEnseignant>()
                .HasOne(pt => pt.Unite)
                .WithMany(p => p.UniteEnseignants)
                .HasForeignKey(pt => pt.idUnite);

            modelBuilder.Entity<UniteEnseignant>()
                .HasOne(pt => pt.Enseignant)
                .WithMany(t => t.UniteEnseignants)
                .HasForeignKey(pt => pt.idEnseignant);

            /*Configuration de Unite et Periode*/
            modelBuilder.Entity<UnitePeriode>()
            .HasKey(t => new { t.idUnite, t.idPeriode });

            modelBuilder.Entity<UnitePeriode>()
                .HasOne(pt => pt.Unite)
                .WithMany(p => p.UnitePeriodes)
                .HasForeignKey(pt => pt.idUnite);

            modelBuilder.Entity<UnitePeriode>()
                .HasOne(pt => pt.Periode)
                .WithMany(t => t.UnitePeriodes)
                .HasForeignKey(pt => pt.idPeriode);

            /*Configuration de Unite et Salle*/
            modelBuilder.Entity<Seance>()
            .HasKey(t => new { t.idUnite, t.idSalle });

            modelBuilder.Entity<Seance>()
                .HasOne(pt => pt.Unite)
                .WithMany(p => p.Seances)
                .HasForeignKey(pt => pt.idUnite);

            modelBuilder.Entity<Seance>()
                .HasOne(pt => pt.Salle)
                .WithMany(t => t.Seances)
                .HasForeignKey(pt => pt.idSalle);

            /*Configuration de Niveau et Option*/
            modelBuilder.Entity<NiveauOption>()
            .HasKey(t => new { t.idNiveau, t.idOption });

            modelBuilder.Entity<NiveauOption>()
                .HasOne(pt => pt.Niveau)
                .WithMany(p => p.NiveauOptions)
                .HasForeignKey(pt => pt.idNiveau);

            modelBuilder.Entity<NiveauOption>()
                .HasOne(pt => pt.Option)
                .WithMany(t => t.NiveauOptions)
                .HasForeignKey(pt => pt.idOption); 
        }
        
    }
}
