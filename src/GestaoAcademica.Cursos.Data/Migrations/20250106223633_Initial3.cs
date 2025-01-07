using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoAcademica.Cursos.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Professor",
                table: "Disciplinas",
                newName: "NomeProfessor");

            migrationBuilder.RenameColumn(
                name: "Coordenador",
                table: "Cursos",
                newName: "NomeProfessorCoordenador");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProfessor",
                table: "Disciplinas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdProfessorCoordenador",
                table: "Cursos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProfessor",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "IdProfessorCoordenador",
                table: "Cursos");

            migrationBuilder.RenameColumn(
                name: "NomeProfessor",
                table: "Disciplinas",
                newName: "Professor");

            migrationBuilder.RenameColumn(
                name: "NomeProfessorCoordenador",
                table: "Cursos",
                newName: "Coordenador");
        }
    }
}
