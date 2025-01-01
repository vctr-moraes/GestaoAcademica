using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoAcademica.Turmas.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: false),
                    DataEncerramento = table.Column<DateTime>(type: "date", nullable: false),
                    StatusTurma = table.Column<int>(type: "int", nullable: false),
                    IdCurso = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeCurso = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAluno = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeAluno = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "date", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "date", nullable: false),
                    MotivoSaida = table.Column<int>(type: "int", nullable: false),
                    StatusAluno = table.Column<int>(type: "int", nullable: false),
                    IdTurma = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunosCursantes_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursantes_IdTurma",
                table: "AlunosCursantes",
                column: "IdTurma");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursantes");

            migrationBuilder.DropTable(
                name: "Turmas");
        }
    }
}
