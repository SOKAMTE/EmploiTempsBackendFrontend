using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace emploiTemps.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    idDepartement = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codeDepartement = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false),
                    nameDepartement = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.idDepartement);
                });

            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    idEnseignant = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 10, nullable: false),
                    titre = table.Column<string>(type: "varchar(255)", maxLength: 10, nullable: false),
                    mail = table.Column<string>(type: "varchar(45)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.idEnseignant);
                });

            migrationBuilder.CreateTable(
                name: "Niveaus",
                columns: table => new
                {
                    idNiveau = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nameLevel = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveaus", x => x.idNiveau);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    idOption = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nameOption = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.idOption);
                });

            migrationBuilder.CreateTable(
                name: "Periodes",
                columns: table => new
                {
                    idPeriode = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    namePeriode = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false),
                    dateDebutPeriode = table.Column<string>(type: "varchar(255)", nullable: false),
                    dateFinPeriode = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodes", x => x.idPeriode);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                columns: table => new
                {
                    idSalle = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nameSalle = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false),
                    nombreSalle = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.idSalle);
                });

            migrationBuilder.CreateTable(
                name: "Semestres",
                columns: table => new
                {
                    idSemestre = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nameSemestre = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false),
                    nombreSemestre = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false),
                    dateDebutSemestre = table.Column<string>(type: "varchar(255)", nullable: false),
                    dateFinSemestre = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semestres", x => x.idSemestre);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idUser = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 10, nullable: false),
                    mail = table.Column<string>(type: "varchar(45)", nullable: true),
                    DepartementID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.idUser);
                    table.ForeignKey(
                        name: "FK_Users_Departements_DepartementID",
                        column: x => x.DepartementID,
                        principalTable: "Departements",
                        principalColumn: "idDepartement",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NiveauOption",
                columns: table => new
                {
                    idNiveau = table.Column<int>(nullable: false),
                    idOption = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiveauOption", x => new { x.idNiveau, x.idOption });
                    table.ForeignKey(
                        name: "FK_NiveauOption_Niveaus_idNiveau",
                        column: x => x.idNiveau,
                        principalTable: "Niveaus",
                        principalColumn: "idNiveau",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NiveauOption_Options_idOption",
                        column: x => x.idOption,
                        principalTable: "Options",
                        principalColumn: "idOption",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unites",
                columns: table => new
                {
                    idUnite = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codeUnite = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false),
                    nameUnite = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false),
                    nombrereditUnite = table.Column<string>(type: "varchar(255)", maxLength: 50, nullable: false),
                    DepartementID = table.Column<int>(nullable: false),
                    SemestreID = table.Column<int>(nullable: false),
                    NiveauID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unites", x => x.idUnite);
                    table.ForeignKey(
                        name: "FK_Unites_Departements_DepartementID",
                        column: x => x.DepartementID,
                        principalTable: "Departements",
                        principalColumn: "idDepartement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unites_Niveaus_NiveauID",
                        column: x => x.NiveauID,
                        principalTable: "Niveaus",
                        principalColumn: "idNiveau",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Unites_Semestres_SemestreID",
                        column: x => x.SemestreID,
                        principalTable: "Semestres",
                        principalColumn: "idSemestre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seance",
                columns: table => new
                {
                    idUnite = table.Column<int>(nullable: false),
                    idSalle = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seance", x => new { x.idUnite, x.idSalle });
                    table.ForeignKey(
                        name: "FK_Seance_Salles_idSalle",
                        column: x => x.idSalle,
                        principalTable: "Salles",
                        principalColumn: "idSalle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seance_Unites_idUnite",
                        column: x => x.idUnite,
                        principalTable: "Unites",
                        principalColumn: "idUnite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniteEnseignant",
                columns: table => new
                {
                    idUnite = table.Column<int>(nullable: false),
                    idEnseignant = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniteEnseignant", x => new { x.idUnite, x.idEnseignant });
                    table.ForeignKey(
                        name: "FK_UniteEnseignant_Enseignants_idEnseignant",
                        column: x => x.idEnseignant,
                        principalTable: "Enseignants",
                        principalColumn: "idEnseignant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniteEnseignant_Unites_idUnite",
                        column: x => x.idUnite,
                        principalTable: "Unites",
                        principalColumn: "idUnite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitePeriode",
                columns: table => new
                {
                    idUnite = table.Column<int>(nullable: false),
                    idPeriode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitePeriode", x => new { x.idUnite, x.idPeriode });
                    table.ForeignKey(
                        name: "FK_UnitePeriode_Periodes_idPeriode",
                        column: x => x.idPeriode,
                        principalTable: "Periodes",
                        principalColumn: "idPeriode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UnitePeriode_Unites_idUnite",
                        column: x => x.idUnite,
                        principalTable: "Unites",
                        principalColumn: "idUnite",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NiveauOption_idOption",
                table: "NiveauOption",
                column: "idOption");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_idSalle",
                table: "Seance",
                column: "idSalle");

            migrationBuilder.CreateIndex(
                name: "IX_UniteEnseignant_idEnseignant",
                table: "UniteEnseignant",
                column: "idEnseignant");

            migrationBuilder.CreateIndex(
                name: "IX_UnitePeriode_idPeriode",
                table: "UnitePeriode",
                column: "idPeriode");

            migrationBuilder.CreateIndex(
                name: "IX_Unites_DepartementID",
                table: "Unites",
                column: "DepartementID");

            migrationBuilder.CreateIndex(
                name: "IX_Unites_NiveauID",
                table: "Unites",
                column: "NiveauID");

            migrationBuilder.CreateIndex(
                name: "IX_Unites_SemestreID",
                table: "Unites",
                column: "SemestreID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartementID",
                table: "Users",
                column: "DepartementID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NiveauOption");

            migrationBuilder.DropTable(
                name: "Seance");

            migrationBuilder.DropTable(
                name: "UniteEnseignant");

            migrationBuilder.DropTable(
                name: "UnitePeriode");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Salles");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "Periodes");

            migrationBuilder.DropTable(
                name: "Unites");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "Niveaus");

            migrationBuilder.DropTable(
                name: "Semestres");
        }
    }
}
