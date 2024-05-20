using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Healy_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_PACIENTE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PACIENTE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_PROFISSIONAL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    AreaAtuacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_PROFISSIONAL", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_EXAME",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeExame = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataRealizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Custo = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    PacienteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_EXAME", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_EXAME_T_PACIENTE_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "T_PACIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_EXAME_PacienteId",
                table: "T_EXAME",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_EXAME");

            migrationBuilder.DropTable(
                name: "T_PROFISSIONAL");

            migrationBuilder.DropTable(
                name: "T_PACIENTE");
        }
    }
}
