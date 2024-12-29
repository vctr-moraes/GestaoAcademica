using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoAcademica.Professores.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "varchar(100)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Pais = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(100)", nullable: false),
                    Referencia = table.Column<string>(type: "varchar(100)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
