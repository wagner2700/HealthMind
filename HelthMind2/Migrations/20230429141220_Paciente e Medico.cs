using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelthMind2.Migrations
{
    /// <inheritdoc />
    public partial class PacienteeMedico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MEDICO",
                columns: table => new
                {
                    MEDICOID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOMEMEDICO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ESPECIALIDADE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CRM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICO", x => x.MEDICOID);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTE",
                columns: table => new
                {
                    PACIENTEID = table.Column<int>(name: "PACIENTE ID", type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ESTADO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MedicoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.PACIENTEID);
                    table.ForeignKey(
                        name: "FK_PACIENTE_MEDICO_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "MEDICO",
                        principalColumn: "MEDICOID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PACIENTE_MedicoId",
                table: "PACIENTE",
                column: "MedicoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PACIENTE");

            migrationBuilder.DropTable(
                name: "MEDICO");
        }
    }
}
