﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using emploiTemps.Data;

namespace emploiTemps.Migrations
{
    [DbContext(typeof(EmploiTempsContext))]
    partial class EmploiTempsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("emploiTemps.Models.Departement", b =>
                {
                    b.Property<int>("idDepartement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("codeDepartement")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.Property<string>("nameDepartement")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.HasKey("idDepartement");

                    b.ToTable("Departements");
                });

            modelBuilder.Entity("emploiTemps.Models.Enseignant", b =>
                {
                    b.Property<int>("idEnseignant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("mail")
                        .HasColumnType("varchar(45)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(10);

                    b.Property<string>("titre")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(10);

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.HasKey("idEnseignant");

                    b.ToTable("Enseignants");
                });

            modelBuilder.Entity("emploiTemps.Models.Niveau", b =>
                {
                    b.Property<int>("idNiveau")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nameLevel")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.HasKey("idNiveau");

                    b.ToTable("Niveaus");
                });

            modelBuilder.Entity("emploiTemps.Models.NiveauOption", b =>
                {
                    b.Property<int>("idNiveau")
                        .HasColumnType("int");

                    b.Property<int>("idOption")
                        .HasColumnType("int");

                    b.HasKey("idNiveau", "idOption");

                    b.HasIndex("idOption");

                    b.ToTable("NiveauOption");
                });

            modelBuilder.Entity("emploiTemps.Models.Option", b =>
                {
                    b.Property<int>("idOption")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nameOption")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.HasKey("idOption");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("emploiTemps.Models.Periode", b =>
                {
                    b.Property<int>("idPeriode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("dateDebutPeriode")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("dateFinPeriode")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("namePeriode")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.HasKey("idPeriode");

                    b.ToTable("Periodes");
                });

            modelBuilder.Entity("emploiTemps.Models.Salle", b =>
                {
                    b.Property<int>("idSalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("nameSalle")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.Property<string>("nombreSalle")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.HasKey("idSalle");

                    b.ToTable("Salles");
                });

            modelBuilder.Entity("emploiTemps.Models.Seance", b =>
                {
                    b.Property<int>("idUnite")
                        .HasColumnType("int");

                    b.Property<int>("idSalle")
                        .HasColumnType("int");

                    b.HasKey("idUnite", "idSalle");

                    b.HasIndex("idSalle");

                    b.ToTable("Seance");
                });

            modelBuilder.Entity("emploiTemps.Models.Semestre", b =>
                {
                    b.Property<int>("idSemestre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("dateDebutSemestre")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("dateFinSemestre")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("nameSemestre")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.Property<string>("nombreSemestre")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.HasKey("idSemestre");

                    b.ToTable("Semestres");
                });

            modelBuilder.Entity("emploiTemps.Models.Unite", b =>
                {
                    b.Property<int>("idUnite")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartementID")
                        .HasColumnType("int");

                    b.Property<int>("NiveauID")
                        .HasColumnType("int");

                    b.Property<int>("SemestreID")
                        .HasColumnType("int");

                    b.Property<string>("codeUnite")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.Property<string>("nameUnite")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.Property<string>("nombrereditUnite")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.HasKey("idUnite");

                    b.HasIndex("DepartementID");

                    b.HasIndex("NiveauID");

                    b.HasIndex("SemestreID");

                    b.ToTable("Unites");
                });

            modelBuilder.Entity("emploiTemps.Models.UniteEnseignant", b =>
                {
                    b.Property<int>("idUnite")
                        .HasColumnType("int");

                    b.Property<int>("idEnseignant")
                        .HasColumnType("int");

                    b.HasKey("idUnite", "idEnseignant");

                    b.HasIndex("idEnseignant");

                    b.ToTable("UniteEnseignant");
                });

            modelBuilder.Entity("emploiTemps.Models.UnitePeriode", b =>
                {
                    b.Property<int>("idUnite")
                        .HasColumnType("int");

                    b.Property<int>("idPeriode")
                        .HasColumnType("int");

                    b.HasKey("idUnite", "idPeriode");

                    b.HasIndex("idPeriode");

                    b.ToTable("UnitePeriode");
                });

            modelBuilder.Entity("emploiTemps.Models.User", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartementID")
                        .HasColumnType("int");

                    b.Property<string>("mail")
                        .HasColumnType("varchar(45)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(10);

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(50);

                    b.HasKey("idUser");

                    b.HasIndex("DepartementID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("emploiTemps.Models.NiveauOption", b =>
                {
                    b.HasOne("emploiTemps.Models.Niveau", "Niveau")
                        .WithMany("NiveauOptions")
                        .HasForeignKey("idNiveau")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("emploiTemps.Models.Option", "Option")
                        .WithMany("NiveauOptions")
                        .HasForeignKey("idOption")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("emploiTemps.Models.Seance", b =>
                {
                    b.HasOne("emploiTemps.Models.Salle", "Salle")
                        .WithMany("Seances")
                        .HasForeignKey("idSalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("emploiTemps.Models.Unite", "Unite")
                        .WithMany("Seances")
                        .HasForeignKey("idUnite")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("emploiTemps.Models.Unite", b =>
                {
                    b.HasOne("emploiTemps.Models.Departement", "Departement")
                        .WithMany("Unites")
                        .HasForeignKey("DepartementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("emploiTemps.Models.Niveau", "Niveau")
                        .WithMany("Unites")
                        .HasForeignKey("NiveauID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("emploiTemps.Models.Semestre", "Semestre")
                        .WithMany("Unites")
                        .HasForeignKey("SemestreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("emploiTemps.Models.UniteEnseignant", b =>
                {
                    b.HasOne("emploiTemps.Models.Enseignant", "Enseignant")
                        .WithMany("UniteEnseignants")
                        .HasForeignKey("idEnseignant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("emploiTemps.Models.Unite", "Unite")
                        .WithMany("UniteEnseignants")
                        .HasForeignKey("idUnite")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("emploiTemps.Models.UnitePeriode", b =>
                {
                    b.HasOne("emploiTemps.Models.Periode", "Periode")
                        .WithMany("UnitePeriodes")
                        .HasForeignKey("idPeriode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("emploiTemps.Models.Unite", "Unite")
                        .WithMany("UnitePeriodes")
                        .HasForeignKey("idUnite")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("emploiTemps.Models.User", b =>
                {
                    b.HasOne("emploiTemps.Models.Departement", "Departement")
                        .WithMany("Users")
                        .HasForeignKey("DepartementID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
