using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Healy_API.Migrations
{
    /// <inheritdoc />
    public partial class FixTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_EXAME_T_PACIENTE_PacienteId",
                table: "T_EXAME");

            migrationBuilder.DropIndex(
                name: "IX_T_EXAME_PacienteId",
                table: "T_EXAME");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "T_EXAME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "T_EXAME",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_T_EXAME_PacienteId",
                table: "T_EXAME",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_T_EXAME_T_PACIENTE_PacienteId",
                table: "T_EXAME",
                column: "PacienteId",
                principalTable: "T_PACIENTE",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
